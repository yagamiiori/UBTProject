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
    private List<IObserver> obServers = new List<IObserver>();      // 管理オブサーバリスト
    private GameObject abilityArea;                                 // アビリティエリア統括オブジェクト
    private GameObject unitArea;                                    // ユニットエリア統括オブジェクト
    public AudioSource audioCompo;                                  // オーディオコンポ
    public AudioClip clickSE_Unit;                                  // ユニットクリック時のクリックSE
    public AudioClip clickSE_AblButton;                             // アビリティボタンクリック時のクリックSE
    public AudioClip clickSE_Cancel;                                // キャンセル時のクリックSE

    // サブジェクトのステータス
    // ここに変更があったら各オブサーバへ変更内容を通知するNotify();
    // が起動する
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

        // オーディオコンポを取得
        audioCompo = this.gameObject.GetComponent<AudioSource>();

        // ユニットボタンクリック時SEと、アビリティボタンクリック時SEを設定
        clickSE_Unit = (AudioClip)Resources.Load("Sounds/SE/AbilitySelect_UnitClick");
        clickSE_AblButton = (AudioClip)Resources.Load("Sounds/SE/AbilitySelect_Decided");
        clickSE_Cancel = (AudioClip)Resources.Load("Sounds/SE/Cancel");
    }

    // --------------------------------------------
    // オブサーバ追加メソッド
    // サブジェクトが管理するオブサーバリストにオブサーバを追加
    // --------------------------------------------
    public void Attach(IObserver observer)
    {
        obServers.Add(observer);
    }

    // --------------------------------------------
    // オブサーバ削除メソッド
    // サブジェクトが管理するオブサーバリストからオブサーバを削除
    // --------------------------------------------
    public void Detach(IObserver observer)
    {
        obServers.Remove(observer);
    }

    // --------------------------------------------
    // オブサーバへの通知メソッド
    // statusセッター内からコールされ、オブサーバ内Notifyへ変更を通知する
    // --------------------------------------------
    public void Notify(int jud)
    {
        // ユニットが左クリックされた場合（アビリティエリア表示）
        if (1 == this.status)
        {
            // クリックSEを鳴らす
            audioCompo.clip = clickSE_Unit;
            audioCompo.Play();

            // アビリティエリアアクティブ化 / ユニットエリア非アクティブ化
            abilityArea.SetActive(true);
            unitArea.SetActive(false);

        }
        // ユニットが右クリックされた場合（キャンセル）
        else if (3 == this.status)
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
            audioCompo.clip = clickSE_AblButton;
            audioCompo.Play();

            // アビリティエリア非アクティブ化 / ユニットエリアアクティブ化
            abilityArea.SetActive(false);
            unitArea.SetActive(true);
        }

        // オブサーバクラス内の通知メソッドをコール
        obServers.ForEach(observer => observer.Notify(this.status));
    }
}
