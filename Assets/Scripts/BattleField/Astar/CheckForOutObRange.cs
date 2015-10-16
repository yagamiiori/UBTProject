using UnityEngine;
using System.Collections;

/// <summary>
/// 領域判定クラス
/// </summary>
public class CheckForOutObRange
{
    /// <summary>
    /// 領域判定メソッド
    /// <para>　引数で指定された情報のノード(パネル)が領域外か否かを判定する。</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="panelWidth"></param>
    /// <param name="panelHight"></param>
    /// <returns></returns>
    public bool IsOutOfRange(int x, int y, int panelWidth, int panelHight)
    {
        // 領域外の場合はtrueを返す
        if (x < 0 || x >= panelWidth) { return true; }
        if (y < 0 || y >= panelHight) { return true; }

        // 領域内の場合はfalseを返す
        return false;
    }
}
