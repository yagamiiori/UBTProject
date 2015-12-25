using UnityEngine;
using System.Collections;

/// <summary>
/// チップデータ生成クラス
/// </summary>
public class MapLayer2D
{
    /// <summary>
    /// チップ種別の配列（草原とかタイルとか）tipTypeArray[チップの座標] = チップ種別
    /// </summary>
    private int[] tipTypeArray = null;
    /// <summary>
    /// チップの幅
    /// </summary>
    private int _width;
    public int Width
    {
        get { return _width; }
    }
    /// <summary>
    /// チップの高さ
    /// </summary>
    private int _height;
    public int Height
    {
        get { return _height; }
    }
    /// <summary>
    /// マップ構成マトリクスの領域外が指定された場合の例外値
    /// </summary>
    private int outOfRange = -1;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public MapLayer2D() { }

    /// <summary>
    /// チップデータ生成メソッド
    /// <para>　チップの幅*高さよりチップ管理リストにチップ数分の領域を確保する（tipImage[xx]のxx部分）</para>
    /// </summary>
    public void CreateTipListIndex(int width, int height)
    {
        _width = width;
        _height = height;
        tipTypeArray = new int[Width * Height];
    }

    /// <summary>
    /// マップ構成マトリクス→Index変換メソッド
    /// <para>　マップ構成マトリクスXY軸をマップ構成マトリクスList用のIndex値に変換する。</para>
    /// </summary>
    /// <param name="x">マップ構成マトリクスX軸</param>
    /// <param name="y">マップ構成マトリクスY軸</param>
    /// <returns></returns>
    public int ConvertPositionToIndex(int x, int y)
    {
        return x + (y * Width);
    }

    /// <summary>
    /// マップ構成マトリクス領域外チェックメソッド
    /// <para>　引数指定された範囲がマップ構成マトリクスの領域外か否かを判定する。</para>
    /// </summary>
    public bool CheckOutOfRange(int x, int y)
    {
        if (x < 0 || x >= Width)  { return true; }
        if (y < 0 || y >= Height) { return true; }

        // 領域内
        return false;
    }

    /// <summary>
    /// チップ種別設定メソッド
    /// <para>　マップ構成マトリクスXY軸を元にしたIndexにチップ種別を設定する。</para>
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="v">設定するチップ種別（草原チップか石畳かとか）</param>
    public void Set(int x, int y, int v)
    {
        if (CheckOutOfRange(x, y))
        {
            // マップ構成マトリクスの領域外を指定した場合
            Debug.Log("指定された値がマップ構成マトリクスの範囲外です。");
            return;
        }

        // tipTypeArray[マップ構成マトリクスXYを元に作ったIndex]にv(草原チップ)を設定するって感じ
        tipTypeArray[y * Width + x] = v;
    }

    /// <summary>
    /// チップ種別取得メソッド
    /// <para>　引数で指定されたマップ構成マトリクスのIndexに位置するチップ種別を取得する。</para>
    /// </summary>
    /// <param name="x">マップ構成マトリクスX軸</param>
    /// <param name="y">マップ構成マトリクスY軸</param>
    /// <returns>引数で指定された位置のチップ種別</returns>
    public int Get(int x, int y)
    {
        if (CheckOutOfRange(x, y))
        {
            // マップ構成マトリクスの領域外を指定した場合
            Debug.Log("指定された値がマップ構成マトリクスの範囲外です。");
            return outOfRange;
        }
        return tipTypeArray[y * Width + x];
    }

    /// <summary>
    /// ダンパー
    /// </summary>
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
