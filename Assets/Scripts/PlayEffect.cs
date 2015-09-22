using UnityEngine;
using System.Collections;

public class PlayEffect : MonoBehaviour
{
    // ---------------------------------------------
    // エフェクト表示メソッド
    // エフェクトを一度だけ表示する。
    // 引数：エフェクトスプライトの場所、親オブジェクト(子に設定する場合、表示位置)
    // ---------------------------------------------
    public void PlayOnce(string name, GameObject rootObject, Vector3 potision)
    {
        GameObject effect;  // 生成したエフェクト

        // エフェクトの生成および親オブジェクト指定がある場合はそれをParentとして設定する
        effect = Instantiate(Resources.Load(name), potision, Quaternion.identity) as GameObject;
        if(rootObject) effect.transform.SetParent(rootObject.transform, false);
    }
}
