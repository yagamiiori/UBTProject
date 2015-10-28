using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// BGM再生クラス（Login～Lobbyシーン）
/// <para>　BGMの再生やボリューム調整を行う。</para>
/// </summary>
public class BgmPlayerForAllScene : MonoBehaviour
{
    /// <summary>BGMボリュームスライダーコンポ（スライダーにアタッチされたBgmVolumeChangeOnSliderから設定される）</summary>
    public Slider VolumeSlider;
    /// <summary>BGMボリュームスライダーの音量（各シーンのスライダーオブジェクトから操作される）</summary>
    private float volumeSliderValue = 0.1f;
    public float VolumeSliderValue
    {
        get { return volumeSliderValue; }
        set {
                if (0 > value) value = 0;
                if (1 < value) value = 1.0f;
                volumeSliderValue = value;
            }
    }
    /// <summary>オーディオソースコンポ（BgmVolumeChangeOnSlider.csより参照されるためpublic）</summary>
    public AudioSource audioSource;
    /// <summary>BGM</summary>
    public AudioClip bgmClip;
    /// <summary>BGMの基本ボリューム</summary>
    [SerializeField]
    private float BaseVolume;
    /// <summary>フェード処理中か否か</summary>
    private bool isFadePlaying = false;
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
        if (null == bgmClip) bgmClip = Resources.Load<AudioClip>("Sounds/BGM/AllScenes/AllScenesBGM1");

        // BGM決定し、再生する
        audioSource.clip = bgmClip;
        audioSource.Play();
        audioSource.loop = true;
    }

    void Update()
    {
        // スライダーの値をボリュームに設定
        if (!isFadePlaying && audioSource && VolumeSlider) audioSource.volume = VolumeSlider.value;

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
    /// BGMボリューム変更メソッド
    /// <para>　BGMのボリューム値を変更する。</para>
    /// </summary>
    public void BgmVolumeChanger()
    {
        // 処理なし
    }

    /// <summary>
    /// BGMファイル設定メソッド
    /// <para>　BGMファイルを設定する。</para>
    /// </summary>
    public void BgmSet(AudioClip clip)
    {
        this.bgmClip = clip;
        audioSource.clip = bgmClip;
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
    /// BGMフェードアウト停止メソッド
    /// <para>　流れているBGMをフェードアウトさせながら停止する。</para>
    /// </summary>
    /// <param name="fadeoutSec">フェードアウトにかける時間</param>
    public void BgmStopFadeOut(double fadeoutSec)
    {
        this.FadeOutSeconds = fadeoutSec;
        isFadePlaying = true;
    }

    /// <summary>
    /// BGM停止メソッド
    /// <para>　流れているBGMをフェードアウトさせず停止する。</para>
    /// </summary>
    /// <param name="fadeoutSec">フェードアウトにかける時間</param>
    public void BgmStopNow()
    {
        audioSource.Stop();
    }
}
