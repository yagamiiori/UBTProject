using UnityEngine;
using System.Collections;

/// <summary>
/// ガードゲージのCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　フィールドステータスウィンドウアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのfieldStatusWindowParentGOフィールドを経由して行う。</para>
/// </summary>
public class GuardGageActiveManager : MonoBehaviour
{
    /// <summary>自身のアクティブ状態</summary>
    public GameObject guardGageParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GuardGageActiveManager() { }

    void Start()
    {
        // ガードゲージの親オブジェクトを取得
        guardGageParentGO = this.transform.FindChild("Parent").gameObject;
        guardGageParentGO.SetActive(false);
    }
}
