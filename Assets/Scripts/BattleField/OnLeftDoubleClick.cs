using UnityEngine;
using System.Collections;

/// <summary>
/// マウス左ボタンダブルクリック判定クラス
/// <para>　マウス左ボタンのダブルクリックがされたか否かを判定する。</para>
/// <para>　アタッチGO：Canvas</para>
/// </summary>
public class OnLeftDoubleClick : MonoBehaviour
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
    private OnLeftDoubleClick() { }

    void Start()
    {
        // メインカメラを取得
        mainCamera = GameObject.Find("Main Camera");
    }

	void Update ()
    {
        // 左ダブルクリック - 1回目のクリックを判定
        if (!isDoubleClickStarting && Input.GetMouseButtonUp(0))
        {
            if (0 == elapsedSec)
            {
                // ダブルクリック開始フラグON
                isDoubleClickStarting = true;
                // カウントメソッドを起動し、2回目のクリックを待つ
                StartCoroutine(Counter());
            }
        }
        // 左ダブルクリック - 2回目のクリックを判定
        if (isDoubleClickStarting && Input.GetMouseButtonDown(0))
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
        // カメラをステージ中央に瞬間移動させる
        mainCamera.transform.position = new Vector3(3.56f, 6.25f, -8.24f);
    }
}
