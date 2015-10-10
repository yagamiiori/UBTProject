using UnityEngine;
using System.Collections;

public class OnClickNo : MonoBehaviour {

    /// <summary>親オブジェクト管理コンポ</summary>
    private WarningWindowActiveManager warningWindowGO;

    /// <summary>コンストラクタ</summary>
    private OnClickNo() { }

	void Start ()
    {
        // ワーニングウィンドウアクティブ管理コンポ取得
        warningWindowGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>();
	}

    public void OnClick()
    {
        // 親オブジェクトを非アクティブ化する
        warningWindowGO.warningWindowParentGO.SetActive(false);
    }
}
