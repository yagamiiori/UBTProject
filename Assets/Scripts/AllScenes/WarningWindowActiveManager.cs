using UnityEngine;
using System.Collections;

/// <summary>
/// ワーニングウィンドウにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　ワーニングウィンドウのアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのwarningWindowParentGOフィールドを経由して行う。</para>
/// </summary>
public class WarningWindowActiveManager : MonoBehaviour
{
    /// <summary>自身(ワーニングウィンドウ)のアクティブ状態</summary>
    public GameObject warningWindowParentGO;

    /// <summary>コンストラクタ</summary>
    private WarningWindowActiveManager() { }

	void Start ()
    {
        // ワーニングウィンドウの親オブジェクトを取得
        warningWindowParentGO = this.transform.FindChild("Parent").gameObject;
        warningWindowParentGO.SetActive(false);
    }
}
