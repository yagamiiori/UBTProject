using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class OnClickHelpUnitSelectScene : MonoBehaviour
{
    /// <summary>メインCanvas</summary>
    private GameObject canVas;
    /// <summary>ヘルプメッセージCanvasの親オブジェクト状態クラス</summary>
    private HelpMsgParentGOstate helpMsgParentState;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    [SerializeField]
    private AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickHelpUnitSelectScene() { }

    void Start()
    {
        // メインCanvasを取得
        canVas = GameObject.Find("Canvas");

        // ヘルプメッセージCanvasの親オブジェクト状態クラスを取得
        helpMsgParentState = GameObject.Find("Canvas_MessageWindow").GetComponent<HelpMsgParentGOstate>();

        // オーディオコンポを取得
        audioCompo = this.gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = this.gameObject.AddComponent<AudioSource>();
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

        string helpMessage = "ユニット（クラス）とその人数を選択するシーンです。\n" +
                         "\n" +
                         "選択方法：ユニットのグラフィックを右クリックすると、そのクラスをユニットとして加える事ができます。\n" +
                         "また、右クリックで加えたユニットを減らす事ができます。\n" +
                         "\n" +
                         "ユニットの追加には「コスト」を必要とし、コストがなければユニットを追加する事はできません。\n" +
                         "コストは右下に表示されており、最大コストは16となります。それが0になるまでユニットの登録を行って下さい。\n" +
                         "ユニットはレシオ制で管理されており、消費するコストはそのユニットのレシオによって異なります。\n" +
                         "\n" +
                         "レシオ1：1ユニット追加につき1コスト消費\n" +
                         "レシオ2：1ユニット追加につき2コスト消費\n" +
                         "レシオ3：1ユニット追加につき3コスト消費\n" +
                         "レシオ4：1ユニット追加につき4コスト消費\n" +
                         "\n" +
                         "となります。\n" +
                         "基本的にレシオが高くなるほど強いクラスになりますが、コストを多く消費するため高レシオのユニットは少数しか追加できません。";


        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
