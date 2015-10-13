using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 入室判定クラス
/// <para>　Lobbyシーンにおいて入室成功した場合のコールバック</para>
/// <para>　OnJoinedRoom()を受け持つ。</para>
/// </summary>
public class OnJoinedRoomJudge : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;

    /// <summary>コンストラクタ</summary>
    private OnJoinedRoomJudge(){}

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

    void OnJoinedRoom()
    {
        // 入室したタイミングでプレイヤーCPを作成
        var p = new ExitGames.Client.Photon.Hashtable(){
                                                          { "GS", EnumConsts.GameState.Room }, // ゲームステート
                                                          { "UserName", gameManager.userName } // ユーザー名
                                                       };
        PhotonNetwork.player.SetCustomProperties(p);

        // ルーム情報を取得
        gameManager.r = PhotonNetwork.room;
        /*
                        if ((string)gameManager.r.customProperties["BS"] != "idle")
                        {
                            // ゲームプレイ中に入った場合、一時的にイベントをシャットアウトする
                            // Roomに入った瞬間インスタンス情報が流れてきてしまうため
                            PhotonNetwork.isMessageQueueRunning = false;
                            Application.LoadLevel(1);
                        }
        */
    }

}
