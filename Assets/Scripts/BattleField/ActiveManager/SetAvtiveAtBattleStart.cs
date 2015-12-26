using UnityEngine;
using System.Collections;

/// <summary>
/// 各種ウィンドウアクティブ化クラス
/// <para>　ユニットの初期配置完了後において、バトルで使う各種ウィンドウをアクティブ化する。</para>
/// </summary>
public class SetAvtiveAtBattleStart : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetAvtiveAtBattleStart() { }

    /// <summary>
    /// 各種ウィンドウアクティブ化メソッド
    /// <para>　バトル開始時に必要な各種ウィンドウをアクティブ化する。</para>
    /// </summary>
    public void SetActiveWindows()
    {
        // フィールドステータスウィンドウをアクティブ化する
        var fieldStatusWindow = GameObject.Find("Canvas_FieldStatusWindow").GetComponent<FieldStatusActiveManager>();
        fieldStatusWindow.fieldStatusWindowParentGO.SetActive(true);

        // WTパネルをアクティブ化する
        var wtPanel = GameObject.Find("Canvas_WaitTurnPanel").GetComponent<WaitTurnPanelActiveManager>();
        wtPanel.waitTurnPanelParentGO.SetActive(true);

        // TSゲージ（タクティカルシチュエーションゲージ）をアクティブ化する
        var tsGage = GameObject.Find("Canvas_TsGage").GetComponent<TsGageActiveManager>();
        tsGage.tsGageParentGO.SetActive(true);

        // ガードゲージをアクティブ化する
        var guardGage = GameObject.Find("Canvas_GuardGage").GetComponent<GuardGageActiveManager>();
        guardGage.guardGageParentGO.SetActive(true);
    }
}
