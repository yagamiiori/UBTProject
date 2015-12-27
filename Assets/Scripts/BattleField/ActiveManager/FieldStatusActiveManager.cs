using UnityEngine;
using System.Collections;

/// <summary>
/// ステータスウィンドウCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　フィールドステータスウィンドウアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのfieldStatusWindowParentGOフィールドを経由して行う。</para>
/// </summary>
public class FieldStatusActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    public GameObject fieldStatusWindowParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private FieldStatusActiveManager() { }

    void Start()
    {
        // コマンドパネルの親オブジェクトを取得
        fieldStatusWindowParentGO = this.transform.FindChild("Parent").gameObject;
    }
}
