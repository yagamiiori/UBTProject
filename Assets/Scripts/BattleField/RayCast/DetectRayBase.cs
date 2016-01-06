using UnityEngine;
using System.Collections;

/// <summary>
/// Ray検出基底クラス
/// </summary>
public class DetectRayBase : MonoBehaviour
{
    /// <summary>
    /// Rayヒット判定メソッド
    /// <para>　自身のオブジェクトにRayがヒットした場合にShotRayCast.csからコールされる。</para>
    /// </summary>
    virtual public void DetectRayHit()
    {
    
    }
}
