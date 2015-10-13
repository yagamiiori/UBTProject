using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// ルーム予約時ルームボタンカラー変更クラス
/// <para>　ルーム予約時にLogWindowManagerクラス内OnJoinedRoom()よりコールされ、</para>
/// <para>　ルームボタンの色を灰色化する。</para>
/// <para>　また、OnLeftRoom()からコールされた場合は灰色化を解除する。</para>
/// <para>　本スクリプトはCanvasへアタッチする。</para>
/// </summary>
public class RoomButtonColorGrayOut : MonoBehaviour
{
    /// <summary>全ルームボタン</summary>
    private GameObject[] roomButtons;
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>ルームボタンのImageコンポ</summary>
    private Image roomButtonImage;
    /// <summary>ルームボタンのTextコンポ</summary>
    private Text roomButtonText;
    /// <summary>予約中のルームボタンの色</summary>
    private Color grayOutColor;
    /// <summary>通常のルームボタンの色</summary>
    private Color defaultColor;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private RoomButtonColorGrayOut() { }

	void Start ()
    {
        // 全てのルームボタンGOを取得
        roomButtons = GameObject.FindGameObjectsWithTag("RoomButtons");

        // デフォルト時と予約時のルームボタンの色を作成
        defaultColor = Color.white;
        grayOutColor = Color.gray;
	}

    /// <summary>
    /// ルームボタンカラー変更メソッド
    /// <para>　予約中にルームボタンの色を変更する。
    /// </summary>
    public void ColorChangeReserved()
    {
        foreach (var t in roomButtons)
        {
            // 入室ボタンのImageとTextコンポを取得
            roomButtonImage = t.GetComponent<Image>();
            roomButtonText = t.GetComponentInChildren<Text>();

            // ルームボタンをグレイアウト
            roomButtonImage.color = grayOutColor;
            roomButtonText.color = grayOutColor;
        }
    }

    /// <summary>
    /// ルームボタンカラー初期化メソッド
    /// <para>　予約がキャンセルされた場合にルームボタンの色を初期化する。
    /// </summary>
    public void InitializeColorCanceled()
    {
        foreach (var t in roomButtons)
        {
            // 入室ボタンのImageとTextコンポを取得
            roomButtonImage = t.GetComponent<Image>();
            roomButtonText = t.GetComponentInChildren<Text>();

            // ルームボタンをグレイアウト
            roomButtonImage.color = defaultColor;
            roomButtonText.color = defaultColor;
        }
    }
}
