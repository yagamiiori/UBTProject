using UnityEngine;
using System.Collections;

/// <summary>
/// チップデータ生成クラス
/// </summary>
public class MapLayer2D
{
    /// <summary>
    /// チップの幅
    /// </summary>
    private int _width;
    /// <summary>
    /// チップの高さ
    /// </summary>
    private int _height;
    /// <summary>
    /// 領域外を指定した時の例外値
    /// </summary>
    private int outOfRange = -1;
    /// <summary>
    /// チップ種別の配列（草原とかタイルとか）
    /// <para>　構成：timImage[チップの座標] = チップ種別 </para>
    /// </summary>
    private int[] tipArray = null;

    /// <summary>
    /// チップデータ幅取得メソッド
    /// </summary>
    public int Width
    {
        get { return _width; }
    }

    /// <summary>
    /// チップデータ高さ取得メソッド
    /// </summary>
    public int Height
    {
        get { return _height; }
    }

    /// <summary>
    /// チップデータ生成メソッド
    /// <para>　チップの幅*高さよりチップデータ領域を生成する（tipImage[xx]のxx部分）</para>
    /// </summary>
    public void Create(int width, int height)
    {
        _width = width;
        _height = height;
        tipArray = new int[Width * Height];
    }

    /// <summary>
    /// 座標→Index変換メソッド
    /// </summary>
    public int ConvertPositionToIndex(int x, int y)
    {
        return x + (y * Width);
    }

    /// <summary>
    /// 領域外チェックメソッド
    /// </summary>
    public bool CheckOutOfRange(int x, int y)
    {
        if (x < 0 || x >= Width)  { return true; }
        if (y < 0 || y >= Height) { return true; }

        // 領域内
        return false;
    }

    /// <summary>
    /// チップ座標データ設定メソッド
    /// <para>　チップ固有の座標値を生成し、フィールドへ設定する。</para>
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="v">設定するチップ種別（草原チップか石畳かとか）</param>
    public void Set(int x, int y, int v)
    {
        if (CheckOutOfRange(x, y))
        {
            // 領域外を指定した
            return;
        }

        // _values[チップ座標値]にv(草原チップ)を設定するって感じ
        tipArray[y * Width + x] = v;
    }

    /// <summary>
    /// チップ座標データ取得メソッド
    /// <para>　チップ固有の座標値を取得する。</para>
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <returns>指定の座標の値（領域外を指定したら_outOfRangeを返す）</returns>
    public int Get(int x, int y)
    {
        if (CheckOutOfRange(x, y))
        {
            return outOfRange;
        }

        return tipArray[y * Width + x];
    }

    /// デバッグ出力
    public void Dump()
    {
        Debug.Log("[MapLayer2D] (w,h)=(" + Width + "," + Height + ")");
        for (int y = 0; y < Height; y++)
        {
            string s = "";
            for (int x = 0; x < Width; x++)
            {
                s += Get(x, y) + ",";
            }
            Debug.Log(s);
        }
    }
}
