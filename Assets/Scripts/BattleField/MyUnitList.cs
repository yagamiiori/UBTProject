using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// バトル参加中自軍ユニットリスト
/// <para>　バトルに参加している自軍のユニットリスト。</para>
/// </summary>
public class MyUnitList : MonoBehaviour
{
    /// <summary>
    /// バトル参加中の自軍ユニットリスト
    /// </summary>
    public List<GameObject> myUnitList;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private MyUnitList() { }
}
