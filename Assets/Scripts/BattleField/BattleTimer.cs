using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// ゲーム経過時間表示クラス
/// <para>　ステータスウィンドウ内にゲーム経過時間を表示する。</para>
/// </summary>
public class BattleTimer : MonoBehaviour
{
    /// <summary>
    /// 時間表示用のテキストコンポ
    /// </summary>
    public Text timerText;
    /// <summary>
    /// 経過時間
    /// </summary>
    public float elapsedTime;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BattleTimer() { }

	void Start ()
    {
        // 時間表示用のテキストコンポを取得
        timerText = this.gameObject.GetComponent<Text>();
	}
	
	void Update ()
    {
        // 経過時間をカウント
        elapsedTime += Time.deltaTime;

        // カウントした時間を表示
        timerText.text = Mathf.Floor(elapsedTime / 3600f).ToString("00") + " : " + Mathf.Floor((elapsedTime / 60f) % 60f).ToString("00");
	}
}
