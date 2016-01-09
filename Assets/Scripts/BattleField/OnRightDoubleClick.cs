using UnityEngine;
using System.Collections;

/// <summary>
/// マウス右ボタンダブルクリック判定クラス
/// <para>　マウス右ボタンのダブルクリックがされたか否かを判定する。</para>
/// <para>　アタッチGO：Canvas</para>
/// </summary>
public class OnRightDoubleClick : MonoBehaviour
{
    /// <summary>
    /// 一回目のクリックをトリガーとした経過時間
    /// </summary>
    private float elapsedSec = 0;
    /// <summary>
    /// 2回目のクリックを受け付ける許容時間（この時間を超過してからの2回目のクリックは無効）
    /// </summary>
    private float clickAllowSec = 0.1f;
    /// <summary>
    /// メインカメラ
    /// </summary>
    private GameObject mainCamera;
    /// <summary>
    /// メインカメラのカメラコンポ
    /// </summary>
    private Camera cameraCompo;
    /// <summary>
    /// ダブルクリックの実施中判定
    /// </summary>
    private bool isDoubleClickStarting = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnRightDoubleClick() { }

    void Start()
    {
        // メインカメラを取得
        mainCamera = GameObject.Find("Main Camera");
        cameraCompo = mainCamera.GetComponent<Camera>();
    }

    void Update()
    {
        // 右ダブルクリック - 1回目のクリックを判定
        if (!isDoubleClickStarting && Input.GetMouseButtonUp(1))
        {
            if (0 == elapsedSec)
            {
                // ダブルクリック開始フラグON
                isDoubleClickStarting = true;
                // カウントを開始し、2回目のクリックを待つ
                StartCoroutine(Counter());
            }
        }
        // 右ダブルクリック - 2回目のクリックを判定
        if (isDoubleClickStarting && Input.GetMouseButtonDown(1))
        {
            if (0 != elapsedSec)
            {
                // ダブルクリック待ち合わせ時間内であればダブルクリック成立
                DoubleClickConfirm();
                // ダブルクリック実施中判定と経過時間をクリア
                isDoubleClickStarting = false;
                elapsedSec = 0;
            }
        }
    }

    /// <summary>
    /// ダブルクリック許容時間カウンタ
    /// <para>　ダブルクリックの1回目をトリガーにカウントが開始され、2回目のクリックまでの</para>
    /// <para>　許容時間をカウントする。</para>
    /// <para>　許容時間閾値超過の場合はカウントを停止し、ダブルクリック不成立とする。</para>
    /// </summary>
    /// <returns>なし</returns>
    private IEnumerator Counter()
    {
        while (true)
        {
            if (clickAllowSec <= elapsedSec)
            {
                // タイムオーバーしたらメソッドを終了
                elapsedSec = 0;
                isDoubleClickStarting = false;
                break;
            }
            // 経過時間を加算
            elapsedSec += Time.deltaTime;
            yield return 0;
        }
    }

    /// <summary>
    /// ダブルクリック判定成立メソッド
    /// <para>　ダブルクリック成立時にコールされ、成立時の機能を実施する。</para>
    /// </summary>
    void DoubleClickConfirm()
    {
        // カメラのサイズを変更する
        if (10.0f == cameraCompo.orthographicSize)
        {
            // 通常スケールに戻す
            cameraCompo.orthographicSize = 6.0f;
        }
        else
        {
            // 広角ズームアウトを実施
            cameraCompo.orthographicSize = 10.0f;        
        }
    }
}
