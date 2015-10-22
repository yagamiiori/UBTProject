using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetUserHelpInUnitForm : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>ユーザーヘルプのInputField</summary>
    private Text userHelpText;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetUserHelpInUnitForm() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ユーザーヘルプのInputField取得
        userHelpText = this.gameObject.GetComponent<Text>();

        // GMから読み出し、Textコンポに設定する
        userHelpText.text = gameManager.userHelp;
    }
}
