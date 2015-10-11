using UnityEngine;
using System.Collections;

public class OnClickCreditButton : MonoBehaviour
{
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>遷移先シーン</summary>
    private string nextScene = "Credit";
    /// <summary>オーディオソースコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    public AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickCreditButton() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
    }

    public void OnClickCredit()
    {
        // クリックSEを設定および再生
        audioCompo.PlayOneShot(clickSE);

        // Scene遷移実施（アビリティセレクトへ）
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.01f, 0.6f, 0.01f, Color.black, nextScene);
    }
}
