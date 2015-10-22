using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Photonバトルフィールド遷移クラス
/// <para>　PhotonNetWorkにおいてルームボタンクリック後、人数が揃うのを待ち合わせ</para>
/// <para>　人数が揃ったらバトルフィールドシーンへ遷移させる。</para>
/// </summary>
public class WaitingForOtherPlayer : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;

    /// <summary>コンストラクタ</summary>
    private WaitingForOtherPlayer() { }

	void Start ()
    {
        // マネージャコンポを取得
        gameManager = this.gameObject.GetComponent<GameManager>();

        // マスターが行うPhotonNetwork.LoadLevelによる遷移をスレイブにも適用する
        PhotonNetwork.automaticallySyncScene = true;
    }

    void Update()
    {
        if (PhotonNetwork.inRoom)
        {
            // playerCountやmaxPlayersの値を一度フィールドに入れてそのフィールド同士を判定するのは出来ないっぽい
            if (PhotonNetwork.isMasterClient && PhotonNetwork.room.maxPlayers == PhotonNetwork.room.playerCount)
            {
                // ルーム内の現プレイヤー数と最大プレイヤー数が同じなら（人数が揃ったら）バトルフィールドへ遷移する
                // マスタークライアントがLoadLevelし、スレイブはautomaticallySyncSceneでシンクロさせる
                PhotonNetwork.LoadLevel("BattleStage");
            }
        }
	}
}
