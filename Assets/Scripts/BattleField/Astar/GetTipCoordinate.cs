using UnityEngine;
using System.Collections;

/// <summary>
/// チップ位置情報クラス
/// <para>　チップ一つ一つの位置やグリッド情報を持つクラス</para>
/// </summary>
public class GetTipCoordinate : MonoBehaviour
{
    /// <summary>パネルID ※FieldCreator.csから設定される</summary>
    public int panelID;
    /// <summary>パネルのグリッド（X軸）※FieldCreator.csから設定される</summary>
    public int gridX = 0;
    /// <summary>パネルのグリッド（Y軸）※FieldCreator.csから設定される</summary>
    public int gridY = 0;
    /// <summary>パネルの座標位置X　※FieldCreator.csから設定される</summary>
    public float posX = 0;
    /// <summary>パネルの座標位置Y　※FieldCreator.csから設定される</summary>
    public float posY = 0;
    /// <summary>パネルの座標位置Z　※FieldCreator.csから設定される</summary>
    public float posZ = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GetTipCoordinate() { }

    private void Start()
    {
    }

    /// <summary>
    /// チップ座標X算出メソッド
    /// <para>　マップ構成マトリクスのX値を引数に、そこに位置するチップの座標上のX値を算出して返す。</para>
    /// </summary>
    /// <param name="i">ループカウンターX</param>
    /// <returns>配置するチップの位置X</returns>
    public float GetTipPosX(int i)
    {
        // カメラをワールド座標に変換
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 取得対象のスプライト
        var spr = Util.GetSprite("MapTips/Tips_1", "Tips_1_0");
        var sprW = spr.bounds.size.x;

        return min.x + (sprW * i) + sprW / 2;
    }

    /// <summary>
    /// チップ座標Y算出メソッド
    /// <para>　マップ構成マトリクスのY値を引数に、そこに位置するチップの座標上のY値を算出して返す。</para>
    /// </summary>
    /// <param name="j">ループカウンターY</param>
    /// <returns>配置するチップの位置Y</returns>
    public float GetTipPosY(int j)
    {
        // カメラをワールド座標に変換
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 取得対象のスプライト
        var spr = Util.GetSprite("MapTips/Tips_1", "Tips_1_0");
        var sprH = spr.bounds.size.y;

        return max.y - (sprH * j) - sprH / 2;
    }
}
