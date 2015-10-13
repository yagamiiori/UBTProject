using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// ルザック平原 - A(1分10秒部屋)
/// </summary>
public class OnClickRuzack : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnClickRuzack(){}

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
            // ルーム名をつける。最後の整数は既に存在していたらカウントアップする
            string clickRoomName = "Ruzack_A_0";
            RoomInfo[] roomInfo = PhotonNetwork.GetRoomList();
            for (int i = 0; 100 > i; i++)
            {
                // ルームが存在しなければ回す意味がないので即抜ける
                if (0 == roomInfo.Length) break;
                // 同名ルームはあるが対戦相手待ちの場合も抜ける
                if (i <= roomInfo.Length && roomInfo[i].name.Equals(clickRoomName) && 1 == roomInfo[i].playerCount) break;

                for (int j = 0; roomInfo.Length > j; j++)
                {
                    if (roomInfo[j].name.Equals(clickRoomName) && 2 == roomInfo[i].playerCount)
                    {
                        // 同名ルームが既に存在し、かつ満員であればルーム名をカウントアップ(100回まで試行する)
                        clickRoomName = "Ruzack_A_" + (i + 1).ToString();
                        j = 0; // カウンタを初期化して最初の配列から探す
                    }
                }
            }

            // ルームプロパティを作成
            RoomOptions ro = new RoomOptions();
            ro.maxPlayers = 2;                      // 最大人数
            ro.isOpen = true;                       // 誰でも参加可能か
            ro.isVisible = true;                    // ロビーからこのルームが見えるか
            string[] s = { "BS" };                  // BattleState（ロビー表示用）
            ro.customRoomPropertiesForLobby = s;    // ロビー用ルームCP
            ro.customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "BS", "idle" }, // バトルステート
                                                                                { "BC1", 60},      // バトルクロック(持ち時間)
                                                                                { "BC2", 10}       // バトルクロック(リカバー)
                                                                              };

            // ルームに入室する、存在しなければ作成する
            PhotonNetwork.JoinOrCreateRoom(clickRoomName, ro, TypedLobby.Default);
        } // まだルームに入室していない場合
    }
}
