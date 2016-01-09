using UnityEngine;
using System.Collections;

/// <summary>
/// ユニットパラメータ設定クラス
/// <para> ShotRayCastInUnitPlace.cs内で作成されたユニットのパラメータに</para>
/// <para> 必要な情報を書き込む。</para>
/// <para> アタッチGO：Canvas_TimerInUnitPlace</para>
/// </summary>
public class SettingsUnitParam : MonoBehaviour
{
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SettingsUnitParam() { }

    void Start()
    {
        // ゲームマネージャーを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// ユニットパラメータ設定メソッド
    /// <para>　ShotRayCastInUnitPlace.csからコールされ、ユニットのパラメータを設定する。</para>
    /// </summary>
    /// <param name="unitID">リストから読み出すユニットのID</param>
    /// <param name="unit">設定する対象のユニットGOが持つ基底クラス</param>
    public void SettingUnitParams(int unitID, GameObject unit)
    {
        // 基底クラスを取得
        var unitBase = unit.GetComponent<UnitBase>();

        // ユニット名
        unitBase.unitName = gameManager.unitStateList[unitID].unitName;
        // ユニットID
        unitBase.unitID = unitID;
        // アビリティA
        unitBase.ability_A = gameManager.unitStateList[unitID].ability_A;
        // アビリティB
        unitBase.ability_B = gameManager.unitStateList[unitID].ability_B;
        // エレメント
        unitBase.element = gameManager.unitStateList[unitID].element;
    }
}
