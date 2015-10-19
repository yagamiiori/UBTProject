using UnityEngine;
using System.Collections;

/// <summary>
/// スキルウィンドウCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　スキルウィンドウのアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのskillWindowParentGOフィールドを経由して行う。</para>
/// </summary>
public class SkillWindowActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    public GameObject skillWindowParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SkillWindowActiveManager() { }

    void Start()
    {
        // コマンドパネルの親オブジェクトを取得
        skillWindowParentGO = this.transform.FindChild("Parent").gameObject;
        skillWindowParentGO.SetActive(false);
    }
}
