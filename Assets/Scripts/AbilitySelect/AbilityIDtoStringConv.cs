using UnityEngine;
using System.Collections;

public class AbilityIDtoStringConv : MonoBehaviour
{

    /// <summary>コンストラクタ</summary>
    public AbilityIDtoStringConv() { }

    // -------------------------------------------
    // アビリティID→アビリティ文字列正引きメソッド
    // アビリティID（int）を元に対応するアビリティ名（string）を返す
    // -------------------------------------------
    public string Converter(int abl_ID)
    {
        // アビリティ表示枠に表示されるアビリティ名
        string abilityName = "";

        // アビリティIDで分岐
        switch (abl_ID)
        {
            // アビリティ - 攻撃力Up
            case Defines.ABL_POWERUP:
                abilityName = "攻撃力Up";
                break;

            // アビリティ - 防御力Up
            case Defines.ABL_DIFFENCEUP:
                abilityName = "防御力Up";
                break;

            // アビリティ - ムーブプラス
            case Defines.ABL_MOVEPLUS:
                abilityName = "ムーブプラス";
                break;

            // アビリティ - 見切り青眼
            case Defines.ABL_HCOUNTER:
                abilityName = "見切り青眼";
                break;

            // アビリティ - ダテレポ
            case Defines.ABL_TEREPORT:
                abilityName = "ダテレポ";
                break;

            // アビリティ - 魔法範囲Up
            case Defines.ABL_MRANGEUP:
                abilityName = "魔法範囲Up";
                break;

            // フェールセーフ
            default:
                break;
        }
        return abilityName;
    }
}
