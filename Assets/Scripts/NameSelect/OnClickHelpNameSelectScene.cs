using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class OnClickHelpNameSelectScene : MonoBehaviour
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
    private OnClickHelpNameSelectScene() { }

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

        string helpMessage = "ユニットの名前とエレメント(属性)を選択するシーンです。\n" +
                         "\n" +
                         "Name欄のInputNameをクリックし、キーボードでユニットの名前を入力して下さい。\n" +
                         "未記入の場合、ユニットの名前は「NameLess」になります。\n" +
                         "\n" +
                         "エレメント(属性)は、各属性の攻撃魔法を使う場合や、それらによる攻撃を受ける場合に関係する要素です。\n" +
                         "例えば、エレメントが炎のユニットが炎属性の魔法を使うと、炎属性以外のユニットが魔法を行使した場合よりダメージアップが見込めます。\n" +
                         "このエレメントは、コンボボックスのリストから選択できます。\n" +
                         "デフォルトでは炎属性が選択されています。\n" +
                         "\n" +
                         "また、Class欄にはユニット選択シーンにおいて選択したクラス名が表示されていますが、クラス名をクリックするとコンボボックスが開き、クラスを変更する事ができます。\n" +
                         "クラスの変更を行いたい場合は、このコンボボックスを使用して下さい。\n";

        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
