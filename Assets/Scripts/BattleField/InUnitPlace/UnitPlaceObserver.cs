using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitPlaceObserver :
    MonoBehaviour,
    IObserver                                   // オブサーバIF
{
    /// <summary>ユニットアイコンのクリック有無判定</summary>
    private bool onClickJud = false;
    /// <summary>サブジェクトコンポ</summary>
    private UnitPlaceSubject subjectCompo;
    /// <summary>ユニットアイコンのImageコンポ</summary>
    private Image thisImageCompo;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitPlaceObserver() { }

	void Start ()
    {
        // サブジェクトコンポ取得
        subjectCompo = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceSubject>();
        // サブジェクトのオブサーバリストに自身を追加
        subjectCompo.Attach(this);

        thisImageCompo = this.gameObject.GetComponent<Image>();
	}

    /// <summary>
    /// ユニットアイコンクリックメソッド
    /// <para>　ユニットアイコンがクリックされた時に起動するコールバックメソッド。</para>
    /// <para>　サブジェクトにクリックされた事を通知する。</para>
    /// </summary>
    public void OnClickIcon()
    {
        if (!onClickJud)
        {
            // まだどのアイコンもクリックされてない場合、クリックされた事をサブジェクトへ通知する
            subjectCompo.Notify((int)Enums.ObserverState.OnClick);
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
            onClickJud = true;
            thisImageCompo.color = Color.gray;
        }
        // ユニットアイコンの選択が解除された場合
        else
        {
            // ユニットアイコンクリック判定フラグをfalseに設定し、グレイアウトを解除する
            onClickJud = false;
            thisImageCompo.color = Color.white;
        }
    }
}
