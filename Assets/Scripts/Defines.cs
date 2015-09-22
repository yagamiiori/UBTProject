
////////////////////////////////////////////////////////////////////////////////////////
// 定数定義クラス
////////////////////////////////////////////////////////////////////////////////////////
public static class Defines
{
    // 汎用
    public const int VALUE_OFF = 0;     // ON
    public const int VALUE_ON  = 1;     // OFF

    // ユニットID（シーン無所属）
    public const int ID_1 = 1;     // ID 1
    public const int ID_2 = 2;     // ID 2
    public const int ID_3 = 3;     // ID 3
    public const int ID_4 = 4;     // ID 4
    public const int ID_5 = 5;     // ID 5
    public const int ID_6 = 6;     // ID 6
    public const int ID_7 = 7;     // ID 7
    public const int ID_8 = 8;     // ID 8
    public const int ID_9 = 9;     // ID 9
    public const int ID_10 = 10;   // ID 10
    public const int ID_11 = 11;   // ID 11
    public const int ID_12 = 12;   // ID 12
    public const int ID_13 = 13;   // ID 13
    public const int ID_14 = 14;   // ID 14
    public const int ID_15 = 15;   // ID 15
    public const int ID_16 = 16;   // ID 16

    // クラス（全シーン共通）
    public const int NON_VALUE = 0;     // 設定なし
    public const int SOLDLER   = 1;     // ソルジャー
    public const int WIZARD    = 2;     // ウィザード
    public const int KNIGHT    = 3;     // ナイト
    public const int ARCHER    = 4;     // アーチャー
    public const int SAMURAI   = 5;     // 侍
    public const int RICH      = 6;     // リッチ
    public const int CLERIC    = 7;     // クレリック
    public const int FAERY     = 8;     // フェアリー
    public const int WITCH     = 9;     // ウィッチ
    public const int ANGEL     = 10;    // エンジェルナイト
    public const int LORD      = 11;    // ロード（ソルジャープロモーション）
    public const int NECKRO    = 12;    // ネクロマンサー（ウィザードプロモーション）
    public const int PALADIN   = 13;    // パラディン（ナイトプロモーション）
    public const int EMPEROR   = 14;    // 雷帝（T.E）（アーチャープロモーション）
    public const int KENSEI    = 15;    // 剣聖（侍プロモーション）
    public const int DELEMENT  = 16;    // ダークエレメント（リッチプロモーション）
    public const int PRINCESS  = 17;    // プリンセス（クレリックプロモーション）
    public const int BANGY     = 18;    // 死の妖精（バンジー）（フェアリープロモーション）
    public const int ARCWITCH  = 19;    // アークウィッチ（ウィッチプロモーション）
    public const int FALLDOWN  = 20;    // 堕天使（エンジェルナイトプロモーション）

    // ゲーム言語
    public const int LANGUAGE_JPN = 1;  // 日本語
    public const int LANGUAGE_ENG = 2;  // 英語

    // ユニット数（オプションセレクトシーン）
    public const int OPT_UNITS_5   = 5;     // ユニット数5
    public const int OPT_UNITS_8   = 8;     // ユニット数8
    public const int OPT_UNITS_10  = 10;    // ユニット数10
    public const int OPT_UNITS_14  = 14;    // ユニット数14
    public const int OPT_UNITS_16  = 16;    // ユニット数16
    public const int OPT_UNITS_MAX = 16;    // 最大ユニット数（16固定）

    // 持ち時間（オプションセレクトシーン）
    public const int OPT_HAVETIME_10 = 10;   // 10秒
    public const int OPT_HAVETIME_20 = 20;   // 20秒
    public const int OPT_HAVETIME_30 = 30;   // 30秒
    public const int OPT_HAVETIME_40 = 40;   // 40秒
    public const int OPT_HAVETIME_50 = 50;   // 50秒
    public const int OPT_HAVETIME_60 = 60;   // 60秒

    // 性別（ユニットセレクトシーン）
    public const int UNT_MALE    = 1;        // 男性
    public const int UNT_FEMALE  = 2;        // 女性
    public const int UNT_UNKNOWN = 3;        // 不明

    // タイプ（ユニットセレクトシーン）
    public const int UNT_KEIHO = 1;     // 軽歩
    public const int UNT_DONPO = 2;     // 鈍歩
    public const int UNT_HIKOU = 3;     // 飛行
    public const int UNT_WORP  = 4;     // ワープ

    // 武器タイプ（ユニットセレクトシーン）※未使用
    public const int UNT_SWORD  = 1;     // 剣
    public const int UNT_SPIRE  = 2;     // 槍
    public const int UNT_ALLOW  = 3;     // 弓
    public const int UNT_KATANA = 4;     // 刀
    public const int UNT_STAFF  = 5;     // 杖
    public const int UNT_MEISE  = 6;     // メイス
    public const int UNT_SUDE   = 7;     // 素手

    // 設定なし（アビリティセレクトシーン限定）
    public const int ABL_NON_VALUE = 100;    // 設定なし

    // アビリティ（アビリティセレクトシーン）
    public const int ABL_NO_ABILITY = 0;   // アビリティなし
    public const int ABL_ON_ABILITY = 1;   // アビリティあり

    // アビリティID - アタック系（アビリティセレクトシーン）
    public const int ABL_POWERUP    = 1;   // 攻撃力Up
    public const int ABL_DIFFENCEUP = 2;   // 防御力Up
    public const int ABL_MOVEPLUS   = 3;   // ムーブプラス
    public const int ABL_HCOUNTER   = 4;   // 見切り青眼
    public const int ABL_TEREPORT   = 5;   // ダテレポ

    // 属性（バトルフィールドシーン）
    public const int ELEM_FIRE     = 1;    // 炎
    public const int ELEM_WATER    = 2;    // 水
    public const int ELEM_EARTH    = 3;    // 土
    public const int ELEM_WIND     = 4;    // 風
    public const int ELEM_DIVINE   = 5;    // 神聖
    public const int ELEM_DARKNESS = 6;    // 暗黒

    // プロモーション判定（バトルフィールドシーン）
    public const int BTL_PROMO_OFF = 0;     // プロモーション未実施
    public const int BTL_PROMO_ON  = 1;     // プロモーション実施済み

    // クラス毎の基本ダメージ値（バトルフィールドシーン）
    public const int BTL_DMG_SOL = 300;     // ソルジャー
    public const int BTL_DMG_WIZ = 100;     // ウィザード
    public const int BTL_DMG_KNT = 300;     // ナイト
    public const int BTL_DMG_ARC = 230;     // アーチャー
    public const int BTL_DMG_DRG = 200;     // ドラグーン
    public const int BTL_DMG_RIC = 100;     // リッチ
    public const int BTL_DMG_CLR = 50;      // クレリック
    public const int BTL_DMG_FAE = 160;     // フェアリー
    public const int BTL_DMG_WIT = 150;     // ウィッチ
    public const int BTL_DMG_ANG = 250;     // エンジェルナイト

    // パネルタイプ（バトルフィールドシーン）
    public const int BTL_PANEL_KUSA  = 1;     // 草
    public const int BTL_PANEL_KONK  = 2;     // コンクリート
    public const int BTL_PANEL_TUCHI = 3;     // 土
    public const int BTL_PANEL_KI    = 4;     // 木
    public const int BTL_PANEL_MIZU  = 5;     // 水
    public const int BTL_PANEL_ISI   = 6;     // 石
    public const int BTL_PANEL_DAIRI = 7;     // 大理石
    public const int BTL_PANEL_NUNO  = 8;     // 布
    public const int BTL_PANEL_YUKI  = 9;     // 雪

    // ハイト（バトルフィールドシーン）
    public const int BTL_HYTE_1  = 1;     // ハイト1
    public const int BTL_HYTE_2  = 2;     // ハイト2
    public const int BTL_HYTE_3  = 3;     // ハイト3
    public const int BTL_HYTE_4  = 4;     // ハイト4
    public const int BTL_HYTE_5  = 5;     // ハイト5
    public const int BTL_HYTE_6  = 6;     // ハイト6
    public const int BTL_HYTE_7  = 7;     // ハイト7
    public const int BTL_HYTE_8  = 8;     // ハイト8
    public const int BTL_HYTE_9  = 9;     // ハイト9
    public const int BTL_HYTE_10 = 10;    // ハイト10
}

