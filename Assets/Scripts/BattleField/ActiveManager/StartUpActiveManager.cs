using UnityEngine;
using System.Collections;

/// <summary>
/// 初期配置Parentオブジェクトアクティブ状態管理クラス
/// <para>　初期配置パート関係のゲームオブジェクトのアクティブ状態を管理する。</para>
/// </summary>
public class StartUpActiveManager : MonoBehaviour
{
    /// <summary>ルームCP</summary>
    private ExitGames.Client.Photon.Hashtable roomCP;
    /// <summary>自身(初期配置時のタイマーパネル)のアクティブ状態</summary>
    private GameObject unitPlaceBeforeBattleParentGO;

    void Start()
    {
        // 初期配置ゲームオブジェクトの親オブジェクトを取得
        unitPlaceBeforeBattleParentGO = this.transform.FindChild("Parent").gameObject;

        // ルームCP取得
        roomCP = PhotonNetwork.room.customProperties;
        if (null == roomCP) Debug.Log("ルームCPを取得できません＠StartUpActiveManager.cs"); return;
    }
}
