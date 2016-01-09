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
    /// <summary>
    /// このサブジェクトが管理するオブサーバのリスト
    /// </summary>
    private List<IObserver> obServers = new List<IObserver>();
    /// <summary>
    /// オーディオコンポ
    /// </summary>
    public AudioSource audioCompo;
    /// <summary>
    /// ユニットアイコンクリック時のSE
    /// </summary>
    public AudioClip clickSE;
    /// <summary>
    /// 現在クリックされているユニットのID
    /// </summary>
    private int nowClickUnitID = 0;
    public int NowClickUnitID
    {
        get { return nowClickUnitID; }
        set { nowClickUnitID = value; }
    }
    /// <summary>
    /// サブジェクトのステータス
    /// </summary>
    private int _status = (int)Enums.ObserverState.None;
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
	}

    void Update()
    {
        if ((int)Enums.ObserverState.OnClick == status)
        {
            // ユニットが選択されている時にマウス右クリックが押された場合
            if (Input.GetButtonDown("Fire2"))
            {
                // 全オブサーバにキャンセルを通知
                status = (int)Enums.ObserverState.Canceled;
            }
        }
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
        // 鳴らすSEの切り分けを開始
        if ((int)Enums.ObserverState.OnClick == jud)
        {
            // ユニットアイコンがクリックされた時に鳴らすSE
            clickSE = (AudioClip)Resources.Load("Sounds/SE/Click5");
        }
        else if ((int)Enums.ObserverState.Canceled == jud)
        {
            // ユニットアイコンクリック後にキャンセルされた時に鳴らすSE
            clickSE = (AudioClip)Resources.Load("Sounds/SE/CursorMove2");
        }
        else if ((int)Enums.ObserverState.None == jud)
        {
            // ユニットがチップに配置された時に鳴らすSE
            clickSE = (AudioClip)Resources.Load("Sounds/SE/Click4");
        }
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        // オブサーバクラス内の通知メソッドをコールし、変更された値を通知する
        obServers.ForEach(observer => observer.Notify(this.status));
    }
}
