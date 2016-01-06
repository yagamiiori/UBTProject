using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// タクティカルシチュエーション（TacticalSituation）ゲージ増減管理クラス
/// <para>　戦況に応じてTSゲージを増減させる。</para>
/// <para>　アタッチGO：Canvas_TsGage->Parent</para>
/// </summary>
public class TsGage : MonoBehaviour
{
    /// <summary>
    /// 1P側のゲージスプライト
    /// </summary>
    private Image barImage1P;
    /// <summary>
    /// 2P側のゲージスプライト
    /// </summary>
    private Image barImage2P;
    /// <summary>
    /// 1P側のゲージ量
    /// </summary>
    private float barValue1P = 0;
    public float BarValue1P
    {
        get { return barValue1P; }
        set
        {
            if (1.204f <= value)
            {
                // ゲージ量の最大値は1.2f
                value = 1.204f;
            }
            else if(0 >= value)
            {
                // ゲージ量の最小値は0
                value = 0;
            }
            barValue1P = value;
        }
    }
    /// <summary>
    /// 2P側のゲージス量
    /// </summary>
    private float barValue2P = 0;
    public float BarValue2P
    {
        get { return barValue2P; }
        set
        {
            if (1.204f <= value)
            {
                // ゲージ量の最大値は1.2f
                value = 1.204f;
            }
            else if (0 >= value)
            {
                // ゲージ量の最小値は0
                value = 0;
            }
            barValue2P = value;
        }
    }
    /// <summary>
    /// ゲージの初期値（インスペクタから設定可能）
    /// </summary>
    [SerializeField]
    private float defaultValue = 0.602f;
    /// <summary>
    /// 1P側ゲージImageコンポのローカルスケール
    /// </summary>
    private Vector3 barScale1P = new Vector3(1.2f, 1.2f, 1.2f);
    /// <summary>
    /// 2P側ゲージImageコンポのローカルスケール
    /// </summary>
    private Vector3 barScale2P = new Vector3(1.2f, 1.2f, 1.2f);

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private TsGage() { }

	void Start ()
    {
        // TSゲージのImageコンポを取得
        barImage1P = this.gameObject.transform.FindChild("BarParent_1P").transform.GetComponentInChildren<Image>();
        barImage2P = this.gameObject.transform.FindChild("BarParent_2P").transform.GetComponentInChildren<Image>();

        // ゲージ量を初期化
        BarValue1P = defaultValue;
        barValue2P = defaultValue;
    }
	
	void Update ()
    {
        // 1P側ゲージの増減処理（スケーリング）
        barScale1P.x = BarValue1P;
        barScale1P.y = 1.2f;
        barScale1P.z = 1.2f;
        barImage1P.transform.localScale = barScale1P;

        // 2P側ゲージの増減処理（スケーリング）
        barScale2P.x = BarValue2P;
        barScale2P.y = 1.2f;
        barScale2P.z = 1.2f;
        barImage2P.transform.localScale = barScale2P;
    }

    /// <summary>
    /// TSゲージ値取得メソッド
    /// <para>　TSゲージ量を取得する。</para>
    /// </summary>
    /// <param name="teamSide">取得するサイド（1P/2P）</param>
    /// <returns></returns>
    public float GetTsValue(int teamSide)
    {
        if (Defines.TEAMSIDE_1P == teamSide)
        {
            // 1P側のTS値
            return BarValue1P;
        }
        else
        {
            // 2P側のTS値
            return BarValue2P;
        }
    }

    /// <summary>
    /// TSゲージ値設定メソッド
    /// <para>　TSゲージ量を設定する。</para>
    /// </summary>
    /// <param name="teamSide">設定する値とサイド（1P/2P）</param>
    /// <returns></returns>
    public void SetTsValue(float value, int teamSide)
    {
        if (Defines.TEAMSIDE_1P == teamSide)
        {
            // 1P側のTS値を設定する
            BarValue1P += value;
        }
        else
        {
            // 2P側のTS値を設定する
            BarValue2P += value;
        }
    }
}
