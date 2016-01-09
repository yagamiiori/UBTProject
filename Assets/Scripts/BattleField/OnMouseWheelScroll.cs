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
    /// 画面がスクロールする方向
    /// </summary>
    private enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

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
        if (!Input.GetButton("Fire2"))
        {
            // マウス右クリックされていない場合、画面を上下へスクロール
            if (wheelScrollValue > 0)
            {
                // 奥へのスクロールを検知
                ScroolStart(Direction.Up, wheelScrollValue);
            }
            else if (wheelScrollValue < 0)
            {
                // 奥へのスクロールを検知
                ScroolStart(Direction.Down, wheelScrollValue);
            }
            else
            {
                // ホイールスクロールなし
            }
        }
        else
        {
            // マウス右クリックされている場合、画面を左右へスクロール
            if (wheelScrollValue > 0)
            {
                // 奥へのスクロールを検知
                ScroolStart(Direction.Left, wheelScrollValue);
            }
            else if (wheelScrollValue < 0)
            {
                // 奥へのスクロールを検知
                ScroolStart(Direction.Right, wheelScrollValue);
            }
            else
            {
                // ホイールスクロールなし
            }        
        }
	}

    /// <summary>
    /// メインカメラスクロール開始メソッド
    /// <para>　ここからコルーチンメソッドをコールする。</para>
    /// </summary>
    /// <param name="direction">ホイールをスクロールさせた方向</param>
    /// <param name="scrollValue">スクロールさせたホイールの速さ</param>
    private void ScroolStart(Direction direction, float scrollValue)
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
    private IEnumerator CameraScroll(Direction direction, float scrollValue)
    {
        // スクロールする基準となる速度
        float scrollVelocity = 2.0f;
        // メインカメラの座標
        Vector3 scrollPos = new Vector3(0, 0, 0);

        // 奥へのスクロール（画面を上にスクロールする）
        if (Direction.Up == direction)
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocity) break;

                scrollPos.x = mainCamera.transform.localPosition.x;
                scrollPos.y = mainCamera.transform.localPosition.y + (scrollVelocity * scrollValue); // Y軸をスクロールさせる
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocity -= 0.2f;
                yield return 0;
            }
        }
        // 手前へのスクロール（画面を下にスクロールする）
        else if (Direction.Down == direction)
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocity) break;

                scrollPos.x = mainCamera.transform.localPosition.x;
                scrollPos.y = mainCamera.transform.localPosition.y + (scrollVelocity * scrollValue); // Y軸をスクロールさせる
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocity -= 0.2f;
                yield return 0;
            }
        }
        // 右クリック＋奥へのスクロール（画面を左にスクロールする）
        else if (Direction.Left == direction)
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocity) break;

                scrollPos.x = mainCamera.transform.localPosition.x - (scrollVelocity * scrollValue); // X軸をスクロールさせる
                scrollPos.y = mainCamera.transform.localPosition.y;
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocity -= 0.2f;
                yield return 0;
            }
        }
        // 右クリック＋手前へのスクロール（画面を右にスクロールする）
        else
        {
            while (true)
            {
                // 補正でスクロール基準速度が0になったらループを抜ける
                if (0.1f >= scrollVelocity) break;

                scrollPos.x = mainCamera.transform.localPosition.x - (scrollVelocity * scrollValue); // X軸をスクロールさせる
                scrollPos.y = mainCamera.transform.localPosition.y;
                scrollPos.z = mainCamera.transform.localPosition.z;
                mainCamera.transform.localPosition = scrollPos;

                // だんだん緩やかにスクロールさせるため補正をかける
                scrollVelocity -= 0.2f;
                yield return 0;
            }        
        }
    }
}
