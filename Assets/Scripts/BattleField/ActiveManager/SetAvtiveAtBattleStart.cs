using UnityEngine;
using System.Collections;

/// <summary>
/// バトル時各種ウィンドウアクティブ化クラス
/// <para>　ユニットの初期配置完了後、バトルで使う各種ウィンドウをアクティブ化する。</para>
/// </summary>
public class SetAvtiveAtBattleStart : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetAvtiveAtBattleStart() { }

    /// <summary>
    /// 各種ウィンドウアクティブ化メソッド
    /// <para>　バトル中に使う各種ウィンドウをアクティブ化する。</para>
    /// </summary>
    public void ActiveWindows()
    {
        // フィールドステータスウィンドウをアクティブ化する
        var fieldStatusWindow = GameObject.Find("Canvas_FieldStatusWindow").GetComponent<FieldStatusActiveManager>();
        fieldStatusWindow.fieldStatusWindowParentGO.SetActive(true);

        // 画面下部のWTパネルをアクティブ化する
        var wtPanel = GameObject.Find("Canvas_WaitTurnPanel").GetComponent<WaitTurnPanelActiveManager>();
        wtPanel.waitTurnPanelParentGO.SetActive(true);
    }
}
