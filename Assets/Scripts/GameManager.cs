using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;
using Hashtable = ExitGames.Client.Photon.Hashtable;    //CP専用Hashtable

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // --- ログイン画面 -- //
    public string userName = "";                   // ユーザー名（文字列）
    public string userGuid = "";                   // ユーザー名（GUID値）

    // --- オプションシーン -- //
    public int opt_unitNum = 0;                    // ユニット数
    public int opt_giftJud = 0;                    // ギフト有無判定フラグ
    public float opt_haveTime = 0;                 // 持ち時間
    public int opt_abilityJud = 0;                 // アビリティシステム有無判定フラグ（廃止）
    public int opt_lang = 0;                       // ゲーム言語
    public float opt_volume = 0f;                  // ボリューム

    // オプション設定完了フラグ
    // オプション設定画面以降のシーンにおいてオプション設定値が変更される事を
    // 抑止する（マネージャクラスは永続オブジェクトであるためのフェールセーフ）
    public bool opt_compJud = false;

    // --- ユニットセレクトシーン -- //
    public int unt_Sodler = 0;         // 戦闘参加ユニット数 - ソルジャー
    public int unt_Wizard = 0;         // 戦闘参加ユニット数 - ウィザード
    public int unt_Archer = 0;         // 戦闘参加ユニット数 - アーチャー
    public int unt_Knight = 0;         // 戦闘参加ユニット数 - ナイト
    public int unt_Guard = 0;          // 戦闘参加ユニット数 - ガード
    public int unt_Undead = 0;         // 戦闘参加ユニット数 - アンデッド
    public int unt_DeepOne = 0;        // 戦闘参加ユニット数 - 深きもの
    public int unt_Commander = 0;      // 戦闘参加ユニット数 - コマンダー
    public int unt_NowAllUnits = 0;    // 現在選択されている選択参加ユニットの総数
    public List<UnitState> unitStateList = new List<UnitState>();                   // ユニットステートリスト
    // ユニットセレクト完了フラグ
    // ユニットセレクト画面以降のシーンにおいて選択したユニット数が変更される事を
    // 抑止する（マネージャクラスは永続オブジェクトであるためのフェールセーフ）
    public bool unt_compJud = false;
    // キャラテーブル（ボツ）
    public List<int> C_List = new List<int>();        //CA対応リスト - C（クラス）ボツ
    public List<int> A_List = new List<int>();        //CA対応リスト - A（アビリティ）ボツ

    // --- バトルフィールドシーン -- //
    public Hashtable customPropeties;                                               // プレイヤーCP
    public SortedList<float, int> btl_AtList = new SortedList<float, int>();        // ATリスト
    public int btl_WtTime = 0;                                                      // WT（ウェイトタイム）
    // ユニットステータス
    // 　0：異常ステータスなし
    // 　1：暗闇
    // 　2：ストップ
    // 　3：ドンアク
    // 　4：ドンムブ
    public int btl_UnitST = 0;
    /// <summary>永続オブジェクト有無（インスペクタから永続オブジェクトである事を可視化するために設定）</summary>
    [SerializeField]
    private bool isDontDestroy = true;

    // ----------------------------------------
    // Awakeメソッド
    // ----------------------------------------
    void Awake()
    {
        if (isDontDestroy)
        {
            // TODO Tag + FindGameObjectsWithTagによる検索でなければ個数が取れない。
            // null == Find("Canvas_FadeDisplay")　では自分もFind対象になるため、Find対象自身の中で行うとnullになるケースが無い
            // すでにシーンに画面フェードオブジェクトが存在する場合は重複を抑止するため本オブジェクトを破棄
            if (1 < GameObject.FindGameObjectsWithTag("GameManager").Length)
            {
                Destroy(this.gameObject);
                return;
            }

            // シーンに画面フェードオブジェクトが存在しない場合は本オブジェクトを永続オブジェクトにする
            DontDestroyOnLoad(this);
        }
    }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // オプション設定が未完了の場合
        // オプションセレクト画面以降において、下記が書き換えられる事を抑止する
        if (false == opt_compJud)
        {
            // ユニット数初期化
            opt_unitNum = Defines.OPT_UNITS_16;

            // ギフト有無判定フラグ初期化
            opt_giftJud = 0;

            // 持ち時間初期化
            opt_haveTime = 20.0f;

            // Aリスト初期化
            for (int x = 0; x < 16; x++)
            {
                A_List.Add(Defines.NON_VALUE);
            }

            // アビリティシステム有無判定フラグ初期化（廃止）
            opt_abilityJud = 1;

            // ゲーム言語初期化（日本語）
            opt_lang = Defines.LANGUAGE_JPN;
        }

        // ユニットセレクトが未完了の場合
        // ユニットセレクト画面以降において、下記が書き換えられる事を抑止する
        if (false == unt_compJud)
        {
            // 戦闘参加ユニット数を初期化
            unt_Sodler = 0;         // ソルジャー
            unt_Wizard = 0;         // ウィザード
            unt_Archer = 0;         // アーチャー
            unt_Knight = 0;         // ナイト
            unt_Guard = 0;          // ガード
            unt_Undead = 0;         // アンデッド
            unt_DeepOne = 0;        // 深きもの
            unt_Commander = 0;      // コマンダー
            unt_NowAllUnits = 0;    // 現在選択されている選択参加ユニットの総数
        }
	}

}
