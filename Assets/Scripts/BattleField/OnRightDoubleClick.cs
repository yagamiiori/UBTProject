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
    /// ダブルクリック2回目のクリックまでのマージンタイム（間隔時間）
    /// </summary>
    public float marginTime = 0.1f;
    /// <summary>
    /// 2回目のクリックを待つ時間（この時間を超過してからの2回目のクリックは無効）
    /// </summary>
    private float elapsedSec = 0;
    /// <summary>
    /// メインカメラ
    /// </summary>
    private GameObject mainCamera;
    /// <summary>
    /// メインカメラのカメラコンポ
    /// </summary>
    private Camera cameraCompo;
    /// <summary>
    /// ダブルクリック中経過時間クリア抑止フラグ
    /// </summary>
    private bool isDoubleClickStarting = false;
    /// <summary>
    /// マウスをクリックした回数
    /// </summary>
    private int clickCounter = 0;

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
                // カウントメソッドを起動し、2回目のクリックを待つ
                StartCoroutine(Counter());
            }
        }
        // 右ダブルクリック - 2回目のクリックを判定
        if (isDoubleClickStarting && Input.GetMouseButtonDown(1))
        {
            if (0 != elapsedSec)
            {
                // ダブルクリック待ち合わせ時間内であればダブルクリック成功
                DoubleClickConfirm();
                // ダブルクリック判定中フラグと2回目のクリック待ち合わせ時間をクリア
                isDoubleClickStarting = false;
                elapsedSec = 0;
            }
        }
    }

    /// <summary>
    /// ダブルクリックカウンタメソッド
    /// <para>　ダブルクリック時において1回目のクリックから2回目のクリックが</para>
    /// <para>　される間隔をカウントする。一定時間経過で2回目のクリックを受け付けないようにする。</para>
    /// </summary>
    /// <returns>なし</returns>
    private IEnumerator Counter()
    {
        while (true)
        {
            if (0.1f <= elapsedSec)
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
    /// <para>　ダブルクリックが成立したらコールされる。</para>
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
