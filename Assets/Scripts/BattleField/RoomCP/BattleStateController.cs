using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleStateController : MonoBehaviour
{
    /// <summary>ルームCP</summary>
    private ExitGames.Client.Photon.Hashtable roomCP;

    /// <summary>バトルフィールドの状態</summary>
    enum BattleState
    {
        StartingSetUp,
        BattleNow,
        Congratulations
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BattleStateController() { }

	void Start ()
    {
        // ルームCPを取得
        roomCP = PhotonNetwork.room.customProperties;

        if (BattleState.StartingSetUp != (BattleState)roomCP["BS"])
        {
            // バトルフィールド開始時にStartingSetUpになっていなかったら設定する（フェールセーフ）
            roomCP["BS"] = BattleState.StartingSetUp;
        }
	}
	
	void Update ()
    {
	
	}
}
