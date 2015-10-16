using UnityEngine;
using System.Collections;

/// <summary>
/// パネル固有インデックス値生成クラス
/// <para>　連想配列に入れるためにノード(パネル)のXYおよび幅情報から</para>
/// <para>　ノード固有のインデックスを生成する。</para>
/// </summary>
public class CoordinateToIndex
{
    /// <summary>
    /// ノード(パネル)のXY座標からインデックスを生成して返す
    /// </summary>
    /// <param name="x">ノードのX値</param>
    /// <param name="y">ノードのY値</param>
    /// <param name="width">ノードの幅px</param>
    /// <returns>生成したノード(パネル)固有のインデックス値</returns>
    public int IndexCreator(int x, int y, int panelWidth)
    {
        return x + (y * panelWidth);
    }
}
