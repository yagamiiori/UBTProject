using UnityEngine;
using System.Collections;

/// <summary>
/// ソルジャークラス
/// <para>　ソルジャーの能力を有する。</para>
/// </summary>
public class Soldier : UnitBase
{
    /// <summary>コンストラクタ</summary>
    private Soldier() { }

    void Awake()
    {
        // 永続オブジェクトに設定
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // クラス固有パラメータの設定および初期化
        InitializeFields();
    }

    void Update()
    {

    }

    /// <summary>
    /// パラメータ初期化メソッド
    /// <para>　ユニットステータスの中でクラス固有のパラメータ、および</para>
    /// <para>　ランダムで決定するパラメータを初期化する。</para>
    /// <para>　ユニット名やアビリティ、エレメントなどプレイヤーが決定した情報の設定は</para>
    /// <para>　SettingsUnitParam.csにて行う。</para>
    /// </summary>
    public void InitializeFields()
    {
        classType = Defines.SOLDLER;
        weaponType = Defines.UNT_SWORD;
        sex = Defines.UNT_MALE;
        workType = Defines.UNT_KEIHO;
        promJud = false;
        hp = 5000 + Random.Range(0, 501);
        mp = 1200 + Random.Range(0, 121);
        sp = 1000 + Random.Range(0, 201);
        wt = 62;
        exp = 0;
        str = 500 + Random.Range(0, 51);
        vit = 500 + Random.Range(0, 51);
        dex = 400 + Random.Range(0, 51);
        agi = 400 + Random.Range(0, 51);
        itg = 300 + Random.Range(0, 51);
        mnd = 300 + Random.Range(0, 51);
        res = 400 + Random.Range(0, 51);
        luc = 200 + Random.Range(0, 51);
    }
}
