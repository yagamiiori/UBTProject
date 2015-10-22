using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitPlaceSubject :
    MonoBehaviour,
    ISubject                        // サブジェクトIF
{
    /// <summary>このサブジェクトが管理するオブサーバのリスト</summary>
    private List<IObserver> obServers = new List<IObserver>();
    /// <summary>オーディオコンポ</summary>
    public AudioSource audioCompo;
    /// <summary>ユニットアイコンクリック時のSE</summary>
    public AudioClip clickSE_UnitSlected;
    /// <summary>パネルクリック時のSE</summary>
    public AudioClip clickSE_AbilitySelected;
    /// <summary>キャンセル時のSE</summary>
    public AudioClip clickSE_Cancel;
    /// <summary>サブジェクトのステータス（0:初期値　1:ユニットアイコンクリック）</summary>
    private int _status = 0;
    public int status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            Notify(_status);
        }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitPlaceSubject() { }

	void Start ()
    {
        // オーディオコンポ取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();

        // ユニットボタンクリック時SE、アビリティボタンクリック時SE、キャンセルSEを設定
        clickSE_UnitSlected = (AudioClip)Resources.Load("Sounds/SE/Click5");
        clickSE_AbilitySelected = (AudioClip)Resources.Load("Sounds/SE/Click4");
        clickSE_Cancel = (AudioClip)Resources.Load("Sounds/SE/CursorMove2");
	}

    /// <summary>
    /// オブサーバ追加メソッド
    /// <para>　サブジェクトが管理するオブサーバリストにオブサーバを追加する</para>
    /// </summary>
    /// <param name="observer"></param>
    public void Attach(IObserver observer)
    {
        obServers.Add(observer);
    }

    /// <summary>
    /// オブサーバ削除メソッド
    /// <para>　サブジェクトが管理するオブサーバリストからオブサーバを削除する</para>
    /// </summary>
    /// <param name="observer"></param>
    public void Detach(IObserver observer)
    {
        obServers.Remove(observer);
    }

    /// <summary>
    /// オブサーバへの通知メソッド
    /// <para>　statusセッター内からコールされ、オブサーバ内のNotifyメソッドに変更を通知する</para>
    /// </summary>
    /// <param name="jud">クリックされたマウスボタンの判定</param>
    public void Notify(int jud)
    {
        // オブサーバクラス内の通知メソッドをコールし、変更された値を通知する
        obServers.ForEach(observer => observer.Notify(this.status));
    }
}
