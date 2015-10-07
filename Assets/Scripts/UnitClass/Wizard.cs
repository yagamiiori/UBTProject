using UnityEngine;
using System.Collections;

/// <summary>
/// ウィザードクラス
/// <para>　ウィザードの能力を有する。</para>
/// </summary>
public class Wizard : BaseClassOnUnit
{
    /// <summary>ユニットID</summary>
    public int unitID;
    /// <summary>クラス</summary>
    public int classType;
    /// <summary>アビリティA</summary>
    public int ability_A;
    /// <summary>アビリティB</summary>
    public int ability_B;
    /// <summary>武器タイプ</summary>
    public int weaponType;
    /// <summary>エレメント</summary>
    public int element;
    /// <summary>性別</summary>
    public int sex;
    /// <summary>HP</summary>
    public int hp;
    /// <summary>MP</summary>
    public int mp;
    /// <summary>歩行タイプ</summary>
    public int workType;
    /// <summary>経験値</summary>
    public int expValue;
    /// <summary>WT</summary>
    public int wt;
    /// <summary>物理攻撃力</summary>
    public int physicsAttack;
    /// <summary>魔法攻撃力</summary>
    public int magicAttack;
    /// <summary>物理防御力</summary>
    public int PysicsDeffence;
    /// <summary>魔法防御力</summary>
    public int MagicDeffence;
    /// <summary>ユニット名</summary>
    public string unitName = "";
    /// <summary>ユニット固有ダメージ補正率 - 物理</summary>
    public float correct_W;
    /// <summary>ユニット固有ダメージ補正率 - 魔法</summary>
    public float correct_M;
    /// <summary>プロモーション可否判定</summary>
    public bool promJud;

    /// <summary>コンストラクタ</summary>
    private Wizard() { }

    void Awake()
    {
        // 永続オブジェクトに設定
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // 全フィールド初期化メソッドをコール
        InitializeFields();
    }

    void Update()
    {

    }

    /// <summary>
    /// 全フィールド初期化メソッド
    /// <para>　ユニットステータスの全てのフィールドを初期化する</para>
    /// </summary>
    void InitializeFields()
    {
        unitID = Defines.NON_VALUE;
        classType = Defines.WIZARD;
        ability_A = Defines.NON_VALUE;
        ability_B = Defines.NON_VALUE;
        weaponType = Defines.UNT_STAFF;
        element = Defines.ELEM_FIRE;
        sex = Defines.UNT_MALE;
        hp = 410 + Random.Range(0, 81);
        mp = 220 + Random.Range(0, 112);
        workType = Defines.UNT_KEIHO;
        expValue = 0;
        wt = 68;
        physicsAttack = 60 + Random.Range(0, 31);
        magicAttack = 130 + Random.Range(0, 31);
        PysicsDeffence = 110 + Random.Range(0, 31);
        MagicDeffence = 160 + Random.Range(0, 31);
        unitName = "Input Name";
        correct_W = 20 + Random.Range(0, 31); ;
        correct_M = 30 + Random.Range(0, 31);
        promJud = false;
    }
}
