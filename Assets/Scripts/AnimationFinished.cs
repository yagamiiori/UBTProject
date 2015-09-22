using UnityEngine;
using System.Collections;

public class AnimationFinished : MonoBehaviour
{
    // -----------------------
    // メカニムのアニメーションイベントからコールされる
    // エフェクトを破棄
    // -----------------------
    void OnAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
