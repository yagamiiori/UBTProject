using UnityEngine;
using System.Collections;

/// <summary>
/// ヘルプメッセージ親オブジェクトActive状態管理クラス
/// <para>　配下にあるヘルプメッセージ群の親オブジェクトを取得し</para>
/// <para>　そのアクティブ状態をスタックする。</para>
/// <para>　parentGOフィールドはMsgWindowCanvasクラスと</para>
/// <para>　各クラスのヘルプボタンにアタッチされたヘルプメッセージ表示クラス</para>
/// <para>　から設定される。</para>
/// TODO 親オブジェクトのアクティブ状態の管理が密結合すぎ。デザパタ使った方がいい？
/// </summary>
public class HelpMsgParentGOstate : MonoBehaviour
{
    /// <summary>ヘルプメッセージ親オブジェクト</summary>
    public GameObject parentGO;

    void Start()
    {
        // ヘルプメッセージ親オブジェクトを取得
        parentGO = GameObject.Find("MessageWindowParentGO");
        parentGO.SetActive(false);
    }
}
