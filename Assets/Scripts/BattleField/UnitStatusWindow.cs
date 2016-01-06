using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitStatusWindow : MonoBehaviour
{
    /// <summary>
    /// HP
    /// </summary>
    private int hp;
    public int Hp
    {
        get { return hp; }
        set {
            if (HP_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                hp = value;
            }
        }
    }
    /// <summary>
    /// MP
    /// </summary>
    private int mp;
    public int Mp
    {
        get { return mp; }
        set
        {
            if (MP_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                mp = value;
            }
        }
    }
    /// <summary>
    /// SP
    /// </summary>
    private int sp;
    public int Sp
    {
        get { return sp; }
        set
        {
            if (SP_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                sp = value;
            }
        }
    }
    /// <summary>
    /// 経験値
    /// </summary>
    private int exp;
    public int Exp
    {
        get { return exp; }
        set
        {
            if (EXP_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                exp = value;
            }
        }
    }
    /// <summary>
    /// WT
    /// </summary>
    private int wt;
    public int Wt
    {
        get { return wt; }
        set
        {
            if (WT_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                wt = value;
            }
        }
    }
    /// <summary>
    /// STR等のパラメータ
    /// </summary>
    private int paramMax;
    public int ParamMax
    {
        get { return paramMax; }
        set
        {
            if (PARAM_MAX <= value)
            {
                value = 9999; // 最大値を越えた場合は最大値で固定
                paramMax = value;
            }
        }
    }
    /// <summary>
    /// 最大値の定数群
    /// </summary>
    private const int HP_MAX    = 9999; // HP最大値
    private const int MP_MAX    = 9999; // MP最大値
    private const int SP_MAX    = 9999; // SP最大値
    private const int EXP_MAX   = 9999; // 経験値最大値
    private const int WT_MAX    = 1000; // WT最大値
    private const int PARAM_MAX =  255; // STRとか
    /// <summary>
    /// 各パラメータのTextコンポ
    /// </summary>
    private Text compoHp;
    private Text compoMp;
    private Text compoSp;
    private Text compoExp;
    private Text compoWt;
    private Text compoStr;
    private Text compoVit;
    private Text compoDex;
    private Text compoAgi;
    private Text compoInt;
    private Text compoMnd;
    private Text compoRes;
    private Text compoLuc;
    
    void Start()
    {
        // 全パラメータ表示用のTextコンポを取得
        compoHp = this.gameObject.transform.FindChild("HP").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoMp = this.gameObject.transform.FindChild("MP").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoSp = this.gameObject.transform.FindChild("SP").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoExp = this.gameObject.transform.FindChild("EXP").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoWt = this.gameObject.transform.FindChild("WT").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoStr = this.gameObject.transform.FindChild("STR").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoVit = this.gameObject.transform.FindChild("VIT").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoDex = this.gameObject.transform.FindChild("DEX").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoAgi = this.gameObject.transform.FindChild("AGI").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoInt = this.gameObject.transform.FindChild("INT").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoMnd = this.gameObject.transform.FindChild("MND").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoRes = this.gameObject.transform.FindChild("RES").transform.FindChild("Value").gameObject.GetComponent<Text>();
        compoLuc = this.gameObject.transform.FindChild("LUC").transform.FindChild("Value").gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// ユニットパラメータ設定メソッド
    /// <para>　ユニットステータスウィンドウに表示するためのユニットパラメータを取得設定する。</para>
    /// </summary>
    /// <param name="unitParams">ユニットパラメータ</param>
    public void SetUnitParams(Dictionary<string, int> unitParams)
    {
        // 辞書からパラメータを取得し、Textコンポに設定する
        compoHp.text  = unitParams["Hp"].ToString();
        compoMp.text  = unitParams["Mp"].ToString();
        compoSp.text  = unitParams["Sp"].ToString();
        compoExp.text = unitParams["Exp"].ToString();
        compoWt.text  = unitParams["Wt"].ToString();
        compoStr.text = unitParams["Str"].ToString();
        compoVit.text = unitParams["Vid"].ToString();
        compoDex.text = unitParams["Dex"].ToString();
        compoAgi.text = unitParams["Agi"].ToString();
        compoInt.text = unitParams["Int"].ToString();
        compoMnd.text = unitParams["Mnd"].ToString();
        compoRes.text = unitParams["Res"].ToString();
        compoLuc.text = unitParams["Luc"].ToString();

        // フェードイン表示メソッドをコールしてウィンドウを表示
        var t = this.gameObject.GetComponent<ObjectFadeInOut>();
        t.CanvasGroupFadeInStart(16.0f, 0.01f, 2.0f, Enums.fadeFrom.fromLeft);
    }
}
