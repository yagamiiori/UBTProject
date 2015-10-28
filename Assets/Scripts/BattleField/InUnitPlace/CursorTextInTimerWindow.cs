using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// カーソルText点滅クラス
/// <para>　初期配置時において初期配置タイマーウィンドウ内のYOUテキストを点滅させる。</para>
/// <para>　アタッチGO：カーソル上部のText</para>
/// </summary>
public class CursorTextInTimerWindow : MonoBehaviour
{
    /// <summary>YOU文字のTextコンポ</summary>
    private Text cursorText;
    /// <summary>経過時間</summary>
    private float elapsedSec;
    private Color normalColor = new Color(255, 255, 255, 255);
    private Color invisibleColor = new Color(255, 255, 255, 0);

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CursorTextInTimerWindow() { }

    void Start()
    {
        // カーソルのTextコンポ取得
        cursorText = this.GetComponent<Text>();
    }

    void Update()
    {
        // カーソルのText「YOU」を点滅させる処理
        elapsedSec += Time.deltaTime;
        if (elapsedSec < 1.6f)
        {
            // 表示
            cursorText.color = normalColor;
        }
        else if (elapsedSec < 1.6f + 0.2f)
        {
            // 非表示
            cursorText.color = invisibleColor;
        }
        else if (elapsedSec < 1.6f + 0.2f + 0.2f)
        {
            // 表示
            cursorText.color = normalColor;
        }
        else if (elapsedSec < 1.6f + 0.2f + 0.2f + 0.2f)
        {
            // 非表示
            cursorText.color = invisibleColor;
        }
        else
        {
            // 表示
            cursorText.color = normalColor;

            // 全ての処理が完了したら経過時間を0に戻して再度実行する
            elapsedSec = 0;
        }
    }
}
