using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 各シーンのスライダーにアタッチされ、GameManager内のボリュームスライダーフィールドに自身を代入する
/// </summary>
public class SeVolumeChangeOnSlider : MonoBehaviour
{
    /// <summary>BGMプレイヤーコンポ</summary>
    private SePlayerForAllScene sePlayerComponet;

    /// <summary>コンストラクタ</summary>
    private SeVolumeChangeOnSlider() { }

    void Start()
    {
        // SEプレイヤーコンポを取得
        sePlayerComponet = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<SePlayerForAllScene>();

        // 自身のスライダーコンポをBGMプレイヤーのフィールドに設定
        sePlayerComponet.VolumeSlider = this.gameObject.GetComponent<Slider>();

        // SEプレイヤーの現在のボリュームをシーン開始時に取得し、スライダー値と同期させる
        this.gameObject.GetComponent<Slider>().value = sePlayerComponet.audioSource.volume;
    }
}
