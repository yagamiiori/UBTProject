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
// =======================================================================================
public class LobbyManager : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>ゲームオブジェクト"Canvas"</summary>
    private GameObject canVas;
    /// <summary>全ユーザー数表示用テキストコンポ</summary>
    private Text playerAllText;
    /// <summary>全ルーム数表示用テキストコンポ</summary>
    private Text roomAllText;
    /// <summary>ルームボタン - ルザック平原</summary>
    private GameObject[] roomRuzack;

    // ---- プレイヤーCP用フィールド(今は未使用、mySQL立ててから) ---- //
    /// <summary>ユーザー名</summary>
    public string userName = "Guest";
    /// <summary>ランク</summary>
    public string rank = "";
    /// <summary>バトルポイント</summary>
    public int battlePoint = 0;
    /// <summary>戦闘回数</summary>
    public int battleCnt = 0;

    /// <summary>コンストラクタ</summary>
    private LobbyManager() { }

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

    /// <summary>
    /// 総プレイヤー人数取得メソッド
    /// <para>　全ゲーム中のプレイヤー数を取得し、Textコンポに表示する</para>
    /// <para>　Start()メソッドからコールされ、コルーチンとして定期的に更新する。</para>
    /// </summary>
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
