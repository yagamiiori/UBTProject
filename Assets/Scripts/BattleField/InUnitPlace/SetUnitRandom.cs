using UnityEngine;
using System.Collections;

/// <summary>
/// UnitPlace時ユニットランダム配置クラス
/// <para>　UnitPlace時に一人もユニットが配置されずバトルが開始された場合に</para>
/// <para>　ランダムで一人ユニットを配置する。（フェールセーフ的な機能）</para>
/// </summary>
public class SetUnitRandom : MonoBehaviour
{
    /// <summary>
    /// ユニットインスタンス作成クラス
    /// </summary>
    private InstantiateUnitOnTip unitCreate;
    /// <summary>
    /// バトル参加中ユニット管理クラス
    /// </summary>
    private BattleUnitList battleUnitList;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetUnitRandom() { }

    void Start()
    {
        // ユニットインスタンス作成クラスを取得
        unitCreate = this.gameObject.GetComponent<InstantiateUnitOnTip>();

        // バトル参加中ユニット管理クラスを取得
        battleUnitList = GameObject.Find("Canvas").GetComponent<BattleUnitList>();
    }

    /// <summary>
    /// ユニットランダム配置メソッド
    /// <para>　ユニットをランダムで選択し、チップ上に配置する。</para>
    /// </summary>
    public void Set()
    {
        // 配置するユニットのIDをランダムで決定
        int unitId = Random.Range(0,16);
        // 配置するチップの座標
        Vector3 tipPosition = new Vector3(0.86f, 1.2f, 0);

        // ユニットのインスタンスをチップ上に作成する
        unitCreate.CreateUnitGO(unitId, tipPosition);

        // バトル参加中ユニット管理クラスの自軍ユニットリストに配置したユニットのIDを追加
        battleUnitList.AddMyList(unitId);
    }
}
