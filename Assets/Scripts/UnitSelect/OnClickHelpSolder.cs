using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class OnClickHelpSolder : MonoBehaviour {

    /// <summary>メインCanvas</summary>
    private GameObject canVas;
    /// <summary>ヘルプメッセージCanvasの親オブジェクト状態クラス</summary>
    private HelpMsgParentGOstate helpMsgParentState;

    /// <summary>コンストラクタ</summary>
    private OnClickHelpSolder() { }
   
    void Start()
    {
        // メインCanvasを取得
        canVas = GameObject.Find("Canvas");

        // ヘルプメッセージCanvasの親オブジェクト状態クラスを取得
        helpMsgParentState = GameObject.Find("Canvas_MessageWindow").GetComponent<HelpMsgParentGOstate>();
	}

    /// <summary>
    /// ヘルプメッセージ表示メソッド（ソルジャー）
    /// <para>　ソルジャーのヘルプアイコンがクリックされたら起動し</para>
    /// <para>　メッセージウィンドウにヘルプメッセージを表示する。</para>
    /// </summary>
    // TODO ヘルプメッセージの実装要検討
    public void OnclickHelpMessage()
    {
        string helpMessage = "クラス名　　　：ソルジャー\n" +
                         "武器　　　　　：片手剣\n" +
                         "クラスタイプ　：近接物理攻撃型\n" +
                         "エレメント　　：4属性選択型\n" +
                         "移動範囲　　　：5パネル\n\n" +

                         "剣を武器に戦うクラス。\n" +
                         "近接戦闘の要となるクラスで、基本的にバランスに優れたパラメータを持つが、魔法防御力は低め。\n" +
                         "移動やWTに癖がなく、初心者でも扱いやすいのが特徴。\n\n\n\n" +

                         "基礎パラメータ\n" +
                         " HP        500\n" +
                         " MP        200\n" +
                         " STR        50 + ランダム1～5\n" +
                         " VIT　　  45 + ランダム1～6\n" +
                         " DEX        34 + ランダム0～5\n" +
                         " AGI          41 + ランダム0～3\n" +
                         " INT          29 + ランダム0～3\n" +
                         " MND       29 + ランダム0～4\n" +
                         " RES        37 + ランダム1～5\n" +
                         " LUC        33 + ランダム1～5\n" +
                         " WT          62";


        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
