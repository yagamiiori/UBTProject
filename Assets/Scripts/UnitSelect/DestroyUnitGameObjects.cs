using UnityEngine;
using System.Collections;

/// <summary>
/// UnitSelectシーン専用ユニットGO全消去クラス
/// <para>　UnitSelectシーンをロードするのはユニットを初期選択する場合、</para>
/// <para>　もしくは最初から部隊を再編成する場合のみである。</para>
/// <para>　UnitFormより遷移した場合、すでにユニットGOが存在しているため、</para>
/// <para>　本クラス内にてユニットGOの全削除を行う。</para>
/// </summary>
public class DestroyUnitGameObjects : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    private DestroyUnitGameObjects() { }

	void Start ()
    {
        // 全てのユニットGOを取得し、削除する
        var t = GameObject.FindGameObjectsWithTag("UnitGO");
        foreach (var i in t)
        {
            Destroy(i);
        }
	}
	
}
