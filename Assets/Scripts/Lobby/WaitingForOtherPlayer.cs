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
    }
	
	void Update ()
    {
        if (PhotonNetwork.inRoom && gameManager.r.playerCount == 2)
        {
            // ルームに入っていて、人数が揃ったらバトルフィールドへ遷移する
            Application.LoadLevel("BattleStage");
        }
	}
}
