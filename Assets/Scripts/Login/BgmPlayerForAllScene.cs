﻿using UnityEngine;
using System.Collections;

/// <summary>
/// BGM再生クラス（Loginシーン）
/// <para>　BGMを再生する。</para>
/// </summary>
public class BgmPlayerForAllScene : MonoBehaviour
{
    /// <summary>オーディオソースコンポ</summary>
    [SerializeField]
    private AudioSource audioSource;
    /// <summary>ログインシーンのBGM</summary>
    [SerializeField]
    private AudioClip bgm1;
    /// <summary>BGMの基本ボリューム</summary>
    [SerializeField]
    private float BaseVolume;
    /// <summary>フェード処理中か否か</summary>
    public bool isFadePlaying = false;
    /// <summary>フェードアウトにかける時間</summary>
    private double FadeOutSeconds = 1.0;
    /// <summary>フェード処理の経過時間</summary>
    private double FadeDeltaTime = 0;

    /// <summary>コンストラクタ</summary>
    public BgmPlayerForAllScene() { }

	void Start ()
    {
        // オーディオコンポを取得し、再生するBGMファイルを設定する
        audioSource = this.gameObject.GetComponent<AudioSource>();

        // BGMファイル(bgm1)はインスペクタから設定するが、設定されていなかったら下記をBGMとして設定する
        if (!bgm1) bgm1 = (AudioClip)Resources.Load("Sounds/BGM/AllScenes/AllScenesBGM1");

        // BGM決定し、再生する
        audioSource.clip = bgm1;
        audioSource.Play();
        audioSource.loop = true;
    }

    void Update()
    {
        // 基本ボリュームを設定
        if (!isFadePlaying) BaseVolume = 0.1f;

        // フェードアウト処理
        if (isFadePlaying)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime >= FadeOutSeconds)
            {
                // 設定したフェードにかける時間を過ぎたらフェード処理判定フラグをfalseにしてBGMを停止する
                FadeDeltaTime = FadeOutSeconds;
                audioSource.Stop();
                isFadePlaying = false;
            }
            // フェード処理を実施
            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds) * BaseVolume;
        }
    }

    /// <summary>
    /// BGM再生メソッド
    /// <para>　BGMを再生する。</para>
    /// </summary>
    public void BgmStart()
    {
        audioSource.Play();
        audioSource.loop = true;
    }

    /// <summary>
    /// BGM停止メソッド
    /// <para>　流れているBGMを停止する。</para>
    /// </summary>
    public void BgmStop()
    {
        isFadePlaying = true;
    }
}
