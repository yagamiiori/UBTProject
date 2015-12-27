using UnityEngine;
using System.Collections;

/// <summary>
/// ステータスウィンドウタイプ切り替えメソッド
/// <para>　ステータスウィンドウの透明ボタンからJudgeNowWindowSize()がコールされ、</para>
/// <para>　ステータスウィンドウのタイプを切り替える。</para>
/// </summary>
public class StatusWindowTypeChanger : MonoBehaviour
{
    /// <summary>
    /// ノーマルサイズ
    /// </summary>
    private GameObject normalSize;
    /// <summary>
    /// ミニサイズ
    /// </summary>
    private GameObject miniSize;

    void Start ()
    {
        // ノーマルサイズとミニサイズのステータスウィンドウのGOを取得
        normalSize = GameObject.Find("FieldStatusNormalSizeParent");
        miniSize = GameObject.Find("FieldStatusMiniSizeParent");
	}

    /// <summary>
    /// アクティブ状態のウィンドウサイズ判定メソッド
    /// <para>　現在どちらのウィンドウサイズがアクティブであるか判定する。</para>
    /// </summary>
    public void JudgeNowWindowSize()
    {
        // ノーマルサイズがアクティブになっている場合
        if (true == normalSize.activeSelf)
        {
            // ミニサイズをアクティブにする
            ActivateMiniSize();
        }
        else
        {
            // ノーマルサイズサイズをアクティブにする
            ActivateNormalSize();
        }
    }

    /// <summary>
    /// ノーマルサイズアクティブ化メソッド
    /// <para>　ノーマルサイズをアクティブ化し、ミニサイズを非アクティブ化する。</para>
    /// </summary>
    public void ActivateNormalSize()
    {
        normalSize.SetActive(true);
        miniSize.SetActive(false);
    }

    /// <summary>
    /// ミニサイズアクティブ化メソッド
    /// <para>　ミニサイズをアクティブ化し、ノーマルサイズを非アクティブ化する。</para>
    /// </summary>
    public void ActivateMiniSize()
    {
        miniSize.SetActive(true);
        normalSize.SetActive(false);
    }
}
