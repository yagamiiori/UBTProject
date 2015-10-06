using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// マネージャークラス
/// <para>　シーンを跨ぐオプション値や選択したユニット数などを保存するための
/// <para>　単一インスタンス（privateコンストラクタ）クラス。</para>
/// </summary>
public class GameManager : Photon.MonoBehaviour
{
    /// <summary>ユーザー名</summary>
    public string userName = "";
    /// <summary>GUID</summary>
    public string userGuid = "";
    /// <summary>ユニット数</summary>
    public int opt_unitNum = Defines.OPT_UNITS_16;
    /// <summary>持ち時間</summary>
    public float opt_haveTime = 0;
    /// <summary>ゲーム言語</summary>
    public int opt_lang = 0;
    /// <summary>選択されたソルジャーの人数</summary>
    public int sodlerNum = 0;
    /// <summary>選択されたウィザードの人数</summary>
    public int wizardNum = 0;
    /// <summary>選択されたアーチャーの人数</summary>
    public int archerNum = 0;
    /// <summary>選択されたナイトの人数</summary>
    public int knightNum = 0;
    /// <summary>選択されたユニットの総数</summary>
    public int unt_NowAllUnits = 0;
    /// <summary>選択された全ユニットのリスト</summary>
    public List<UnitState> unitStateList = new List<UnitState>();
    // --- バトルフィールドシーン -- //
    /// <summary>プレイヤーCP</summary>
    public ExitGames.Client.Photon.Hashtable customPropeties;
    /// <summary>ルームCP</summary>
    public RoomInfo r;
    /// <summary>ステート異常種別</summary>
    public int stateAbnormality = Defines.STATUS_NORMAL;
    /// <summary>ユニットセレクト設定完了フラグ</summary>
    // ユニットセレクト画面以降のシーンにおいてオプション設定値が変更される事を抑止する
    private bool unt_compJud = false;
    /// <summary>オプション設定完了フラグ</summary>
    // オプション設定画面以降のシーンにおいてオプション設定値が変更される事を抑止する
    private bool opt_compJud = false;
    /// <summary>永続オブジェクト有無（インスペクタから永続オブジェクトである事を可視化するために設定）</summary>
    [SerializeField]
    private bool isDontDestroy = true;

    /// <summary>コンストラクタ</summary>
    private GameManager() { }

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

    void Start()
    {
        // オプション設定が未完了の場合
        // オプションセレクト画面以降において、下記が書き換えられる事を抑止する
        if (false == opt_compJud)
        {
            // ユニット数初期化
            opt_unitNum = Defines.OPT_UNITS_16;

            // 持ち時間初期化
            opt_haveTime = 20.0f;

            // ゲーム言語初期化（日本語）
            opt_lang = Defines.LANGUAGE_JPN;
        }
        // ユニットセレクトが未完了の場合
        // ユニットセレクト画面以降において、下記が書き換えられる事を抑止する
        if (false == unt_compJud)
        {
            // 全ての選択されたユニット数を初期化
            sodlerNum = 0;
            wizardNum = 0;
            archerNum = 0;
            knightNum = 0;
            unt_NowAllUnits = 0;
        }
	}
}
