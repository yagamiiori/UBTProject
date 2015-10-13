using UnityEngine;
using System.Collections;

/// <summary>
/// コマンドパネルCanvasにアタッチし、自身のアクティブ状態を管理する
/// 　<para>　コマンドパネルのアクティブ状態の変更は</para>
/// 　<para>　必ず本クラスのcommandPanelParentGOフィールドを経由して行う。</para>
/// </summary>
public class CommandPanelActiveManager : MonoBehaviour
{
    /// <summary>自身(コマンドパネル)のアクティブ状態</summary>
    private GameObject commandPanelParentGO;

    /// <summary>コンストラクタ</summary>
    private CommandPanelActiveManager() { }

	void Start ()
    {
        // コマンドパネルの親オブジェクトを取得
        commandPanelParentGO = this.transform.FindChild("Parent").gameObject;
        commandPanelParentGO.SetActive(false);
    }
}
