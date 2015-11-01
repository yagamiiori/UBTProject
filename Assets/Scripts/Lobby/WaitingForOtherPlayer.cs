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
    private bool isLoadLevel = false;

    /// <summary>コンストラクタ</summary>
    private WaitingForOtherPlayer() { }

	void Start ()
    {
        // マスターが行うPhotonNetwork.LoadLevelによるLevel遷移を同室内の全スレイブにも適用する
        PhotonNetwork.automaticallySyncScene = true;

        // マネージャコンポを取得
        gameManager = this.gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (!isLoadLevel && PhotonNetwork.inRoom)
        {
            // playerCountやmaxPlayersの値を一度フィールドに入れてそのフィールド同士を判定するのは出来ないっぽい
            if (PhotonNetwork.isMasterClient && PhotonNetwork.room.maxPlayers == PhotonNetwork.room.playerCount)
            {

                // ルーム内の現プレイヤー数と最大プレイヤー数が同じなら（人数が揃ったら）バトルフィールドへ遷移する
                // マスタークライアントがLoadLevelし、スレイブはautomaticallySyncSceneでシンクロさせる
                // 通常のLoadLevelとは違い、シーン遷移中はキューを停止するLoadLevelである
                // よってシーン遷移中はRPC等のやり取りはできない。
                // Lobbyで投げたRPGが、シーン変更後(BattleField)に到着したら破棄される。
                // これは逆に、RPCでシーン間の区切りを定義できるということです。
                PhotonNetwork.LoadLevel("BattleStage");

                // ★★★これで抑止しないと永久ループでPhotonNetwork.LoadLvelを呼び続ける★★★
                // TODO 100時間くらいハマった
                isLoadLevel = true;

                // 全Photonオブジェクト消去
                PhotonNetwork.DestroyAll();
            }
        }
	}
}
