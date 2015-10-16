using UnityEngine;
using System.Collections;

/// <summary>
/// ユニットステータスウィンドウCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　ユニットステータスウィンドウアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのunitStatusWindowParentGOフィールドを経由して行う。</para>
/// </summary>
public class UnitStatusWindowActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    private GameObject unitStatusWindowParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitStatusWindowActiveManager() { }

    void Start()
    {
        // コマンドパネルの親オブジェクトを取得
        unitStatusWindowParentGO = this.transform.FindChild("Parent").gameObject;
        unitStatusWindowParentGO.SetActive(false);
    }
}
