using UnityEngine;
using System.Collections;

public class LobbyButtonOK : Photon.MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private string nextScene = "UnitForm";              // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE_OKbutton;                  // OKボタンクリックSE

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポ取得とOKボタンクリック時SEの設定
        audioCompo = this.gameObject.GetComponent<AudioSource>();
        clickSE_OKbutton = (AudioClip)Resources.Load("Sounds/SE/OKButtonSE");
    }

    // -------------------------------
    // OKボタンクリック判定メソッド（ロビーシーン）
    // ロビーシーンにてユニット編成ボタンが押された場合にコールされ
    // ユニット編成シーンに遷移する。
    // -------------------------------
    public void OnClick()
    {
        // スタートボタン未プッシュの場合
        if (0 == isStarted)
        {
            // クリックSEを設定および再生
            audioCompo.clip = clickSE_OKbutton;
            audioCompo.Play();

            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // オプションが変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.2f, 0.1f, Color.black, nextScene);
        }
    }
}
