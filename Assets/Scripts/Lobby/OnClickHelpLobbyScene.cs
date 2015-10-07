using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class OnClickHelpLobbyScene : MonoBehaviour
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
    private OnClickHelpLobbyScene() { }

    void Start()
    {
        // メインCanvasを取得
        canVas = GameObject.Find("Canvas");

        // ヘルプメッセージCanvasの親オブジェクト状態クラスを取得
        helpMsgParentState = GameObject.Find("Canvas_MessageWindow").GetComponent<HelpMsgParentGOstate>();

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

        string helpMessage = "ルームを選択するためのロビーです。\n" +
                         "\n" +
                         "入室したいルームをクリックすると予約できます。\n" +
                         "ルームの人数が揃うと自動的にルームに入り、バトルが開始されます。\n" +
                         "ルームはステージによって分かれており、ルームボタンの色はそのルームのステージタイプを表しています。\n" +
                         "ルームボタンの色によるステージの分類は、\n" +
                         "\n" +
                         "赤色ボタン：溶岩系ステージ\n" +
                         "青色ボタン：水系ステージ\n" +
                         "茶色ボタン：建物系ステージ\n" +
                         "緑色ボタン：草原系ステージ\n" +
                         "黒色ボタン：洞窟系ステージ\n" +
                         "\n" +
                         "となっています。\n" +
                         "\n" +
                         "予約したルームを変更したい場合や、ロビーのリロードを行う場合は、2番目の「LobbyReLoad」ボタンをクリックし、ロビーをリロードして下さい。\n" +
                         "また、右上の「UnitForm」ボタンより編成したユニットを一覧で確認できます。\n" +
                         "UnitFormではユニットの一覧を確認するだけでなく、名前やアビリティの編成画面に戻る事も可能です。\n";

        // ヘルプメッセージの親オブジェクトをアクティブ化
        helpMsgParentState.parentGO.SetActive(true);

        // ヘルプメッセージCanvas内のTextコンポを取得
        var textField = helpMsgParentState.parentGO.transform.FindChild("MessageWindowText").GetComponent<Text>();
        Text helpTextField = textField.GetComponent<Text>();
        // ヘルプメッセージCanvas内のTextコンポにヘルプメッセージを設定
        helpTextField.text = helpMessage;
    }
}
