using UnityEngine;
using System.Collections;

/// <summary>
/// UnitSelectシーン専用ユニットリスト全消去クラス
/// <para>　UnitSelectシーンをロードするのはユニットを初期選択する場合、</para>
/// <para>　もしくは最初から部隊を再編成する場合のみである。</para>
/// <para>　従ってシーン開始時において一律、保持するユニットリストをクリアするため、</para>
/// <para>　本クラス内にてユニットリスト削除クラスのインスタンス化およびメソッドコール</para>
/// <para>　を行う。</para>
/// </summary>
public class UnitListAllClearInUnitSelect : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    private UnitListAllClearInUnitSelect() { }

	void Start ()
    {
        // ユニットリスト削除クラスを作成し、全ユニットリスト削除メソッドをコールする
        var t = new UnitListClear();
        t.UnitListAllClear();
	}
}
