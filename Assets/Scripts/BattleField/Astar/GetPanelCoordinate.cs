using UnityEngine;
using System.Collections;

public class GetPanelCoordinate : MonoBehaviour
{
    /// <summary>パネルのグリッド（X軸）※FieldCreator.csから設定される</summary>
    public int gridX = 0;
    /// <summary>パネルのグリッド（Y軸）※FieldCreator.csから設定される</summary>
    public int gridY = 0;
    /// <summary>パネルの座標位置X</summary>
    private float posX = 0;
    /// <summary>パネルの座標位置Y</summary>
    private float posY = 0;
    /// <summary>パネルの座標位置Z</summary>
    private float posZ = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GetPanelCoordinate() { }

    private void Start()
    {
        // パネルの座標位置をそれぞれ取得
        posX = this.gameObject.transform.position.x;
        posY = this.gameObject.transform.position.y;
        posZ = this.gameObject.transform.position.z;
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
