﻿using UnityEngine;
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
    private MessageWindowActiveManager helpMsgParentState;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    [SerializeField]
    private AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickHelpWizard() { }

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
    public void OnclickHelpMessage()
    {
        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/OnHelpMessage");
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        string helpMessage = "クラス名　　　：ウィザード\n" +
                         "装備　　　　　：ルビーワンド\n" +
                         "クラスタイプ　：遠距離攻撃魔法型\n" +
                         "エレメント　　：4属性より選択\n" +
                         "クラス固有能力：なし\n" +
                         "移動範囲　　　：6パネル\n\n" +

                         "様々な攻撃魔法を操る、ローブ姿の魔術師。\n" +
                         "剣や槍など、物理武器が届かない遠距離からの魔法攻撃が得意。\n" +
                         "反面、物理攻撃には弱いため、ソルジャーなどの近接物理攻撃型ユニットを近寄らせず戦うのが基本方針となる。\n" +
                         "パラメータは魔法系が高く、物理系が攻守共に低い。\n\n" +

                         "基礎パラメータ\n" +
                         " HP        500\n" +
                         " MP        200\n" +
                         " SP        100\n" +
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
