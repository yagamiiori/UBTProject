using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// スキルウィンドウ書き込みクラス（初期配置選択時）
/// <para>　初期配置選択時においてスキルウィンドウを表示し、</para>
/// <para>　「SelectPlace」文字列を書き込む</para>
/// </summary>
public class WriteToSkillWindow : MonoBehaviour
{
    /// <summary>スキルウィンドウの管理クラス</summary>
    private SkillWindowActiveManager skillWindow;
    /// <summary>スキルウィンドウのTextコンポ</summary>
    private Text[] skillWindowText;
    /// <summary>経過した秒</summary>
    private float elapsedSec = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private WriteToSkillWindow() { }

	void Start()
    {
        // スキルウィンドウのアクティブ管理クラス、およびTextコンポを取得
        skillWindow = GameObject.Find("Canvas_SkillWindow").GetComponent<SkillWindowActiveManager>();
        skillWindow.skillWindowParentGO.SetActive(true);
        skillWindowText = GameObject.Find("Canvas_SkillWindow").GetComponentsInChildren<Text>();
    }

    void FixedUpdate()
    {
        // 経過時間を測定
        elapsedSec += Time.deltaTime;

        // 点滅を繰り返す
        if (elapsedSec < 1.0f)
        {
            // 初期配置中はスキルウィンドウに「SelectPlace」を書き込む
            skillWindowText[0].text = "SelectPlace";
        }
        else if (elapsedSec <= 1.0f + 0.4f)
        {
            // スキルウィンドウを初期化
            skillWindowText[0].text = "";
        }
        else if (elapsedSec >= 1.5f)
        {
            // 経過時間を初期化
            elapsedSec = 0;
        }
    }
}
