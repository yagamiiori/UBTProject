using UnityEngine;
using System.Collections;

/// <summary>
/// Rayヒット検出クラス（Tipオブジェクト用）
/// <para>　ユニットGOやチップやステータスウィンドウなど、Rayを検出して</para>
/// <para>　何か処理をさせるゲームオブジェクトにアタッチするクラス。</para>
/// </summary>
public class DetectRayHitTip : DetectRayBase
{
    /// <summary>
    /// Ray連続ヒット抑止フラグ
    /// </summary>
    private bool isHit = false;

    /// <summary>
    /// Rayヒット判定メソッド
    /// <para>　自身のオブジェクトにRayがヒットした場合にShotRayCast.csからコールされる。</para>
    /// </summary>
    override public void DetectRayHit()
    {
    }
}
