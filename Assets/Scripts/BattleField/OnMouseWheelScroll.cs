using UnityEngine;
using System.Collections;

/// <summary>
/// マウスホイールスクロール判定クラス
/// <para>　マウスホイールのスクロールを検知する。</para>
/// <para>　アタッチGO：Canvas</para>
/// </summary>
public class OnMouseWheelScroll : MonoBehaviour
{
    /// <summary>
    /// メインカメラ
    /// </summary>
    private GameObject mainCamera;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnMouseWheelScroll() { }

    void Start()
    {
        // メインカメラを取得
        mainCamera = GameObject.Find("Main Camera");
    }

	void Update ()
    {
        // マウスのホイールスクロールを取得
        var wheelScrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelScrollValue > 0)
        {
            // 奥へのスクロールを検知
            ScroolStart(0, wheelScrollValue);
        }
        else if (wheelScrollValue < 0)
        {
            // 奥へのスクロールを検知
            ScroolStart(1, wheelScrollValue);
        }
        else
        {
            // ホイールスクロールなし
        }
	}

    /// <summary>
    /// メインカメラスクロール開始メソッド
    /// <para>　ここからコルーチンメソッドをコールする。</para>
    /// </summary>
    /// <param name="direction">ホイールをスクロールさせた方向</param>
    /// <param name="scrollValue">スクロールさせたホイールの速さ</param>
    private void ScroolStart(int direction, float scrollValue)
    {
        StartCoroutine(CameraScroll(direction, scrollValue));
    }

    /// <summary>
    /// メインカメラスクロール実施メソッド
    /// <para>　コルーチンによりメインカメラのスクロール処理を実施する。</para>
    /// </summary>
    /// <param name="direction">ホイールをスクロールさせた方向</param>
    /// <param name="scrollValue">スクロールさせたホイールの速さ</param>
    /// <returns>なし</returns>
    private IEnumerator CameraScroll(int direction, float scrollValue)
    {
        // スクロールする基準となる速度
        float scrollVelocityY = 2.0f;
        // メインカメラの座標
        Vector3 scrollPos = new Vector3(0, 0, 0);

        // 奥へのスクロール
        if (0 == direction)
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocityY) break;

                scrollPos.x = mainCamera.transform.localPosition.x;
                scrollPos.y = mainCamera.transform.localPosition.y + (scrollVelocityY * scrollValue); // Y軸をスクロールさせる
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocityY -= 0.2f;
                yield return 0;
            }
        }
        // 手前へのスクロール
        else
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocityY) break;

                scrollPos.x = mainCamera.transform.localPosition.x;
                scrollPos.y = mainCamera.transform.localPosition.y + (scrollVelocityY * scrollValue); // Y軸をスクロールさせる
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocityY -= 0.2f;
                yield return 0;
            }
        }
    }
}
