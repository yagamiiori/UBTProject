﻿using UnityEngine;
using System.Collections;

public class OnClickOkForAbilitySelect : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private string nextScene = "Lobby";                 // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE;                  // OKボタンクリックSE

    /// <summary>コンストラクタ</summary>
    private OnClickOkForAbilitySelect() { }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
	}
    
    // -------------------------------
    // OKボタンクリック判定メソッド（ユニットセレクトシーン）
    // ユニットセレクトシーンにてOKボタンが押された場合（ユニット確定した場合）にコールされ
    // 選択したユニットをユニットリストに格納、アビリティシステム有無フラグを確認し
    // アビリティセレクトシーンまたはポジションセレクトシーンに遷移する。
    // -------------------------------
    public void OnClick()
    {
        // スタートボタン未プッシュの場合
        if (0 == isStarted)
        {
            // クリックSEを再生
            audioCompo.PlayOneShot(clickSE);

            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // オプションが変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // ユニット情報をXMLへ書き込み
            var xmlManager = GameObject.Find("XmlManager").GetComponent<XmlManager>();
            xmlManager.UnitStateWriteToXml();

            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
        }
    }
}