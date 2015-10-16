using UnityEngine;
using System.Collections;

public class GetPanelCoordinate : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GetPanelCoordinate() { }

    /// <summary>
    /// チップ座標X取得メソッド
    /// <para>　チップ上のX座標を取得する。</para>
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
    /// <para>　チップ上のY座標を取得する。</para>
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
