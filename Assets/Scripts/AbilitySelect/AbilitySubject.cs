using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

// ================================================================================================
// サブジェクトとしてユニットクリック判定がONになった場合に
// 全オブサーバ(ユニットスプライト)に通知し、ユニットスプライトは透明化する
//
// ================================================================================================
public class AbilitySubject :
    MonoBehaviour,
    ISubject                                                        // サブジェクトIF
{
    /// <summary>このサブジェクトが管理するオブサーバのリスト</summary>
    private List<IObserver> obServers = new List<IObserver>();
    /// <summary>アビリティエリアの統括オブジェクト</summary>
    private GameObject abilityArea;
    /// <summary>ユニットエリアの統括オブジェクト</summary>
    private GameObject unitArea;
    /// <summary>オーディオコンポ</summary>
    public AudioSource audioCompo;
    /// <summary>ユニットクリック時のSE</summary>
    public AudioClip clickSE_UnitSlected;
    /// <summary>アビリティボタンクリック時のSE</summary>
    public AudioClip clickSE_AbilitySelected;
    /// <summary>キャンセル時のクリックSE</summary>
    public AudioClip clickSE_Cancel;
    /// <summary>サブジェクトのステータス</summary>
    // 0：初期値
    // 1：ユニットがクリックされた場合(AbilityObserver内)
    // 2：アビリティボタンがクリックされた場合(AbilitySelect内)
    // 3：右クリックされた場合(AbilitySelect内)
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

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // アビリティエリア統括オブジェクトを取得し、非アクティブ化
        abilityArea = GameObject.FindWithTag("Abl_AbilityArea");
        if (abilityArea) abilityArea.SetActive(false);

        // ユニットエリア統括オブジェクト取得
        unitArea = GameObject.FindWithTag("Abl_UnitArea");

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
        // ユニットが左クリックされた場合（アビリティエリア表示）
        if (1 == jud)
        {
            // クリックSEを鳴らす
            audioCompo.clip = clickSE_UnitSlected;
            audioCompo.Play();

            // アビリティエリアアクティブ化 / ユニットエリア非アクティブ化
            abilityArea.SetActive(true);
            unitArea.SetActive(false);

        }
        // ユニットが右クリックされた場合（キャンセル）
        else if (3 == jud)
        {
            // クリックSEを鳴らす
            audioCompo.clip = clickSE_Cancel;
            audioCompo.Play();

            // アビリティエリア非アクティブ化 / ユニットエリアアクティブ化
            abilityArea.SetActive(false);
            unitArea.SetActive(true);
        }
        // アビリティボタンがクリックされた場合（アビリティ決定）
        else
        {
            // クリックSEを鳴らす
            audioCompo.clip = clickSE_AbilitySelected;
            audioCompo.Play();

            // アビリティエリア非アクティブ化 / ユニットエリアアクティブ化
            abilityArea.SetActive(false);
            unitArea.SetActive(true);
        }
        // オブサーバクラス内の通知メソッドをコールし、変更された値を通知する
        obServers.ForEach(observer => observer.Notify(this.status));
    }
}
