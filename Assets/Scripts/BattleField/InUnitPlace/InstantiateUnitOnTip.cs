using UnityEngine;
using System.Collections;

/// <summary>
/// ユニットインスタンス作成クラス
/// <para>　UnitPlaceにおいて、クリックされたチップ上にユニットGOを作成する。</para>
/// <para>　アタッチGO：Canvas_TimerInUnitPlace
/// </summary>
public class InstantiateUnitOnTip : MonoBehaviour
{
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// ユニットパラメータ設定クラス
    /// </summary>
    private SettingsUnitParam settingUnitParam;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private InstantiateUnitOnTip() { }

    void Start()
    {
        // ゲームマネージャー取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ユニットパラメータ設定クラス取得
        settingUnitParam = this.gameObject.GetComponent<SettingsUnitParam>();
    }

    /// <summary>
    /// ユニットGO作成メソッド
    /// <para>　クリックされたチップ上にユニットGOを作成する。</para>
    /// </summary>
    /// <param name="unitID">作成するユニットのID</param>
    /// <param name="tipPosition">ユニットを配置するチップの座標</param>
    public void CreateUnitGO(int unitID, Vector3 tipPosition)
    {
        // prefab名
        string prefabName = null;
        // Y軸をちょっと補正
        tipPosition.y += 0.5f;

        // 作成するユニットIDからそのユニットのクラスを判定
        switch (gameManager.unitStateList[unitID].classType)
        {
            case Defines.SOLDLER: // ソルジャー
                prefabName = "UnitSprite_BattleStage/SOLDLER";
                break;
            case Defines.WIZARD:  // ウィザード
                prefabName = "UnitSprite_BattleStage/WIZARD";
                break;
            default:              // 例外
                // 処理なし
                break;
        }
        // ユニットGOをインスタンス化
        // TODO PhotonNetwork.Instantiateになる事に注意！ハマった
        var unit = PhotonNetwork.Instantiate(prefabName, tipPosition, Quaternion.identity, 0);
        unit.name = "Unit" + unitID.ToString();
        // インスタンス化したユニットのパラメータを設置する
        settingUnitParam.Execute(unitID, unit as GameObject);
    }
}
