using UnityEngine;
using System.Collections;

/// <summary>
/// TSゲージのCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　フィールドステータスウィンドウアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのfieldStatusWindowParentGOフィールドを経由して行う。</para>
/// 　<para>　アタッチGO：Canvas_TsGage</para>
/// </summary>
public class TsGageActiveManager : MonoBehaviour
{
    /// <summary>自身のアクティブ状態</summary>
    public GameObject tsGageParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private TsGageActiveManager() { }

    void Start()
    {
        // TSゲージの親オブジェクトを取得
        tsGageParentGO = this.transform.FindChild("Parent").gameObject;
        tsGageParentGO.SetActive(false);
    }
}
