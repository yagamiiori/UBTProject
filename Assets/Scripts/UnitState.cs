using UnityEngine;
using System.Collections;

public class UnitState : Photon.MonoBehaviour
{
    public int unitID = Defines.NON_VALUE;           // ユニットID
    public int classType = Defines.NON_VALUE;        // クラスタイプ
    public int ability_A = Defines.NON_VALUE;        // アビリティA（ユーザーアビリティA）
    public int ability_B = Defines.NON_VALUE;        // アビリティB（ユーザーアビリティB）
    public int ability_C = Defines.NON_VALUE;        // アビリティC（ランダムアビリティ）
    public int ability_D = Defines.NON_VALUE;        // アビリティD（ドロップアビリティ）
    public int ability_E = Defines.NON_VALUE;        // アビリティE（？？？アビリティ）
    public int weaponType = Defines.NON_VALUE;       // 武器タイプ
    public int element = Defines.ELEM_FIRE;          // エレメント（デフォルト：火）
    public int sex = Defines.NON_VALUE;              // 性別
    public int color = Defines.NON_VALUE;            // カラーパレット（※とりあえず未使用）
    public int hp = Defines.NON_VALUE;               // HP
    public int mp = Defines.NON_VALUE;               // MP
    public int workType = Defines.NON_VALUE;         // 歩行タイプ
    public int expValue = Defines.NON_VALUE;         // 経験値
    public int wt = Defines.NON_VALUE;               // WT
    public int brave = Defines.NON_VALUE;            // Brave
    public int fath = Defines.NON_VALUE;             // Fath
    public int PysicsDef = Defines.NON_VALUE;        // 物理防御力
    public int MagicDef = Defines.NON_VALUE;         // 魔法防御力
    public int attack;                               // 基本攻撃力
    public int Equipment_Hand_R;                     // 装備 - 右手
    public int Equipment_Hand_L;                     // 装備 - 左手
    public int Equipment_Head;                       // 装備 - 頭
    public int Equipment_Body;                       // 装備 - 体
    public int Equipment_Foot;                       // 装備 - 足
    public int Equipment_Accessory;                  // 装備 - アクセサリ
    public string unitName = "";                     // ユニット名
    public float correct_W;                          // ユニット固有ダメージ補正率 - 武器
    public float correct_M;                          // ユニット固有ダメージ補正率 - 魔法
    public bool promJud = false;                     // プロモーション可否判定フラグ

    /// <summary>コンストラクタ</summary>
    private UnitState() { }

    void Awake()
    {
        // 永続オブジェクトに設定
        DontDestroyOnLoad(this);

        // 全フィールド初期化メソッドをコール
        InitializeFields();
    }

    /// <summary>
    /// 全フィールド初期化メソッド
    /// <para>　ユニットステータスの全てのフィールドを初期化する</para>
    /// </summary>
    void InitializeFields()
    {
        unitID = Defines.NON_VALUE;             // ユニットID
        classType = Defines.NON_VALUE;          // クラスタイプ
        ability_A = Defines.NON_VALUE;          // アビリティA（ユーザーアビリティA）
        ability_B = Defines.NON_VALUE;          // アビリティB（ユーザーアビリティB）
        ability_C = Defines.NON_VALUE;          // アビリティC（ランダムアビリティ）
        ability_D = Defines.NON_VALUE;          // アビリティD（ドロップアビリティ）
        ability_E = Defines.NON_VALUE;          // アビリティE（？？？アビリティ）
        weaponType = Defines.NON_VALUE;         // 武器タイプ
        element = Defines.ELEM_FIRE;            // エレメント（デフォルト：火）
        sex = Defines.NON_VALUE;                // 性別
        color = Defines.NON_VALUE;              // カラーパレット（※とりあえず未使用）
        hp = Defines.NON_VALUE;                 // HP
        mp = Defines.NON_VALUE;                 // MP
        workType = Defines.NON_VALUE;           // 歩行タイプ
        expValue = Defines.NON_VALUE;           // 経験値
        wt = Defines.NON_VALUE;                 // WT
        brave = Defines.NON_VALUE;              // Brave
        fath = Defines.NON_VALUE;               // Fath
        PysicsDef = Defines.NON_VALUE;          // 物理防御力
        MagicDef = Defines.NON_VALUE;           // 魔法防御力
        attack = Defines.NON_VALUE;             // 基本攻撃力
        Equipment_Hand_R = Defines.NON_VALUE;   // 装備 - 右手
        Equipment_Hand_L = Defines.NON_VALUE;   // 装備 - 左手
        Equipment_Head = Defines.NON_VALUE;     // 装備 - 頭
        Equipment_Body = Defines.NON_VALUE;     // 装備 - 体
        Equipment_Foot = Defines.NON_VALUE;     // 装備 - 足
        Equipment_Accessory = Defines.NON_VALUE;// 装備 - アクセサリ
        unitName = "Input Name";                // ユニット名
        correct_W = Defines.NON_VALUE;          // ユニット固有ダメージ補正率 - 武器
        correct_M = Defines.NON_VALUE;          // ユニット固有ダメージ補正率 - 魔法
        promJud = false;                        // プロモーション可否判定フラグ
    }
}
