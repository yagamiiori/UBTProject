using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ユニットアイコンオブサーバ（InUnitPlace時）
/// <para>　InUnitPlace時においてアンダーライン上に配置されたユニットアイコンのオブサーバ。</para>
/// </summary>
public class UnitPlaceObserver :
    MonoBehaviour,
    IPointerEnterHandler,                       // マウスオーバー検知用IF
    IObserver                                   // オブサーバIF
{
    /// <summary>
    /// ユニットアイコンのクリック有無判定
    /// </summary>
    private bool alreadyClickJud = false;
    /// <summary>
    /// サブジェクトコンポ
    /// </summary>
    private UnitPlaceSubject subjectCompo;
    /// <summary>
    /// バトル参加中ユニットリスト管理クラス
    /// </summary>
    private BattleUnitList unitListInBattle;
    /// <summary>
    /// ユニットアイコンのImageコンポ
    /// </summary>
    private Image thisImageCompo;
    /// <summary>
    /// オーディオコンポ
    /// </summary>
    private AudioSource audioCompo;
    /// <summary>
    /// クリックSE
    /// </summary>
    public AudioClip clickSE;
    /// <summary>
    /// 初期配置完了判定クラス
    /// </summary>
    private UnitPlaceCompJudRPC compJudRPC;
    /// <summary>
    /// ユニットID（UnitViewerOnUnderLine.csからインスタンス化した時に設定される）
    /// </summary>
    private int unitID;
    public int UnitID
    {
        get { return unitID; }
        set { unitID = value; }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitPlaceObserver() { }

	void Start ()
    {
        // サブジェクトコンポを取得し、オブサーバリストに自身を追加
        subjectCompo = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceSubject>();
        subjectCompo.Attach(this);

        // 自身のImageコンポを取得
        thisImageCompo = this.gameObject.GetComponent<Image>();

        //　バトル参加中ユニットリスト管理クラスを取得
        unitListInBattle = GameObject.Find("Canvas").GetComponent<BattleUnitList>();

        // 初期配置完了クラスを取得
        compJudRPC = subjectCompo.GetComponent<UnitPlaceCompJudRPC>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
	}

    /// <summary>
    /// ユニットアイコンクリックメソッド
    /// <para>　ユニットアイコンがクリックされた時に起動するコールバックメソッド。</para>
    /// <para>　サブジェクトにクリックされた事を通知する。</para>
    /// </summary>
    public void OnClickIcon()
    {
        // まだ初期配置完了報告RPCを飛ばしていない場合
        if (!compJudRPC.isCompleteMySide)
        {
            if (!alreadyClickJud)
            {
                // まだどのアイコンもクリックされてない場合、クリックされた事と自身のユニットIDをサブジェクトへ通知する
                subjectCompo.status = (int)Enums.ObserverState.OnClick;
                subjectCompo.NowClickUnitID = UnitID;
            }
            else
            {
                // すでに自分のユニットIDがチップ上にセットされていたらユニットを削除する
                foreach (var t in unitListInBattle.myUnits)
                {
                    if (UnitID == t)
                    {
                        // バトル参加中ユニットリストから削除
                        unitListInBattle.RemoveMyList(UnitID);
                        // ユニットGOを検索して削除
                        var unitGO = GameObject.Find("Unit" + UnitID.ToString());
                        Destroy(unitGO);
                        // 再選択可能にするためサブジェクトへ変更を送信
                        subjectCompo.status = (int)Enums.ObserverState.Canceled;
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// オブサーバ通知メソッド（オブサーバIF）
    /// <para>　ユニットがクリックされた場合にサブジェクトからコールされる。</para>
    /// </summary>
    /// <param name="jud"></param>
    public void Notify(int val)
    {
        // いずれかのユニットアイコンがクリックされた事が通知された場合
        if ((int)Enums.ObserverState.OnClick == val)
        {
            // ユニットアイコンクリック判定フラグをtrueに設定し、自身のカラーをグレイアウトする
            alreadyClickJud = true;
            thisImageCompo.color = Color.gray;
        }
        // ユニットアイコンの選択が解除された場合
        else if((int)Enums.ObserverState.Canceled == val)
        {
            foreach (var t in unitListInBattle.myUnits)
            {
                // すでに自分のユニットIDがチップ上にセットされていたらグレイアウトを解除しない
                if (UnitID == t) return;
            }
            // ユニットアイコンクリック判定フラグをfalseに設定し、グレイアウトを解除する
            alreadyClickJud = false;
            thisImageCompo.color = Color.white;
        }
        // ユニットアイコンの選択が選択なしになった場合（ユニットがチップに配置された時）
        else if ((int)Enums.ObserverState.None == val)
        {
            foreach (var t in unitListInBattle.myUnits)
            {
                // すでに自分のユニットIDがチップ上にセットされていたらグレイアウトを解除しない
                if (UnitID == t) return;
            }
            // ユニットアイコンクリック判定フラグをfalseに設定し、グレイアウトを解除する
            alreadyClickJud = false;
            thisImageCompo.color = Color.white;
        }
    }

    /// <summary>
    /// マウスオーバーメソッド
    /// <para>　マウスカーソルがオブジェクトに乗った時にコールバックされ、SEを再生する。</para>
    /// </summary>
    /// <param name="eventData">イベントデータ（使用しない）</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        // まだ初期配置完了報告RPCを飛ばしていない場合
        if (!compJudRPC.isCompleteMySide)
        {
            if (!alreadyClickJud)
            {
                // まだユニットアイコンがクリックされていない場合はSEを再生する
                clickSE = (AudioClip)Resources.Load("Sounds/SE/OnMouseOver1");
                audioCompo.PlayOneShot(clickSE);
            }
        }
    }
}
