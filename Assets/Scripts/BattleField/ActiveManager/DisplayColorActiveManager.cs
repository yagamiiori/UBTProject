using UnityEngine;
using System.Collections;

/// <summary>
/// Canvas_DisplayColorにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　フィールドステータスウィンドウアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのdisplayColorParentGOフィールドを経由して行う。</para>
/// </summary>
public class DisplayColorActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    public GameObject displayColorParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private DisplayColorActiveManager() { }

    void Start()
    {
        // コマンドパネルの親オブジェクトを取得
        displayColorParentGO = this.transform.FindChild("Parent").gameObject;
        displayColorParentGO.SetActive(false);
    }
}
