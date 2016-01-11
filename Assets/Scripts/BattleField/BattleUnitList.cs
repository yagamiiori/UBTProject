using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 戦闘参加ユニット管理クラス
/// <para>　自軍、敵軍、自敵全軍の3つのリストを保有する。</para>
/// </summary>
public class BattleUnitList : MonoBehaviour
{
    /// <summary>
    /// バトルに参加している自軍ユニット
    /// </summary>
    public List<int> myUnits = new List<int>();
    /// <summary>
    /// バトルに参加している敵軍ユニット
    /// </summary>
    public List<int> enemyUnits = new List<int>();
    /// <summary>
    /// バトルに参加している自敵軍合わせた全ユニット
    /// </summary>
    private List<int> allUnits = new List<int>();
    private List<int> AllUnits
    {
        get { return allUnits; }
        set { allUnits = value; }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BattleUnitList() { }

    public void AddMyList(int unitID)
    {
        foreach (var t in myUnits)
        {
            // IDがすでにリスト内にある場合は追加しない
            if (t == unitID) return;
        }
        // リスト内にまだ無いユニットIDの場合のみリストに追加
        myUnits.Add(unitID);
        AllUnits.Add(unitID);
    }

    public void RemoveMyList(int unitID)
    {
        foreach (var t in myUnits)
        {
            if (t == unitID)
            {
                // IDがすでにリスト内にある場合は削除する
                myUnits.Remove(unitID);
                AllUnits.Remove(unitID);
                return;
            }
        }
    }
}
