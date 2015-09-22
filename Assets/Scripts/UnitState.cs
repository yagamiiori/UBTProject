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

    // ----------------------------------------
    // Awakeメソッド
    // ----------------------------------------
    void Awake()
    {
        // 永続オブジェクトに設定
        DontDestroyOnLoad(this);
    }

}
