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
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE;                           // OKボタンクリックSE
    private GameManager gameManager;                  // マネージャコンポ
    private GameObject warningParentGO;                 // メッセージウィンドウCanvas
    /// <summary>LinkToXML(旧mySQL)クラス</summary>
    private XmlManager appSettings;
    private Text warningText;                         // メッセージウィンドウのTextコンポ
    public InputField guidField;                      // GUIDのインプットフィールド
    private string nextForUnitSelect = "UnitSelect";  // 遷移先シーン名
    private string nextForLobby = "Lobby";            // 遷移先シーン名
    private string regisgerName = "Register";         // 遷移先シーン名
    private bool IsWindow = false;                    // メッセージウィンドウ表示有無判定フラグ

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // GUID入力フィールド取得
        guidField = GameObject.FindWithTag("Login_InputField_Name").GetComponent<InputField>();
        // GUIDをXMLから読み出し、入力フィールドに設定する
        appSettings = GameObject.Find("XmlManager").GetComponent<XmlManager>();
        string userGuid = appSettings.GuidSetForInputFieldInLogin();
        guidField.text = userGuid;

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
                if ("" == guidField.text)
                {
                    MessageWriteToWindow("未入力。\nログインIDを入力して下さい。");
                    return;
                }
                // 入力されたIDが「NameLess」の場合
                else if ("NameLess" == guidField.text)
                {
                    gameManager.userName = "NameLess";
                }
                // GUIDっぽいものが入力された場合
                else
                {
                    // 入力されたGUIDとXMLのGUIDが同一であるか否か比較する
                    bool GuidResult = appSettings.CompareGuid(guidField.text);
                    // XMLがユニット情報を保持しているか否か判定する
                    bool UnitExistResult = appSettings.JudgeUnitExistInXml();

                    if (!GuidResult)
                    {
                        // クリックSEを設定および再生（エラーSE）
                        clickSE = (AudioClip)Resources.Load("Sounds/SE/Error1");
                        audioCompo.PlayOneShot(clickSE);

                        // 入力されたGUIDXMLのGUIDがアンマッチの場合はエラーを表示
                        MessageWriteToWindow("ユーザーIDが一致しません。\n正しいユーザーIDを入力して下さい。");
                        return;
                    }

                    // クリックSEを設定および再生（正常SE）
                    clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
                    audioCompo.PlayOneShot(clickSE);

                    // ユーザーヘルプフィールドを取得
                    InputField userHelpField = GameObject.Find("InputField_UserHelp").GetComponent<InputField>();

                    // GMのユーザーヘルプフィールドへユーザーヘルプを設定する
                    gameManager.userHelp = userHelpField.text;

                    // LinkToXMLコンポを取得し、入力されたユーザーヘルプをXMLへ保存する
                    appSettings = GameObject.Find("XmlManager").GetComponent<XmlManager>();
                    appSettings.UserStatusWriteToXml(userHelpField.text);

                    // ユーザー情報をXMLファイルより読み込んでGMへ設定する
                    bool result = appSettings.UserStatusLoadFromXml();
                    if (!result)
                    {
                        // XMLファイルより読み出したユーザー情報が不正な場合はエラーを表示
                        MessageWriteToWindow("ユーザー情報が不正。\n正しいユーザーIDを入力して下さい。");
                        return;                    
                    }

                    if (!UnitExistResult)
                    {
                        // ユーザー情報が正しく、かつXMLがユニット情報を保持していない場合はUnitSelectシーンへ遷移する
                        NextSceneIsUnitSelct();
                        return;
                    }
                    if (GuidResult && UnitExistResult)
                    {
                        // 入力されたGUIDが正しく、かつXMLがユニット情報を保持している場合はLobbyシーンへ遷移する
                        NextSceneIsLobby();
                        return;
                    }
                }
                // XMLがユニット情報を保持していない場合はUnitSelectシーンへ遷移する
                NextSceneIsUnitSelct();
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
    // シーン遷移メソッド（UnitSelect）
    // =====================================
    public void NextSceneIsUnitSelct()
    {
        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextForUnitSelect);
    }
    // =====================================
    // シーン遷移メソッド（Lobby）
    // =====================================
    public void NextSceneIsLobby()
    {
        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextForLobby);
    }
}
