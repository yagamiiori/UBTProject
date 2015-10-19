using UnityEngine;
using System.Collections;

/// <summary>
/// 共通フィールド管理クラス
/// <para>　Photonにおいて対戦相手と自身との間で共通で持つフィールドを管理する。</para>
/// </summary>
public class CommonFieldsWithEnemy : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CommonFieldsWithEnemy() { }

    /// <summary>バトル前の初期配置が完了したか否か</summary>
    public bool isCompletedUnitPlace = false;
    /// <summary>バトルが終了したか否か</summary>
    public bool isBattleEnd = false;
    /// <summary>バトル勝利判定（WINNER_1P：マスタークライアント勝利 WINNER_2P：スレイブ勝利）</summary>
    public int winnerJud = Defines.NON_VALUE;
}
