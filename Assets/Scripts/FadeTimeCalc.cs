using UnityEngine;
using System.Collections;

public class FadeTimeCalc : MonoBehaviour
{
    public float elapsedTime = 0;      // 経過時間
    public float lerpTime = 0;         // 補間係数

    public IEnumerator FadeTimeCalcStart(float fadeOutTime)
    {
        // 経過時間が指定されたフェード時間を超過するまでループ
        while (0 < fadeOutTime && elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;          // 経過時間取得
            lerpTime = elapsedTime / fadeOutTime;   // 補正係数算出

            yield return lerpTime;
        }
    }
}
