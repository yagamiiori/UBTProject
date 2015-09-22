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
    private GameManager gameManager;                  // マネージャコンポ
    private GameObject messageWindow;                 // メッセージウィンドウCanvas
    private InputField messageText;                   // メッセージウィンドウのTextコンポ
    public InputField nameField;                      // 名前のインプットフィールド
    public InputField guidField;                      // GUIDインプットフィールド
    public GameObject guidFieldGO;                    // GUID表示用オブジェクト
    private string nextScene = "Login";               // 遷移先シーン名
    private string loginName = "Login";               // 遷移先シーン名
    private bool IsWindow = false;                    // メッセージウィンドウ表示有無判定フラグ
    private bool IsGuidDecided = false;               // GUID決定済み判定（0:GUID未発行　1:GUID発行済み）


    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 名前入力フィールド取得
        nameField = GameObject.FindWithTag("Login_InputField_Name").GetComponent<InputField>();

        // メッセージウィンドウのCanvasとTextコンポを取得し、非アクティブ化
        messageWindow = GameObject.FindWithTag("Canvas_MW");
        messageText = GameObject.FindWithTag("TextField_MW").GetComponent<InputField>();
        messageWindow.SetActive(false);

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
                    // メッセージウィンドウ描画メソッドをコールして未入力メッセージを表示
                    MessageWriteToWindow("未入力もしくはゲスト名です。\n正しいユーザー名を入力して下さい。");
                    return;
                }
                // IDが正常に入力された場合
                else
                {
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

                    return;
                }
            }
            else
            {
                // 未入力メッセージ表示中にエンターキーが押された場合
                if (!IsGuidDecided)
                {
                    // メッセージウィンドウを非アクティブ化
                    messageWindow.SetActive(false);

                    // メッセージウィンドウ表示有無判定フラグを変更
                    IsWindow = false;
                }
                // GUIDメッセージ表示中にエンターキーが押された場合
                else
                {
                    // シーン遷移メソッドコール
                    NextScene();
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
                // GUIDを生成
                Guid guidValue = Guid.NewGuid();

                // ユーザ名とGUIDをGMのフィールドに格納
                gameManager.userName = nameField.text;
                gameManager.userGuid = guidValue.ToString();

                // 生成したGUIDをメッセージウィンドウで表示
                MessageWriteToWindow("Complete!!\n" + "UserID was generated, copy here.：\n" + gameManager.userGuid);

                // GUID決定済み判定を発行済み(true)にする
                IsGuidDecided = true;
            }
            // インプットフィールドが空欄またはNameLessが入力されている場合
            else
            {
                // メッセージウィンドウ描画メソッドをコールして未入力メッセージを表示
                MessageWriteToWindow("未入力もしくはゲスト名です。\n正しいユーザー名を入力して下さい。");
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
            // シーン遷移メソッドをコール
            NextScene();
        }
        // GUID未発行の場合
        else
        {
            // メッセージウィンドウを非アクティブ化
            messageWindow.SetActive(false);

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
        messageWindow.SetActive(true);

        // メッセージウィンドウ表示有無判定フラグを変更
        IsWindow = true;

        // メッセージ表示
        messageText.text = a;
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
        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextScene);
    }


}
