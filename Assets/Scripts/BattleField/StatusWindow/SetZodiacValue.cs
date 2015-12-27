using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 星座名表示クラス
/// <para>　ZodiacSelector.csからコールされ、ステータスウィンドウの</para>
/// <para>　星座表示Textに現在の星座名を表示する。</para>
/// </summary>
public class SetZodiacValue : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetZodiacValue() { }

    /// <summary>
    /// 星座名表示メソッド
    /// <para>　決定した星座名をステータスウィンドウ内に表示する。</para>
    /// </summary>
    /// <param name="seiza"></param>
	public void SetText (int seiza)
    {
        // Textコンポ取得および星座種別による振り分け
        var text = this.gameObject.GetComponent<Text>();
        switch (seiza)
        {
            case Defines.ARIES:         // 牡羊座
                text.text = "牡羊座[Aries]";
                break;
            case Defines.TAURUS:        // 牡牛座
                text.text = "牡牛座 [Tauros]";
                break;
            case Defines.GEMINI:        // 双子座
                text.text = "双子座 [Gemini]";
                break;
            case Defines.CANCER:        // 蟹座
                text.text = "蟹座 [Cancer]";
                break;
            case Defines.LEO:           // 獅子座
                text.text = "獅子座 [Leo]";
                break;
            case Defines.VIRGO:         // 乙女座
                text.text = "乙女座 [Virgo]";
                break;
            case Defines.LIBRA:         // 天秤座
                text.text = "天秤座 [Libra]";
                break;
            case Defines.SCORPIO:       // 蠍座
                text.text = "蠍座 [Scorpio]";
                break;
            case Defines.SAGITTARIUS:   // 射手座
                text.text = "射手座 [Sagittarius]";
                break;
            case Defines.CAPRICORN:     // 山羊座
                text.text = "山羊座 [Capricorn]";
                break;
            case Defines.AQUARIUS:      // 水瓶座
                text.text = "水瓶座 [Aquarius]";
                break;
            case Defines.PISCES:        // 魚座
                text.text = "魚座 [Pisces]";
                break;
            case Defines.OPHIUCHUS:     // 蛇遣座
                text.text = "蛇遣座 [Ophiuchus]";
                break;
            default:                    // 例外
                text.text = "? ? ?";
                break;
        }
	}	
}
