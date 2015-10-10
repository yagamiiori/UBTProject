using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class OnClickOkForNameSelect : MonoBehaviour
{
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE;                           // OKボタンクリックSE
    private GameManager gameManager;                    // マネージャコンポ
    private UnitNameSetForSceneLoading nameSelect;      // NameSelectコンポ
    private string nextScene = "AbilitySelect";         // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ

    /// <summary>コンストラクタ</summary>
    private OnClickOkForNameSelect() { }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // NameSelectコンポ取得
        nameSelect = GameObject.FindWithTag("Canvas").GetComponent<UnitNameSetForSceneLoading>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
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
                if ("UnitName" == nameSelect.UnitNameList[i].text ||
                    "" == nameSelect.UnitNameList[i].text)
                {
                    // 名前が初期値のInputNameもしくは未入力の場合はNo＋固有番号を振る
                    string reNameString = "No." + (i + 1).ToString(); ;
                    gameManager.unitStateList[i].unitName = reNameString;
                }
                else 
                {
                    // 名前が設定されている場合は名前をユニットステートリストに格納
                    gameManager.unitStateList[i].unitName = nameSelect.UnitNameList[i].text;
                }
            }
            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
        }
    }
}
