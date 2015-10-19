using UnityEngine;
using System.Collections;

/// <summary>
/// 初期配置Parentオブジェクトアクティブ状態管理クラス
/// <para>　初期配置パート関係のゲームオブジェクトのアクティブ状態を管理する。</para>
/// <para>　アクティブ状態の変更は本スクリプト内でのみ行われ、BattleStateが</para>
/// <para>　「BattleNow」に更新された場合において、不要となった初期配置関連の</para>
/// <para>　Parentオブジェクトの非アクティブ化を行う。</para>
/// <para>　他のActiveManagerと違い、本スクリプト外から更新される事はない。</para>
/// </summary>
public class StartUpActiveManager : MonoBehaviour
{
    /// <summary>ルームCP</summary>
    private ExitGames.Client.Photon.Hashtable roomCP;
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    private GameObject unitPlaceBeforeBattleParentGO;

    void Start()
    {
        // 初期配置ゲームオブジェクトの親オブジェクトを取得
        unitPlaceBeforeBattleParentGO = this.transform.FindChild("Parent").gameObject;

        // ルームCP取得
        roomCP = PhotonNetwork.room.customProperties;
        if (null == roomCP) Debug.Log("ルームCPを取得できません＠StartUpActiveManager.cs"); return;
    }

	void Update ()
    {
        if (Enums.BattleState.BattleNow == (Enums.BattleState)roomCP["BS"])
        {
            // BattleStateが「バトル中」の場合（初期配置が終了した場合）タイマーCanvasを非アクティブ化する
            unitPlaceBeforeBattleParentGO.SetActive(false);
            // バトルが始まると二度と初期配置パートに戻る事はないので本スクリプトは非アクティブ化する
            this.gameObject.SetActive(false);
        }
	}
}
