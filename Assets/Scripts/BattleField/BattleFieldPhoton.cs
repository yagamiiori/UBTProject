using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;    //CP専用Hashtable

// =======================================================================================
// PhotonSystemマネージャー（バトルフィールドシーン）
//
// 起動直後にルーム入室する
//
//　ルームCP設定契機：バトルフィールドシーンにてCreateRoomの直前
//　プレイヤーCP設定契機：ロビーシーン起動直後のStartメソッド内
//
// =======================================================================================
public class BattleFieldPhoton : Photon.MonoBehaviour
{
    private GameManager gameManager;         // マネージャコンポ
    private GameObject canVas;               // ゲームオブジェクト"Canvas"
    public Hashtable customRoomPropeties;    // ルームCP
    public string roomNo = "";               // ルーム番号
    public int counter = 0;                  // ルーム番号用カウンタ

    public string name = "Guest";            // ユーザー名
    public string rank = "";                 // ランク
    public int rip = 0;                      // RIP
    public int battleCnt = 0;                // 戦闘回数

    void Awake()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");
    }

    // -------------------------------------------------------------
    // Startメソッド
    // とりあえず接続人数を表示する実装だけ
    // -------------------------------------------------------------
    void Start()
    {
        // ルーム番号を初期化
        roomNo = "RoomNo_0";

        // ルームCP要素を定義
        customRoomPropeties = new Hashtable() {
                                                { "RoomNo", roomNo },
                                                { "Blank", 0 }
                                              };
/*
        // プレイヤーCP要素を定義（ロビーシーンに移行した）
        gameManager.customPropeties = new Hashtable()
                                        {
                                            { "UserName", name },
                                            { "RIP", rip },
                                            { "BattleCnt", battleCnt },
                                            { "Rank", rank }
                                        };
*/
        // ★ロビー入室を前シーンでやる事にしたからここに移動させた
        // ルーム作成メソッドをコール
        JoinRoom(customRoomPropeties);
    }

    // -------------------------------------------------------------
    // マスターサーバーのロビーに入った場合にコールされる
    // ロビーに入ったらとりあえず部屋を生成する
    // -------------------------------------------------------------
    void OnJoinedLobby()
    {
        Debug.Log("ロビーに入室");

        // ルーム入室メソッドをコール
        JoinRoom(customRoomPropeties);
    }

    // -------------------------------------------------------------------
    // CreateRoom失敗メソッド
    // 同名のルームが既に存在するなどして、CreateRoomできなかった場合にコールされる
    // -------------------------------------------------------------------
    void OnPhotonCreateRoomFailed()
    {
        Debug.Log("CreateRoomに失敗");

/*
        // 部屋番号をインクリメント
        counter++;
        roomNo = "RoomNo_" + counter.ToString();
*/
    }

    // -------------------------------------------------------------------
    // 部屋に入るとき呼ばれる
    // 入室時だけでなく作成時にもコールされる
    // ※本メソッドに入る事で自分がルームインしたか否かの情報である
    // 　PhotonNetwork.inRoom(bool)がtrueになる
    // -------------------------------------------------------------------
    void OnJoinedRoom()
    {
        Debug.Log("ルームに入室（または生成）");

        PhotonNetwork.Instantiate("Test", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }

    // -------------------------------------------------------------------
    // JoinRoom失敗メソッド
    // JoinRoom()の呼び出しが失敗した場合にコールされルームの生成を行う。
    // -------------------------------------------------------------------
    void OnPhotonJoinRoomFailed()
    {
        Debug.Log("ルーム入室失敗");

        // ルーム作成メソッドをコール
        CreateRoom(customRoomPropeties);
    }

    // -------------------------------------------------------------------
    // 入室ボタンがクリックした時に入室ボタンのOnClickからコールされる
    // 部屋を作成する。
    // -------------------------------------------------------------------
    public void RoomIn()
    {
        Application.LoadLevel("BattleStage");
    }

    // -------------------------------------------------------------------
    // ルーム情報更新メソッド
    // ルームListが更新された場合にコールされる。
    // ※ここより前にGetRoomList()を呼ぶとRoomInfo[]は要素数が0となり
    // 　Roomリストが取得できません。
    // -------------------------------------------------------------------
    void OnReceivedRoomListUpdate()
    {
        RoomInfo[] roomInfo = PhotonNetwork.GetRoomList();

        // 個々のRoomの名前を表示
        for (int i = 0; i < roomInfo.Length; i++)
        {
            Debug.Log((i).ToString() + " : " + roomInfo[i].name);
        }
        
        // ルームリストを検索
        foreach (RoomInfo roomInfo2 in PhotonNetwork.GetRoomList())
        {
            Hashtable cp = roomInfo2.customProperties;   // CP読み出し

            // 指定したルーム番号が存在し、マッチする場合
            if (roomInfo2.name == (string)customRoomPropeties["RoomNo"])
            {
                // 自分のランクが指定ルームのランクとマッチする場合
                if ((string)customRoomPropeties["Rank"] == (string)cp["Rank"])
                {
                    // 入室する
                    PhotonNetwork.JoinRoom((string)customRoomPropeties["RoomNo"]);
                }
                return;
            }
        }
    }

    // -------------------------------------------------------------------
    // ルーム生成メソッド
    // 部屋を作成する。
    // -------------------------------------------------------------------
    public void CreateRoom(Hashtable customRoomPropeties)
    {
        string text = "ルームを生成中です...";              // ルーム生成メッセージ（

        // ルームオプションおよびルームCP（カスタムプロパティ）を作成
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.isVisible = true;                       // ロビーから部屋が見えるか
        roomOptions.isOpen = true;                          // 誰でも入室できるか
        roomOptions.maxPlayers = 2;                         // 入室できる最大プレイヤー数
        roomOptions.customRoomProperties = customRoomPropeties; // CP
        roomOptions.customRoomPropertiesForLobby = new string[] { "Rank" }; // CP(ロビー用)

        // ルームを作成
        PhotonNetwork.CreateRoom((string)customRoomPropeties["RoomNo"], roomOptions, null);
    }

    // -------------------------------------------------------------------
    // ルーム入室メソッド
    // 部屋に入室する。
    // 初回は必ず失敗し、その後OnPhotonJoinRoomFailedに入り
    // 上記メソッド内でCreateRoom()がコールされ、ルーム生成を行う。
    // -------------------------------------------------------------------
    public void JoinRoom(Hashtable customRoomPropeties)
    {
        // とりあえず入室する
        PhotonNetwork.JoinRoom((string)customRoomPropeties["RoomNo"]);

    }

}