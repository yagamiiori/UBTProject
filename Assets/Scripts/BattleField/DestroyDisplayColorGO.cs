using UnityEngine;
using System.Collections;

public class DestroyDisplayColorGO : MonoBehaviour 
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private DestroyDisplayColorGO() { }

    /// <summary>
    /// DisplayColorGo消去メソッド
    /// <para>　本オブジェクトを消去する。</para>
    /// </summary>
    public void Destroy()
    {
        Destroy(this);
    }
}
