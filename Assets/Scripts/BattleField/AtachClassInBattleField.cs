using UnityEngine;
using System.Collections;

/// <summary>
/// クラスコンポーネントアタッチクラス
/// <para>　BattleFieldシーンにおいてUnitStateより自身の</para>
/// <para>　クラスタイプを読み込み、対応したクラスコンポーネントをアタッチする。</para>
/// </summary>
public class AtachClassInBattleField : MonoBehaviour
{
    /// <summary>ユニットステート</summary>
    private UnitState unitstate;

    void Start()
    {
        unitstate = this.gameObject.GetComponent<UnitState>();
    }

	void Update ()
    {
        // BattleFieldシーンに入った場合
        if (Application.loadedLevelName == "BattleField")
        {
            // クラスタイプによりアタッチするクラスコンポを分岐
            switch (unitstate.classType)
            {
                case Defines.SOLDLER:
                    this.gameObject.AddComponent<Soldier>();
                    break;
                case Defines.WIZARD:
                    this.gameObject.AddComponent<Wizard>();
                    break;
                default:
                    // 処理なし
                    break;
            }
        }
	}
}
