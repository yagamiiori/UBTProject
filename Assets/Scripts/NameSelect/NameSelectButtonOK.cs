using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class NameSelectButtonOK : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private NameSelect nameSelect;                      // NameSelectコンポ
    private string nextScene = "AbilitySelect";         // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE;                           // OKボタンクリックSE

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // NameSelectコンポ取得
        nameSelect = GameObject.FindWithTag("Canvas").GetComponent<NameSelect>();

        // オーディオコンポ取得とOKボタンクリック時SEの設定
        audioCompo = this.gameObject.GetComponent<AudioSource>();
        clickSE = (AudioClip)Resources.Load("Sounds/SE/OKButtonSE");
	}

    // -------------------------------
    // OKボタンクリック判定メソッド
    // ユニットセレクトシーンにてOKボタンが押された場合（ユニット名が確定した場合）
    // にコールされ、選択したユニット名をユニットステートに格納した後、シーン遷移する。
    // -------------------------------
    public void OnClick()
    {
        // スタートボタン未プッシュの場合
        if (0 == isStarted)
        {
            // クリックSEを設定および再生
            audioCompo.PlayOneShot(clickSE);

            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // 内容が変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // ユニットステートリスト内を最大ユニット数分ループ
            for (int i = 0; i < gameManager.unitStateList.Count; i++)
            {
                if ("InputName" == nameSelect.UnitNameList[i].text ||
                    "" == nameSelect.UnitNameList[i].text)
                {
                    // 名前が初期値のInputNameもしくは未入力の場合はNameLessとする
                    string reNameString = "NameLess";
                    nameSelect.UnitNameList[i].text = reNameString;
                }

                // 設定したユニット名をユニットステートリストに格納
                gameManager.unitStateList[i].unitName = nameSelect.UnitNameList[i].text;
            }
            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
        }
    }
}
