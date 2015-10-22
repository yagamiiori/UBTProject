using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetUserHelpInLogin : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>ユーザーヘルプのInputField</summary>
    private InputField userHelpField;
    /// <summary>LinkToXML(旧mySQL)クラス</summary>
    private XmlManager appSettings;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetUserHelpInLogin() { }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ユーザーヘルプのInputField取得
        userHelpField = this.gameObject.GetComponent<InputField>();

        // ユーザーヘルプをXMLから読み出し、入力フィールドに設定する
        appSettings = GameObject.Find("XmlManager").GetComponent<XmlManager>();
        string userHelp = appSettings.UserHelpSetForInputFieldInLogin();
        userHelpField.text = userHelp;
	}
}
