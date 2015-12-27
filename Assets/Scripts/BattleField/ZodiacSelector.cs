using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 星座決定クラス
/// <para>　星座をランダムで決定し、表示する。</para>
/// </summary>
public class ZodiacSelector : MonoBehaviour
{
    /// <summary>
    /// 星座種別
    /// </summary>
    public int zodiac = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private ZodiacSelector() { }

	void Start ()
    {
        // 星座をランダムで決定
        zodiac = Random.Range(1, 14);
        // スプライト設定メソッドをコールし、決定した星座の画像を表示する。
        SetSprite(zodiac);
	}

    /// <summary>
    /// スプライト設定メソッド
    /// <para>　星座の画像をSpriteに設定する。</para>
    /// </summary>
    /// <param name="zodiac">星座種別</param>
    private void SetSprite(int zodiac)
    {
        // Imageコンポを取得
        var t = this.gameObject.GetComponent<Image>();

        // 星座の元画像パスを指定
        string zodiacImage = "Zodiac/";
        // スプライト名を指定
        string spriteName = "z_" + zodiac;
        // 元画像からスプライト名の画像を取得する
        Sprite[] sprites = Resources.LoadAll<Sprite>(zodiacImage);
        Sprite decidedSprite = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));

        // 決定した星座の画像をスプライトに設定する
        t.sprite = decidedSprite;

        // ステータスウィンドウ内の星座テキストに決定した星座名を表示する
        var zodiacTextField = GameObject.Find("ZodiacType").GetComponent<SetZodiacValue>();
        zodiacTextField.SetText(zodiac);
    }
}
