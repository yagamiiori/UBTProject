using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class OnClickHelpWizard : MonoBehaviour
{

    /// <summary>メインCanvas</summary>
    private GameObject canVas;
    /// <summary>ヘルプメッセージCanvasの親オブジェクト状態クラス</summary>
    private HelpMsgParentGOstate helpMsgParentState;

    /// <summary>コンストラクタ</summary>
    private OnClickHelpWizard() { }

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
    public void OnclickHelpMessage()
    {
        string helpMessage = "クラス名　　　：ウィザード\n" +
                         "武器　　　　　：杖\n" +
                         "クラスタイプ　：遠距離攻撃魔法型\n" +
                         "エレメント　　：4属性選択型\n" +
                         "移動範囲　　　：6パネル\n\n" +

                         "遠距離からの魔法攻撃を得意とするクラス。\n" +
                         "剣や槍などの物理武器の攻撃範囲外から、魔法で攻撃できる。\n" +
                         "反面、物理攻撃には弱いため近接戦闘は極力避けるのが基本方針となる。\n" +
                         "パラメータは魔法系が高く、物理系が低く設定されている。\n\n\n\n" +

                         "基礎パラメータ\n" +
                         " STR        50 + ランダム1～5\n" +
                         " VIT　　  45 + ランダム1～6\n" +
                         " DEX        34 + ランダム0～5\n" +
                         " AGI          41 + ランダム0～3\n" +
                         " INT          29 + ランダム0～3\n" +
                         " MND       29 + ランダム0～4\n" +
                         " RES        37 + ランダム1～5\n" +
                         " LUC        33 + ランダム1～5\n" +
                         " WT          68";

        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
