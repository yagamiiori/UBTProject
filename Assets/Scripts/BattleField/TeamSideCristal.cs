using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// チームサイドクリスタル(TSC)画像設定クラス
/// <para>　ユニットステータスウィンドウ内の1P/2Pを見分けるための</para>
/// <para>　チームサイドクリスタル（TSC）の画像を設定する。</para>
/// </summary>
public class TeamSideCristal : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private TeamSideCristal() { }

	void Start ()
    {
        // Imageコンポ取得
        Image imageCompo = this.gameObject.GetComponent<Image>();
        Sprite sprite;

        if (PhotonNetwork.isMasterClient)
        {
            // マスタークライアント側は青色のクリスタル画像を設定する
            sprite = Resources.Load<Sprite>("TSC/GlassBall1");
            imageCompo.sprite = sprite;
        }
        else
        {
            // マスタークライアント側は赤色のクリスタル画像を設定する
            sprite = Resources.Load<Sprite>("TSC/GlassBall2");
            imageCompo.sprite = sprite;        
        }
	}
}
