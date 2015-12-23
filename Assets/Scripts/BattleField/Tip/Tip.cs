using UnityEngine;
using System.Collections;

/// チップ管理クラス
public class Tip : Token
{
    /// <summary>
    /// チップ種別
    /// </summary>
    public int tipType = 0;

    public static TokenMgr<Tip> parent = null;

    /// <summary>
    /// チップ追加メソッド
    /// </summary>
    /// <param name="id">チップ種別</param>
    /// <param name="x">チップ座標X</param>
    /// <param name="y">チップ座標Y</param>
    /// <returns></returns>
    public static Tip Add(int id, float x, float y)
    {
        if (parent == null)
        {
            // Resorcesフォルダ内のチップGOのprefab名
            parent = new TokenMgr<Tip>("Tip");
        }
        var t = parent.Add(x, y);
        t.Create(id);
        return t;
    }

    /// <summary>
    /// チップ作成メソッド
    /// </summary>
    /// <param name="id">チップ種別</param>
    public void Create(int tipType)
    {
        // チップ種別をフィールドに設定
        this.tipType = tipType;

        var spr = Util.GetSprite("MapTips/Tips_1", "Tips_1_" + tipType);
        SetSprite(spr);
    }
}
