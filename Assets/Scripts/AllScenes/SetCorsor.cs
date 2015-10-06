using UnityEngine;
using System.Collections;

public class SetCorsor : MonoBehaviour
{
    /// <summary>カーソル画像（インスペクタからのみ設定）</summary>
    [SerializeField]
    private Texture2D cursorSprite;

    /// <summary>コンストラクタ</summary>
    private SetCorsor() { }

	void Start ()
    {
        // カーソルが設定されてなければスクリプトを停止する
        if (!cursorSprite) this.enabled = false;
	}
	
	void Update ()
    {
        // マウスカーソルの画像を定義
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
	}
}
