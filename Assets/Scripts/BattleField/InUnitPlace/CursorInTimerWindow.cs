using UnityEngine;
using System.Collections;

/// <summary>
/// カーソル表示クラス
/// <para>　初期配置時において初期配置タイマーウィンドウ内に1P/2Pを示すカーソルを表示する。</para>
/// <para>　なお、マスター：1P　スレイブ：2Pとする。</para>
/// <para>　アタッチGO：カーソル</para>
/// </summary>
public class CursorInTimerWindow : MonoBehaviour 
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CursorInTimerWindow() { }

	void Start ()
    {
        // カーソルゲームオブジェクトを取得し、マスター/スレイブによって表示位置を決定する
        Vector3 p1position = new Vector3(103, -50, 0);
        Vector3 p2position = new Vector3(395, -50, 0);
        if (PhotonNetwork.isMasterClient) this.transform.localPosition = p1position;
        if (!PhotonNetwork.isMasterClient) this.transform.localPosition = p2position;
	}
}
