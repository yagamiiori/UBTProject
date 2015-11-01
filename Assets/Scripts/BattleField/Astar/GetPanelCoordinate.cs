using UnityEngine;
using System.Collections;

/// <summary>
/// パネル位置情報クラス
/// <para>　パネル一つ一つの位置やグリッド情報を持つクラス</para>
/// </summary>
public class GetPanelCoordinate : MonoBehaviour
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
    private GetPanelCoordinate() { }

    private void Start()
    {
    }

    /// <summary>
    /// チップ座標X取得メソッド
    /// <para>　パネル上のX座標を取得する。</para>
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float GetPanelX(int i)
    {
        // カメラをワールド座標に変換
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        return 1.0f;
    }

    /// <summary>
    /// チップ座標Y取得メソッド
    /// <para>　パネル上のY座標を取得する。</para>
    /// </summary>
    /// <param name="j"></param>
    /// <returns></returns>
    public float GetPanelY(int j)
    {
        // カメラをワールド座標に変換
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        return 1.0f;
    }
}
