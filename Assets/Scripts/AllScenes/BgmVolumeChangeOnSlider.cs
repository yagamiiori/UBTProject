using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 各シーンのスライダーにアタッチされ、GameManager内のボリュームスライダーフィールドに自身を代入する
/// </summary>
public class BgmVolumeChangeOnSlider : MonoBehaviour
{
    /// <summary>BGMプレイヤーコンポ</summary>
    private BgmPlayerForAllScene bgmPlayerComponet;

    /// <summary>コンストラクタ</summary>
    private BgmVolumeChangeOnSlider() { }

	void Start ()
    {
        // BGMプレイヤーコンポを取得
        bgmPlayerComponet = GameObject.Find("PlayersParent").transform.FindChild("BGMPlayer").gameObject.GetComponent<BgmPlayerForAllScene>();

        // 自身のスライダーコンポをBGMプレイヤーのフィールドに設定
        bgmPlayerComponet.VolumeSlider = this.gameObject.GetComponent<Slider>();

        // BGMプレイヤーの現在のボリュームをシーン開始時に取得し、スライダー値と同期させる
        this.gameObject.GetComponent<Slider>().value = bgmPlayerComponet.audioSource.volume;
	}
}
