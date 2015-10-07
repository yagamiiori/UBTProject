using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// SE再生クラス（Loginシーン）
/// <para>　SEのボリューム調整を行う。</para>
/// </summary>
public class SePlayerForAllScene : MonoBehaviour
{
    /// <summary>BGMボリュームスライダーコンポ（スライダーにアタッチされたBgmVolumeChangeOnSliderから設定される）</summary>
    public Slider VolumeSlider;
    /// <summary>BGMボリュームスライダーの音量（各シーンのスライダーオブジェクトから操作される）</summary>
    private float volumeSliderValue = 0.1f;
    public float VolumeSliderValue
    {
        get { return volumeSliderValue; }
        set
        {
            if (0 > value) value = 0;
            if (1 < value) value = 1.0f;
            volumeSliderValue = value;
        }
    }
    /// <summary>オーディオソースコンポ（BgmVolumeChangeOnSliderより参照されるためpublic）</summary>
    public AudioSource audioSource;

    /// <summary>コンストラクタ</summary>
    public SePlayerForAllScene() { }

    void Start()
    {
        // オーディオコンポ取得
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // スライダーの値をボリュームに設定
        if (audioSource && VolumeSlider) audioSource.volume = VolumeSlider.value;
    }
}
