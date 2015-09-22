using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// ユニットID取得クラス
/// <para>　属するユニットIDを同じく属するユニットID表示Textコンポの文字列より取得する。</para>
/// </summary>
public class GetMyUnitID : MonoBehaviour
{

    /// <summary>
    /// ユニットID取得メソッド
    /// <para>　属するユニットIDを同じく属するユニットID表示Textコンポの文字列より取得する。</para>
    /// <param name="text_UnitID">取得元となるユニットID表示Textコンポ</param>
    /// <returns>自オブジェクトが属するユニットID</returns>
    /// </summary>
    public int GetUnitID(Text text_UnitID)
    {
        // ユニットIDのTextからユニットIDである最後の1文字(または2文字)を抜き出して定数リテラルに変換する
        int unitID = 0;
        if (4 == text_UnitID.text.Length)
        {
            // IDが1桁の場合は末尾1文字を抽出
            unitID = int.Parse(text_UnitID.text.Substring(text_UnitID.text.Length - 1, 1));
        }
        else
        {
            // IDが2桁の場合は末尾2文字を抽出
            unitID = int.Parse(text_UnitID.text.Substring(text_UnitID.text.Length - 2, 2));
        }
        return unitID - 1;
    }
}
