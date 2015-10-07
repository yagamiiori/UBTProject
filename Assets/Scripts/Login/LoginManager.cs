using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;
using System;

public class LoginManager :
    MonoBehaviour,
    IMessageWriteToMW                                 // メッセージウィンドウ書き込みIF
{
    private GameManager gameManager;                  // マネージャコンポ
    private GameObject warningParentGO;                 // メッセージウィンドウCanvas
    private Text warningText;                         // メッセージウィンドウのTextコンポ
    public InputField nameField;                      // 名前のインプットフィールド
    private string nextScene = "UnitSelect";          // 遷移先シーン名
    private string regisgerName = "Register";         // 遷移先シーン名
    private bool IsWindow = false;                    // メッセージウィンドウ表示有無判定フラグ
    private string userIDtxt;                         // ファイルから読み出したユーザーIDの文字列

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ユーザーID入力フィールド取得
        nameField = GameObject.FindWithTag("Login_InputField_Name").GetComponent<InputField>();

        // ワーニングウィンドウの親GOをワーニングウィンドウ管理クラスより取得
        warningParentGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>().warningWindowParentGO;

        // ユーザーIDをtxtファイルから読み出し
        var streamReader = new StreamReaderSingleLine();
        string filename = "iid.txt";
        userIDtxt = streamReader.ReadFromStream(filename);
        // 読み出しに成功した場合、読み出したユーザーID文字列を入力フィールドに設定
        if ("null" != userIDtxt) nameField.text = userIDtxt;

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
                if ("" == nameField.text)
                {
                    MessageWriteToWindow("未入力。\nログインIDを入力して下さい。");
                    return;
                }
                // 入力されたIDが「NameLess」の場合
                else if ("NameLess" == nameField.text)
                {
                    gameManager.userName = "NameLess";
                }
                // IDが正常に入力された場合
                else
                {
                    // ID検索して一致したらロードする
                    // 処理はまだ書いてない
                    // 一致するIDがなければエラー文をメッセージウィンドウで表示
                    // 入力されたIDから名前を逆引きしてGMのフィールドに格納
                    gameManager.userName = nameField.text.ToString();
                }
                // シーン遷移メソッドコール
                NextScene();
            }
            // メッセージウィンドウ表示中にエンターキーが押された場合
            else
            {
                // メッセージウィンドウを非アクティブ化
                warningParentGO.SetActive(false);

                // メッセージウィンドウ表示有無判定フラグを変更
                IsWindow = false;
            }
        }

        // メッセージウィンドウがアクティブ状態の時に左クリックされた場合
        if (true == warningParentGO.activeSelf && Input.GetMouseButtonDown(0))
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
        warningText = warningParentGO.transform.FindChild("WarningText").gameObject.GetComponent<Text>();

        // メッセージウィンドウ表示有無判定フラグを変更
        IsWindow = true;

        // メッセージ表示
        warningText.text = a;
    }

    // =====================================
    // Registrationボタンからコールされ
    // レジストシーンへ遷移する。
    // =====================================
    public void OnClickRegister()
    {
        // シーン遷移実施
        Application.LoadLevel(regisgerName);
    }

    // =====================================
    // シーン遷移メソッド
    // =====================================
    public void NextScene()
    {
        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextScene);
    }
}
