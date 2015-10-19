using UnityEngine;
using System.Collections;

/// <summary>
/// ユニット初期配置時のPunRPC管理クラス
/// <para>　初期配置時に他プレイヤーとRPCによる初期配置完了判定のやり取りを行う。</para>
/// <para>　自分側と相手側のフラグが共に真になった場合、初期配置パートの完了として</para>
/// <para>　ルームCPのBattleStateを「BattleNow」に更新し、バトルを開始する。</para>
/// </summary>
public class UnitPlaceCompJudRPC : Photon.MonoBehaviour
{
    /// <summary>自分側初期配置完了有無判定</summary>
    public bool isCompleteMySide = false;
    /// <summary>相手側初期配置完了有無判定</summary>
    public bool isCompleteEnemySide = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitPlaceCompJudRPC() { }

    /// <summary>
    /// 初期配置完了報告受信メソッド
    /// <para>　相手側よりRPCにて送信される初期配置の完了報告を受信し、</para>
    /// <para>　相手側初期配置完了有無判定を設定する。</para>
    /// </summary>
    /// <param name="isCompJud">相手が通知してきた初期配置完了報告</param>
    /// <param name="inf">メッセージ情報コンテナ</param>
    [PunRPC]
    public void RecivedCompRPC(bool isCompEnemy, PhotonMessageInfo inf)
    {
        // 相手側初期配置完了有無判定を設定（必ずtrueが送られてくるはず）
        isCompleteEnemySide = isCompEnemy;
    }

    /// <summary>
    /// 初期配置完了報告送信メソッド
    /// <para>　初期配置が完了した場合に相手側へ初期配置の完了報告を送信する。</para>
    /// </summary>
    [PunRPC]
    public void SendCompRPC()
    {
        // ターン判定フラグを送信
        photonView.RPC("RecivedCompRPC", PhotonTargets.Others, (bool)true);

        // 自分側初期配置完了有無判定をtrueに設定
        isCompleteMySide = true;
    }
}
