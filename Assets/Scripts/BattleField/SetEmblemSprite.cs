using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// エンブレム画像設定クラス
/// <para>　1P/2Pでユニットステータスウィンドウ内に表示するエンブレム画像を変更する。</para>
/// </summary>
public class SetEmblemSprite : MonoBehaviour
{
    /// <summary>1P側エンブレム画像</summary>
    private Sprite rampant;
    /// <summary>2P側エンブレム画像</summary>
    private Sprite passant;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetEmblemSprite() { }

    void Start()
    {
        // Imageコンポ取得
        var imageCompo = this.GetComponent<Image>();

        // 各画像を設定
        rampant = Resources.Load<Sprite>("Emblem/Rampant");
        passant = Resources.Load<Sprite>("Emblem/Passant");

        if (PhotonNetwork.isMasterClient)
        {
            // マスターの場合は1P時の画像
            imageCompo.sprite = rampant;
            // ランパルトは逆向きにする
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            // スレイブの場合は2P時の画像
            imageCompo.sprite = passant;        
        }
	}
}
