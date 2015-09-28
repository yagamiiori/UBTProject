using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// =======================================================================================
// ロビーシーンマネージャー
//
// ロビーシーンで起動され、ロビーに入室する
// ルームへの入室はバトルフィールドシーンで行う。
//
// 入室ボタンは取得後、即非アクティブ化しロビー入室確定後に
// アクティブ化を行う（ロビー入室前にボタンを押される事を抑止する）。
//
// ルームCP設定契機：バトルフィールドシーンにてCreateRoomの直前
// プレイヤーCP設定契機：ロビーシーン起動直後のStartメソッド内
//
// 【ロビーおよびルーム入室フロー (今んとこ) 】
// Lobbyシーン起動直後にロビー入室
// ↓
// 入室ボタン押すとLoadLevelでバトルフィールドシーンへ遷移
// ↓
// バトルフィールドシーン起動直後にCreateRoom+JoinRoomで入室
//
// =======================================================================================
public class LobbyManager : MonoBehaviour
{
    /// <summary>クリックしたボタンのルーム情報</summary>
    private GameManager gameManager;         // マネージャコンポ
    private GameObject canVas;               // ゲームオブジェクト"Canvas"
    private Text playerAllText;              // 全ユーザー数表示用テキストコンポ
    private Text roomAllText;                // 全ルーム数表示用テキストコンポ
    private GameObject[] roomRuzack;         // 部屋ボタン - ルザック平原

    // ---- プレイヤーCP用フィールド ----
    public string name = "Guest";            // ユーザー名
    public string rank = "";                 // ランク
    public int battlePoint = 0;              // バトルポイント
    public int battleCnt = 0;                // 戦闘回数

    void Awake()
    {
        if (!PhotonNetwork.connected)
        {
            // Photonにまだ接続していなければ、マスターサーバーへ接続
            PhotonNetwork.ConnectUsingSettings("v0.1");
        }
    }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.Find("Canvas");

        // 全ルームボタンオブジェクトを取得し非アクティブ化
        roomRuzack = GameObject.FindGameObjectsWithTag("RoomButtons");
        foreach (GameObject go in roomRuzack)
        {
            go.SetActive(false);
        }
        // 全ユーザ数表示Textコンポを取得
        playerAllText = GameObject.Find("Text_ALLPlayerNum").GetComponent<Text>();

        // 全ルーム数表示Textコンポを取得
        roomAllText = GameObject.Find("Text_ALLRoomsNum").GetComponent<Text>();

        // 総プレイヤー人数取得メソッドをコール
        StartCoroutine(GetPlayerAll());

        if (PhotonNetwork.insideLobby || PhotonNetwork.connected)
        {
            // ロビーにすでに入室している場合は、部屋ボタンをアクティブ化する
            foreach (GameObject go in roomRuzack)
            {
                go.SetActive(true);
            }
        }
	}

    /// <summary>
    /// ロビーに入室した場合のコールバックメソッド
    /// </summary>
    void OnJoinedLobby()
    {
        // ロビーにすでに入室している場合は、部屋ボタンをアクティブ化する
        foreach (GameObject go in roomRuzack)
        {
            go.SetActive(true);
        }
    }

    // -------------------------------------------------------------
    // 総プレイヤー人数取得メソッド
    // 全ゲーム中のプレイヤー数を取得し、Textコンポに表示する
    // Start()メソッドからコールされ、コルーチンとして定期的に更新する
    // -------------------------------------------------------------
    private IEnumerator GetPlayerAll()
    {
        while (true)
        {
            // プレイヤー数を取得
            playerAllText.text = PhotonNetwork.countOfPlayers.ToString();

            // ルーム数を取得
            roomAllText.text = PhotonNetwork.countOfRooms.ToString();

            // 一時停止
            yield return new WaitForSeconds(20.0f);
        }
    }
}
