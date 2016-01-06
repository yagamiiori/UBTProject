
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
    public const int ABL_MRANGEUP   = 6;   // 魔法範囲Up

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

    // ステータス異常種別（バトルフィールドシーン）
    public const int STATUS_NORMAL     = 1;    // ステータス異常なし
    public const int STATUS_FMOVE      = 2;    // ファストムーブ（WTが早くなっている状態）
    public const int STATUS_SWORD      = 3;    // ソード（物理攻撃力が上がっている状態）
    public const int STATUS_SEALD      = 4;    // シールド（物理防御力補正が上がっている状態
    public const int STATUS_ENCHANT    = 5;    // エンチャント（魔法攻撃力が上がっている上昇）
    public const int STATUS_BARRIER    = 6;    // バリア（全属性に対する魔法防御力に補正がついている状態。デバリアで解除）
    public const int STATUS_PATCHFIRE  = 7;    // ファイアパッチ  （炎に対する魔法防御力が上がっている状態）
    public const int STATUS_PATCHWATER = 8;    // ウォーターパッチ（水に対する魔法防御力が上がっている状態）
    public const int STATUS_PATCHEARTH = 9;    // アースパッチ    （土に対する魔法防御力が上がっている状態）
    public const int STATUS_PATCHWIND  = 10;   // ウィンドパッチ  （風に対する魔法防御力が上がっている状態）
    public const int STATUS_PATCHLIGHT = 11;   // ライトパッチ    （聖に対する魔法防御力が上がっている状態）
    public const int STATUS_PATCHDARK  = 12;   // ダークパッチ    （暗黒に対する魔法防御力が上がっている状態）
    public const int STATUS_BLAIN      = 13;   // 暗闇（命中率が半減している状態）
    public const int STATUS_STOP       = 14;   // ストップ（数ターン動けない状態）
    public const int STATUS_INSANITY   = 15;   // 混乱（コマンドオーダーできない状態）
    public const int STATUS_STONE      = 16;   // 石化（石化している状態）
    public const int STATUS_DEAD       = 17;   // 死亡（死亡して倒れている状態）
    public const int STATUS_UNDEAD     = 18;   // アンデッド（死亡しているが動ける状態）

    // 勝利判定
    public const int WINNER_1P = 1;    // 1P側（マスタークライアント）勝利
    public const int WINNER_2P = 2;    // 2P側（スレイブ）勝利

    // 星座
    public const int ARIES = 1;        // 牡羊座
    public const int TAURUS = 2;       // 牡牛座
    public const int GEMINI = 3;       // 双子座
    public const int CANCER = 4;       // 蟹座
    public const int LEO = 5;          // 獅子座
    public const int VIRGO = 6;        // 乙女座
    public const int LIBRA = 7;        // 天秤座
    public const int SCORPIO = 8;      // 蠍座
    public const int SAGITTARIUS = 9;  // 射手座
    public const int CAPRICORN = 10;   // 山羊座
    public const int AQUARIUS = 11;    // 水瓶座
    public const int PISCES = 12;      // 魚座
    public const int OPHIUCHUS = 13;   // 蛇遣座

    // チームサイド
    public const int TEAMSIDE_1P = 1;      // 1P側
    public const int TEAMSIDE_2P = 2;      // 2P側
}

