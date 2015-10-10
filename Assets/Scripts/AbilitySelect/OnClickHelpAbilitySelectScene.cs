using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class OnClickHelpAbilitySelectScene : MonoBehaviour
{
    /// <summary>メインCanvas</summary>
    private GameObject canVas;
    /// <summary>ヘルプメッセージCanvasの親オブジェクト状態クラス</summary>
    private MessageWindowActiveManager helpMsgParentState;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    [SerializeField]
    private AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickHelpAbilitySelectScene() { }

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
    /// ヘルプメッセージ表示メソッド（ソルジャー）
    /// <para>　ソルジャーのヘルプアイコンがクリックされたら起動し</para>
    /// <para>　メッセージウィンドウにヘルプメッセージを表示する。</para>
    /// </summary>
    // TODO ヘルプメッセージの実装要検討
    public void OnclickHelpMessage()
    {
        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/OnHelpMessage");
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        string helpMessage = "ユニットにアタッチ(付与)するアビリティを選択するシーンです。\n" +
                         "\n" +
                         "1ユニットにつき1つ、アビリティをアタッチする事ができます。\n" +
                         "ユニットのグラフィックを左クリックするとアビリティ一覧が表示されるので、その中からアタッチしたいアビリティを選択して下さい。\n" +
                         "グラフィックを左クリックした後、キャンセルしたい場合は右クリックでキャンセルできます。\n" +
                         "\n" +
                         "アビリティはカテゴリによって分けられており、\n" +
                         "Action：攻撃や行動系のアビリティ\n" +
                         "Support：ユニットに能力を付与したり上昇させるアビリティ\n" +
                         "Reaction：攻撃を受けた時に発動するアビリティ\n" +
                         "Move：ユニットの移動に関係するアビリティ\n" +
                         "\n" +
                         "となります。\n" +
                         "また、必ずしもアビリティをアタッチする必要はなく、この画面を素通りして次の画面へ行く事も可能です。";


        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
