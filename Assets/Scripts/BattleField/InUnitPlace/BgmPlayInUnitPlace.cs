using UnityEngine;
using System.Collections;

/// <summary>
/// 初期配置時のGGM再生クラス
/// <para>　ユニットの初期配置BGMを再生する。</para>
/// </summary>
public class BgmPlayInUnitPlace : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BgmPlayInUnitPlace() { }

	void Start ()
    {
        // 初期配置時のBGMを再生
        var bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<BgmPlayerForAllScene>();
        var bgm = Resources.Load<AudioClip>("Sounds/BGM/InBattleScene/InUnitPlace/UnitPlaceSelect");
        bgmPlayer.BgmSet(bgm);
        bgmPlayer.BgmStopNow();
        bgmPlayer.BgmStart();
    }
}
