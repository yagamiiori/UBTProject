using UnityEngine;
using System.Collections;

public class PlayEffect : MonoBehaviour
{

    /// <summary>コンストラクタ</summary>
    public PlayEffect() { }

    /// <summary>
    /// エフェクト表示メソッド
    /// <para>　エフェクトを一度だけ表示する。</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parentObject"></param>
    /// <param name="potision"></param>
    public void PlayOnce(string name, GameObject parentObject, Vector3 potision)
    {
        // 生成したエフェクトのオブジェクト
        GameObject effect;

        // エフェクトを生成し引数で指定された親オブジェクトの子に設定する
        effect = Instantiate(Resources.Load(name), potision, Quaternion.identity) as GameObject;
        if (parentObject) effect.transform.SetParent(parentObject.transform, false);
    }
}
