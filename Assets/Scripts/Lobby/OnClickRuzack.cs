using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClickRuzack : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    private Image image;
    private Text text;
    private Color grayOutColor = new Color(90, 90, 90, 1);

	void Start ()
    {
        // マネージャコンポを取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 入室ボタンのImageとTextコンポを取得
        image = this.gameObject.GetComponent<Image>();
        text = this.gameObject.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (PhotonNetwork.inRoom)
        {
            // 既に入室している場合は全てのルームボタンをグレイアウト
            image.color = grayOutColor;
            text.color = grayOutColor;
        }
    }

    /// <summary>
    /// ルームボタンをクリックした時にOnClickからコールされる。
    /// <para>　人数が揃ったか確認し、揃っていたらバトルフィールドへ飛ばす。</para>
    /// <para>　揃っていなければ揃うまでロビーにて待ち合わせる。</para>
    /// </summary>
    public void OnClickRoomInButton()
    {
        // まだルームに入室していない場合
        if (!PhotonNetwork.inRoom)
        {
            // ルーム名
            string roomName = "Ruzack";

            // ルームプロパティを作成
            RoomOptions ro = new RoomOptions();
            ro.maxPlayers = 2;                      // 最大人数
            ro.isOpen = true;                       // 誰でも参加可能か
            ro.isVisible = true;                    // ロビーからこのルームが見えるか
            string[] s = { "BS" };                  // BattleState
            ro.customRoomPropertiesForLobby = s;    // ロビーで表示される値
            ro.customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "BS", "idle" } };

            // ルームに入室する、存在しなければ作成する
            PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
        }
    }

    void OnJoinedRoom()
    {
        // 入室したタイミングでプレイヤーCPを作成
        var p = new ExitGames.Client.Photon.Hashtable(){
                                                          { "GS", EnumConsts.GameState.Room },
                                                          { "UserName", gameManager.userName }
                                                       };
        PhotonNetwork.player.SetCustomProperties(p);

        // ルーム情報を取得
        gameManager.r = PhotonNetwork.room;

        if ((string)gameManager.r.customProperties["BS"] != "idle")
        {
            // ゲームプレイ中に入った場合、一時的にイベントをシャットアウトする
            // Roomに入った瞬間インスタンス情報が流れてきてしまうため
            PhotonNetwork.isMessageQueueRunning = false;

            Application.LoadLevel(1);
        }
    }
}
