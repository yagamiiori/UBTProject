using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// ヘルプメッセージCanvas消去クラス
/// <para>　ヘルプメッセージ表示時において、マウス左クリックを判定し</para>
/// <para>　左クリックされたらヘルプメッセージCanvasを非アクティブ化する事で</para>
/// <para>　ウィンドウを消去する。</para>
/// </summary>
public class MsgWindowCanvas : MonoBehaviour
{
    /// <summary>ヘルプメッセージ親オブジェクトActive状態管理クラス</summary>
    private HelpMsgParentGOstate parentGOstate;

    void Start()
    {
        // ヘルプメッセージ親オブジェクトActive状態管理クラスを取得
        parentGOstate = this.gameObject.GetComponent<HelpMsgParentGOstate>();
    }

	void Update ()
    {
        // ヘルプメッセージがアクティブ状態の時に左クリックされた場合
        if (true == parentGOstate.parentGO.activeSelf && Input.GetMouseButtonDown(0))
        {
            // ヘルプメッセージ親オブジェクトを非アクティブ化する
            parentGOstate.parentGO.SetActive(false);
        }
	}
}
