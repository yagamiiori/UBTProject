using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;


public class LogWindowManager : Photon.MonoBehaviour
{
    /// <summary>ログリスト</summary>
    private List<string> logList = new List<string>();
    private Text logText;

    /// <summary>コンストラクタ</summary>
    private LogWindowManager() { }

	void Start ()
    {
        // 子オブジェクト内のログ表示Textコンポを取得
        logText = this.gameObject.GetComponentInChildren<Text>();

        // ユニットフォームから戻ってきた時、下記の状態であればメッセージを表示する
        if (PhotonNetwork.connected) LogAddMethod("ネットワーク接続済み。");
        if (PhotonNetwork.inRoom) LogAddMethod("ルーム予約済み。待ち合わせ中...");
    }
	
    /// <summary>
    /// ロビーに入室した場合のコールバックメソッド
    /// </summary>
    void OnJoinedLobby()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("ロビーに入室しました。");
    }
    /// <summary>
    /// ロビーから退室した場合のコールバックメソッド
    /// </summary>
    void OnLeftLobby()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("ロビーから退室しました。");
    }

    /// <summary>
    /// ルームに入室した場合のコールバックメソッド
    /// </summary>
    void OnJoinedRoom()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("ルーム予約完了。待ち合わせ中...");
    }

    /// <summary>
    /// ルームから退室した場合のコールバックメソッド
    /// </summary>
    void OnLeftRoom()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("ルームから切断されました。");
    }

    /// <summary>
    /// ルームの作成に失敗した場合のコールバックメソッド
    /// </summary>
    void OnPhotonCreateRoomFailed()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("ルームの作成に失敗しました。");
    }

    /// <summary>
    /// サーバへの初期接続が確立した場合のコールバックメソッド
    /// </summary>
    void OnConnectedToPhoton()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("サーバ接続完了。");
    }

    /// <summary>
    /// Photonサーバから切断された場合のコールバックメソッド
    /// </summary>
    void OnDisconnectedFromPhoton()
    {
        // ログメッセージ追加メソッドをコール
        LogAddMethod("サーバから切断されました。");
    }

    /// <summary>
    /// ログメッセージ追加メソッド
    /// <para>　ログメッセージをログリストに追加する。</para>
    /// </summary>
    /// <param name="loglist">ログリスト</param>
    /// <param name="logText">ログリストに書き込む文章</param>
    /// <returns>List<string> 追加および削除が完了したログリスト</returns>
    private void LogAddMethod(string text)
    {
        // ログ数が6以上の場合は最初の(最も古い)ログを消去する
        if (6 <= logList.Count) logList.RemoveAt(0);

        // ログリストに書き込み
        logList.Add(text);

        string tes = "";
        // ログウィンドウに全ログを書き出す
        foreach (string writeText in logList)
        {
            tes = tes + writeText + "\n";
//            writeText = writeText + "\n" + writeText;
            logText.text = tes;// writeText;
        }
    }
}
