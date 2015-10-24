using UnityEngine;
using System.Collections;

/// <summary>
/// ルームCP管理クラス
/// <para>　ルームのCP(カスタムプロパティ)の管理および更新を行う。</para>
/// </summary>
public class RoomCPManager : MonoBehaviour 
{
    /// <summary>ルームCP</summary>
    public ExitGames.Client.Photon.Hashtable roomCP;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private RoomCPManager() { }

	void Start ()
    {
        // ルームCP取得
        roomCP = PhotonNetwork.room.customProperties;
	}

    /// <summary>
    /// ルームCP内BattleState要素変更メソッド
    /// <para>　引数に設定された内容でBattleStateの値を更新する。</para>
    /// <para>　また、本BattleStateの更新はマスタークライアント側が行う。</para>
    /// </summary>
    /// <param name="newValue">更新する新しいBattleStateの値</param>
    public void SetBattleStateInRoomCP(Enums.BattleState newValue)
    {
        // マスタークライアントでない者が設定しようとした場合は抜ける
        if (!PhotonNetwork.isMasterClient) return;

        roomCP["BS"] = newValue;
    }
}
