using UnityEngine;
using System.Collections;

public class OnClickYes : MonoBehaviour
{
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>遷移先シーン名</summary>
    private string nextScene = "UnitSelect";
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;
    /// <summary>クリックSE</summary>
    public AudioClip clickSE;

    /// <summary>コンストラクタ</summary>
    private OnClickYes() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        // シーン遷移メソッドをコール
        NextScene();
    }

    private void NextScene()
    {
        // SEを設定および再生
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
        audioCompo.PlayOneShot(clickSE);

        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextScene);
    }

}
