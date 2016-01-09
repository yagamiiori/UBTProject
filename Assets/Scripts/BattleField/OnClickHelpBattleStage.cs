using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class OnClickHelpBattleStage : MonoBehaviour
{
    /// <summary>
    /// メインCanvas
    /// </summary>
    private GameObject canVas;
    /// <summary>
    /// ヘルプメッセージCanvasの親オブジェクト状態クラス
    /// </summary>
    private MessageWindowActiveManager helpMsgParentState;
    /// <summary>
    /// オーディオコンポ
    /// </summary>
    private AudioSource audioCompo;
    /// <summary>
    /// クリックSE
    /// </summary>
    [SerializeField]
    private AudioClip clickSE;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnClickHelpBattleStage() { }

    void Start()
    {
        // メインCanvasを取得
        canVas = GameObject.Find("Canvas");

        // ヘルプメッセージCanvasの親オブジェクト状態クラスを取得
        helpMsgParentState = GameObject.Find("Canvas_MessageWindow").GetComponent<MessageWindowActiveManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// ヘルプメッセージ表示メソッド
    /// <para>　メッセージウィンドウにヘルプメッセージを表示する。</para>
    /// </summary>
    public void OnclickHelpMessage()
    {
        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/OnHelpMessage");
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        string helpMessage = "マウスアクション\n" +
                         "--------------------------------\n" +
                         "左ダブルクリック：WT0のユニットにフォーカスします。\n" +
                         "右ダブルクリック：カメラを広角ビューに切り替えます。\n" +
                         "ホイール：画面を上下にスクロールします。\n" +
                         "右ボタン押しっぱなし＋ホイール：画面を左右にスクロールします。\n";

        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
