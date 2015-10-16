using UnityEngine;
using System.Collections;

/// <summary>
/// ヘルプメッセージ親オブジェクトActive状態管理クラス
/// <para>　配下にあるヘルプメッセージ群の親オブジェクトを取得し</para>
/// <para>　そのアクティブ状態をスタックする。</para>
/// <para>　parentGOフィールドはMsgWindowCanvasクラスと</para>
/// <para>　各クラスのヘルプボタンにアタッチされたヘルプメッセージ表示クラス</para>
/// <para>　から設定される。</para>
/// </summary>
public class MessageWindowActiveManager : MonoBehaviour
{
    /// <summary>ヘルプメッセージ親オブジェクト</summary>
    public GameObject parentGO;

    /// <summary>コンストラクタ</summary>
    private MessageWindowActiveManager() { }

    void Start()
    {
        // ヘルプメッセージ親オブジェクトを取得
        parentGO = this.gameObject.transform.FindChild("Parent").gameObject;
        parentGO.SetActive(false);
    }
}
