using UnityEngine;
using System.Collections;

/// <summary>
/// WTパネルCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　WTパネルのアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのwaitTurnPanelParentGOフィールドを経由して行う。</para>
/// </summary>
public class WaitTurnPanelActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    public GameObject waitTurnPanelParentGO;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private WaitTurnPanelActiveManager() { }

    void Start()
    {
        // コマンドパネルの親オブジェクトを取得
        waitTurnPanelParentGO = this.transform.FindChild("Parent").gameObject;
        waitTurnPanelParentGO.SetActive(false);
    }
}
