using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// カーソル追随クラス
/// <para>　カーソルが画面端に行った時、カーソルをカメラが追随する。</para>
/// <para>　アタッチGO：メインカメラ</para>
/// </summary>
public class TraceMousePosition : MonoBehaviour
{
    /// <summary>
    /// カメラがカーソルに追随する速度
    /// </summary>
    private float cameraSpeed = 0.0002f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private TraceMousePosition() { }

    void Start()
    {
        Vector3 t = new Vector3(3.56f, 6.25f, -8.24f);
        this.transform.position = t;
    }

    void Update()
    {
        // マウスのワールド座標をビューポート座標に変換
        var t = Camera.main.WorldToViewportPoint(Input.mousePosition);

//        Debug.Log(t);

        var setPos = Vector3.Lerp(this.transform.position, t, cameraSpeed);

        // 下方向
        if (2.0f > t.y)
        {
            // 左下
            if (4.0f > t.x)
            {
                setPos.x -= 0.2f;
                setPos.y -= 0.2f;
                this.transform.position = setPos;
            }
            // 右下
            else if (50.0f < t.x)
            {
                setPos.x += 0.2f;
                setPos.y -= 0.2f;
                this.transform.position = setPos;
            }
            // 真下
            else
            {
                setPos.x = this.transform.position.x;
                setPos.y -= 0.2f;
                this.transform.position = setPos;
            }
        }
        // 上方向
        else if (50.0f < t.y)
        {
            // 左上
            if (4.0f > t.x)
            {
                setPos.x -= 0.2f;
                setPos.y += 0.2f;
                this.transform.position = setPos;
            }
            // 右上
            else if (50.0f < t.x)
            {
                setPos.x += 0.2f;
                setPos.y += 0.2f;
                this.transform.position = setPos;
            }
            // 真上
            else
            {
                setPos.x = this.transform.position.x;
                setPos.y += 0.2f;
                this.transform.position = setPos;
            }
        }
        // 左右
        else
        {
            // 左
            if (2.0f > t.x)
            {
                setPos.x -= 0.2f;
                setPos.y = this.transform.position.y;
                this.transform.position = setPos;
            }
            // 右
            else if (50.0f < t.x)
            {
                setPos.x += 0.2f;
                setPos.y = this.transform.position.y;
                this.transform.position = setPos;
            }
            else
            {
                // 中央付近は何もしない
            }
        }
    }
}