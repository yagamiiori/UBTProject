using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitPlaceObserver :
    MonoBehaviour,
    IPointerEnterHandler,                       // マウスオーバー検知用IF
    IObserver                                   // オブサーバIF
{
    /// <summary>クリックSE</summary>
    public AudioClip clickSE;
    /// <summary>ユニットアイコンのクリック有無判定</summary>
    private bool alreadyClickJud = false;
    /// <summary>サブジェクトコンポ</summary>
    private UnitPlaceSubject subjectCompo;
    /// <summary>ユニットアイコンのImageコンポ</summary>
    private Image thisImageCompo;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>ユニットID（UnitViewerOnUnderLine.csから設定される）</summary>
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
        if (!alreadyClickJud)
        {
            // まだどのアイコンもクリックされてない場合、クリックされた事と自身のユニットIDをサブジェクトへ通知する
            subjectCompo.status = (int)Enums.ObserverState.OnClick;
            subjectCompo.NowClickUnitID = unitID;
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
            // ユニットアイコンクリック判定フラグをfalseに設定し、グレイアウトを解除する
            alreadyClickJud = false;
            thisImageCompo.color = Color.white;
        }
        // ユニットアイコンの選択が選択なしになった場合（ユニットがチップに配置された時）
        else if ((int)Enums.ObserverState.None == val)
        {
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
        if (!alreadyClickJud)
        {
            // まだユニットアイコンがクリックされていない場合はSEを再生する
            clickSE = (AudioClip)Resources.Load("Sounds/SE/OnMouseOver1");
            audioCompo.PlayOneShot(clickSE);
        }
    }
}
