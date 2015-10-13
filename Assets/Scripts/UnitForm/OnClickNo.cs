using UnityEngine;
using System.Collections;

public class OnClickNo : MonoBehaviour {

    /// <summary>親オブジェクト管理コンポ</summary>
    private WarningWindowActiveManager warningWindowGO;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    public AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickNo() { }

	void Start ()
    {
        // ワーニングウィンドウアクティブ管理コンポ取得
        warningWindowGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
	}

    public void OnClick()
    {
        // SEを設定および再生
        clickSE = (AudioClip)Resources.Load("Sounds/SE/CursorMove2");
        audioCompo.PlayOneShot(clickSE);

        // 親オブジェクトを非アクティブ化する
        warningWindowGO.warningWindowParentGO.SetActive(false);
    }
}
