using UnityEngine;
using System.Collections;

/// <summary>
/// チップ管理クラス
/// <para>　チップGOのコンポとしてPrefabに実装されるクラス。</para>
/// <para>　自身のチップ画像を引数のチップ種別から判断し、自身のRndererに設定する。</para>
/// </summary>
public class Tip : Token
{
    /// <summary>
    /// チップ種別
    /// </summary>
    public int tipType = 0;
    /// <summary>
    /// トークン管理クラス
    /// </summary>
    public static TokenMgr<Tip> parent = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Tip() { }

    /// <summary>
    /// チップ追加メソッド
    /// </summary>
    /// <param name="id">チップ種別</param>
    /// <param name="x">チップ座標X</param>
    /// <param name="y">チップ座標Y</param>
    /// <returns></returns>
    public static Tip Add(int id, float x, float y, int i, int j, string tipImageName, string tipSpriteName)
    {
        if (parent == null)
        {
            // Resorcesフォルダ内のチップGOのprefab名を指定
            parent = new TokenMgr<Tip>("Tip");
        }

        // チップGOをInstantiateにて作成する
        var t = parent.Add(x, y);
        t.TipSpriteSet(id, tipImageName, tipSpriteName);

        // マップ構成マトリクスXY値を基底クラスのフィールドに設定する
        t.SetTipMatrix(i,j);
        return t;
    }

    /// <summary>
    /// チップ画像設定メソッド
    /// <para>　引数で指定されたチップ種別を元に、そのチップがある画像ファイルから</para>
    /// <para>　チップ画像を取得し、基底クラスToken内のSetSpriteメソッドで</para>
    /// <para>　自身のSpriteRendererコンポにチップ画像を設定する。</para>
    /// </summary>
    /// <param name="id">チップ種別</param>
    public void TipSpriteSet(int tipType, string tipImageName, string tipSpriteName)
    {
        // チップ種別をフィールドに設定
        this.tipType = tipType;

        // チップ種別を元にチップ画像を取得
        var spr = Util.GetSprite("MapTips/" + tipImageName, tipSpriteName + tipType);
        // 取得したチップ画像をSpriteRendererコンポに設定する
        SetSprite(spr);
    }

    /// <summary>
    /// マップ構成マトリクスXY設定メソッド
    /// <para>　Tipの基底クラスであるTokenのmatrixXおよびmatrixYフィールドに</para>
    /// <para>　自身のマップ構成マトリクスXY値を設定する。</para>
    /// <para>　ここで設定した値はマップ上でチップをクリックした時のRayCastで使用される。</para>
    /// </summary>
    public void SetTipMatrix(int matrixX, int matrixY)
    {
        base.matrixX = matrixX;
        base.matrixY = matrixY;
    }
}
