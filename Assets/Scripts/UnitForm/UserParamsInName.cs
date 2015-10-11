using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserParamsInName : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    private UserParamsInName() { }

	void Start ()
    {
     // マネージャコンポ取得
     GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

     // 自身のTextコンポ取得
     Text userNameField = this.gameObject.GetComponent<Text>();

     // ユーザー名表示枠にユーザー名を設定
     userNameField.text = gameManager.userName;
	}
}
