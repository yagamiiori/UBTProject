using UnityEngine;
using System.Collections;

// ==========================================================================================
// メソッド名：ソルジャークラス on Battle Field
// 
// 
// 
// 
// ==========================================================================================
public class Soldler :
    Photon.MonoBehaviour,
    IBattleField                        // バトルIF
{
    private GameManager gameManager;    // マネージャコンポ
    private UnitState unitstate;        // ユニットステートコンポ
//    public int myPanelType;                // 自分が立っているパネルのタイプ
//    public int targetPanelType;            // 敵が立っているパネルのタイプ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        this.gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ユニットステートコンポ取得
        this.unitstate = this.gameObject.GetComponent<UnitState>();

        // パラメータ設定メソッドをコール
        SettingParams();
	}

    // ----------------------------------------
    // Updateメソッド
    // ----------------------------------------
    void Update()
    {
	
	}

    // -----------------------------
    // ユニットパラメータ設定メソッド（IFメソッド）
    // 機能：各ユニットの固有パラメータを設定する。
    // 　　　設定先はユニットステートコンポを指定する。
    // -----------------------------
    public void SettingParams()
    {
        unitstate.unitID = Defines.ID_1;                // ユニットID
        unitstate.classType = Defines.SOLDLER;          // クラスID
        unitstate.ability_A = 0;                        // アビリティID
        unitstate.element = Random.Range(1, 5);       // 属性ID
        unitstate.sex = Defines.UNT_MALE;               // 性別ID
        unitstate.promJud = false;                      // プロモーション可否判定フラグ
        unitstate.hp = 500 + Random.Range(0, 201);      // HP
        unitstate.mp = 0;                               // MP
        unitstate.attack = Defines.BTL_DMG_SOL;         // 基本攻撃ダメージ
        unitstate.workType = Defines.UNT_KEIHO;         // タイプ（軽歩/鈍歩/飛行）
        unitstate.wt = 50;                              // WT
        unitstate.brave = 50 + (Random.Range(0, 31));   // Brave - 物理回避率
        unitstate.fath = 20 + (Random.Range(0, 31));    // Fath - 魔法回避率
        unitstate.correct_W = 0f;                       // ユニット固有ダメージ補正率 - 武器
        unitstate.correct_M = 0f;                       // ユニット固有ダメージ補正率 - 魔法
    }

    // -----------------------------
    // ダメージメソッド（IFメソッド）
    // 機能：攻撃された場合、相手から呼び出される
    // 　　　ダメージを受けた時の食らいアニメを表示する
    // 　　　なお、ダメージ処理自体は攻撃側が行う
    // -----------------------------
    public void ApplyDamage()
    {
    }

    // -----------------------------
    // 通常攻撃メソッド（IFメソッド）
    // 機能：たたかうコマンドによる通常攻撃を行う
    // 　　　与えるダメージを算出した後、相手ユニットの
    // 　　　ApplyDamageメソッドをコールする
    // -----------------------------
    public void NormalAttack()
    {
        // クリティカル判定（クリティカル発生率1/10）
        int criticalDamage = 0;
        int critical = Random.Range(1, 11);

        // クリティカル成立時はダメージに+150
        if (3 == critical) criticalDamage = 150;

        // 最終ダメージ値決定
        // 基本ダメージ + クリティカルダメージ
        unitstate.attack = unitstate.attack + criticalDamage;
    }

}
