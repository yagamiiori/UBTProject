using UnityEngine;
using System.Collections;

/// <summary>
/// アニメーション破棄クラス
/// </summary>
public class AnimationFinished : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public AnimationFinished() { }

    /// <summary>
    /// メカニムのアニメーションイベントからコールされる（エフェクトを破棄する）
    /// </summary>
    void OnAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
