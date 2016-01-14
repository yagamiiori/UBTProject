using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;
using System;

public class RegisterManager :
    MonoBehaviour,
    IMessageWriteToMW,                                // メッセージウィンドウ書き込みIF
    IOnMessageWindowOK                                // OKボタンクリックIF（メッセージウィンドウ専用）
{
    public GameObject guidFieldGO;                    // GUID表示用オブジェクト
    public AudioClip clickSE;                         // OKボタンクリックSE
    public InputField nameField;                      // 名前のインプットフィールド
    public InputField guidField;                      // GUIDインプットフィールド
    private GameManager gameManager;                  // マネージャコンポ
    private GameObject warningParentGO;               // ワーニングウィンドウCanvas
    private InputField warningText;                   // ワーニングウィンドウのTextコンポ
    private AudioSource audioCompo;                  // オーディオソースコンポ
    private string nextScene = "Login";               // 遷移先シーン名
    private string loginName = "Login";               // 遷移先シーン名
    private bool IsWindow = false;                    // メッセージウィンドウ表示有無判定フラグ
    private bool isClick = false;                     // OKボタンクリック判定（OKボタン連打抑止）
    private bool IsGuidDecided = false;               // GUID決定済み判定（0:GUID未発行　1:GUID発行済み）
    /// <summary>LinkToXML(旧mySQL)クラス</summary>
    private XmlManager appSettings;

    /// <summary>コンストラクタ</summary>
    private RegisterManager() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 名前入力フィールド取得
        nameField = GameObject.FindWithTag("Login_InputField_Name").GetComponent<InputField>();

        // ワーニングウィンドウの親GOをワーニングウィンドウ管理クラスより取得
        warningParentGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>().warningWindowParentGO;

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // エンターキーが押された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // メッセージウィンドウ未表示の場合
            if (!IsWindow)
            {
                // IDフィールドに何も入力されていない場合
                if ("" == nameField.text || "NameLess" == nameField.text)
                {
                    // SEを設定および再生
                    clickSE = (AudioClip)Resources.Load("Sounds/SE/Error1");
                    audioCompo.PlayOneShot(clickSE);

                    // メッセージウィンドウ描画メソッドをコールして未入力メッセージを表示
                    MessageWriteToWindow("未入力もしくはゲスト名です。\n正しいユーザー名を入力して下さい。");
                    isClick = false;
                    return;
                }
                // IDが正常に入力された場合
                else
                {
                    // SEを設定および再生
                    clickSE = (AudioClip)Resources.Load("Sounds/SE/Click1");
                    audioCompo.PlayOneShot(clickSE);

                    // GUIDを生成
                    Guid guidValue = Guid.NewGuid();

                    // ユーザ名とGUIDをGMのフィールドに格納
                    gameManager.userName = nameField.text;
                    gameManager.userGuid = guidValue.ToString();

                    // 生成したGUIDをメッセージウィンドウで表示
                    MessageWriteToWindow("Complete!!\n" +
                                         "UserID was generated, copy here.：\n" +
                                         gameManager.userGuid + "\n" +
                                         "CAUTION!! When you push OK button, change scene\n"
                                         );

                    // GUID決定済み判定を発行済み(true)にする
                    IsGuidDecided = true;

                    // LinkToXMLコンポを取得し、入力されたユーザー名と生成されたGUIDをXMLへ保存する
                    appSettings = GameObject.Find("XmlManager").GetComponent<XmlManager>();
                    appSettings.UserStatusWriteToXml(nameField.text, guidValue.ToString());
                    return;
                }
            }
            else
            {
                // メッセージウィンドウ表示中にエンターキーが押された場合
                if (!IsGuidDecided)
                {
                    // メッセージウィンドウを非アクティブ化
                    warningParentGO.SetActive(false);

                    // メッセージウィンドウ表示有無判定フラグを変更
                    IsWindow = false;
                    // OKボタンクリック判定をクリア
                    isClick = false;
                }
                // GUIDが正常に発行され、発行メッセージ表示中にエンターキーが押された場合
                else
                {
                    // まだOKボタンが押されていない場合（連打の抑止）
                    if (!isClick)
                    {
                        isClick = true;
                        // Loginシーンへの遷移を実施
                        NextScene();
                    }
                }
            }
        }
    }

    // -------------------------------------------------------------------
    // OKボタンがクリックした時にOKボタンのOnClickからコールされ、
    // メッセージウィンドウを開きGUIDを表示する
    // -------------------------------------------------------------------
    public void OnClickOK()
    {
        // メッセージウィンドウ未表示の場合
        if (!IsWindow)
        {
            // インプットフィールドにNameLess以外の文字が入力されている場合
            if ("" != nameField.text && "NameLess" != nameField.text)
            {
                // SEを設定および再生
                clickSE = (AudioClip)Resources.Load("Sounds/SE/Click1");
                audioCompo.PlayOneShot(clickSE);

                // GUIDを生成
                Guid guidValue = Guid.NewGuid();

                // ユーザ名とGUIDをGMのフィールドに格納
                gameManager.userName = nameField.text;
                gameManager.userGuid = guidValue.ToString();

                // 生成したGUIDをメッセージウィンドウで表示
                MessageWriteToWindow("Complete!!\n" + "UserID was generated, copy here.：\n" + gameManager.userGuid);

                // GUID決定済み判定を発行済み(true)にする
                IsGuidDecided = true;

                // LinkToXMLコンポを取得し、入力されたユーザー名と生成されたGUIDをXMLへ保存する
                appSettings = GameObject.Find("XmlManager").GetComponent<XmlManager>();
                appSettings.UserStatusWriteToXml(nameField.text, guidValue.ToString());
                return;
            }
            // インプットフィールドが空欄またはNameLessが入力されている場合
            else
            {
                // SEを設定および再生
                clickSE = (AudioClip)Resources.Load("Sounds/SE/Error1");
                audioCompo.PlayOneShot(clickSE);

                // メッセージウィンドウ描画メソッドをコールして未入力メッセージを表示
                MessageWriteToWindow("未入力もしくはゲスト名です。\n正しいユーザー名を入力して下さい。");

                // OKボタンクリック判定をクリア
                isClick = false;
                return;
            }
        }
    }

    // -------------------------------------------------------------------
    // メッセージウィンドウのOKボタンからコールされ、
    // メッセージウィンドウを非アクティブ化する。
    // -------------------------------------------------------------------
    public void OnMessageWindowOK()
    {
        // GUID発行済みの場合
        if (IsGuidDecided)
        {
            // まだOKボタンが押されていない場合（連打の抑止）
            if (!isClick)
            {
                isClick = true;
                // シーン遷移メソッドをコール
                NextScene();
            }
        }
        // GUID未発行の場合
        else
        {
            // メッセージウィンドウを非アクティブ化
            warningParentGO.SetActive(false);

            // メッセージウィンドウ表示有無判定フラグを変更
            IsWindow = false;
        }
    }

    // =====================================
    // メッセージウィンドウ書き込みIF
    // メッセージウィンドウのTextコンポに文字を書き込む
    // =====================================
    public void MessageWriteToWindow(string a)
    {
        // メッセージウィンドウをアクティブ化
        warningParentGO.SetActive(true);

        // テキストコンポを取得
        warningText = warningParentGO.transform.FindChild("MessageWindowText").gameObject.GetComponent<InputField>();

        // メッセージウィンドウ表示有無判定フラグを変更
        IsWindow = true;

        // メッセージ表示
        warningText.text = a;
    }

    // -------------------------------------------------------------------
    // Return Loginボタンからコールされ
    // ログインシーンへ遷移する。
    // -------------------------------------------------------------------
    public void OnClickLogin()
    {
        // メッセージウィンドウ未表示の場合
        if (!IsWindow)
        {
            // シーン遷移実施
            Application.LoadLevel(loginName);
        }
    }

    // -------------------------------
    // シーン遷移メソッド
    // -------------------------------
    public void NextScene()
    {
        // SEを設定および再生
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
        audioCompo.PlayOneShot(clickSE);

        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextScene);
    }
}
