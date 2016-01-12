using UnityEngine;
using System.Collections;

/// <summary>
/// OnClickOKクラス（InUnitPlace）
/// <para>　UnitPlaceでOKボタンクリック時のコールバッククラス。</para>
/// </summary>
public class OnClickOK : MonoBehaviour
{
    /// <summary>
    /// バトル参加中ユニットリスト管理クラス
    /// </summary>
    private BattleUnitList unitListInBattle;
    /// <summary>
    /// 初期配置時のRPC管理クラス
    /// </summary>
    private UnitPlaceCompJudRPC unitPlaceCompJudRPC;
    /// <summary>
    /// OKボタンクリック判定
    /// </summary>
    private bool isClick = false;
    /// <summary>
    /// エフェクト再生クラス
    /// </summary>
    private PlayEffect playEffect;
    /// <summary>
    /// オーディオコンポ
    /// </summary>
    private AudioSource audioCompo;
    /// <summary>
    /// クリックSE
    /// </summary>
    public AudioClip clickSE;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnClickOK() { }

    void Start()
    {
        //　バトル参加中ユニットリスト管理クラスを取得
        unitListInBattle = GameObject.Find("Canvas").GetComponent<BattleUnitList>();

        // 初期配置時のRPC管理クラスを取得
        unitPlaceCompJudRPC = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceCompJudRPC>();

        // エフェクト再生クラス取得
        playEffect = new PlayEffect();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        // まだOKボタンが押されていない場合（連打の抑止）
        if (!isClick)
        {
            isClick = true;

            // ユニットが最低一人配置されているかを確認
            if (0 == unitListInBattle.myUnits.Count)
            {
                // 一人も配置されていなければランダム配置メソッドをコールし、1人をランダムで配置する
                var setUnitRandom = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<SetUnitRandom>();
                setUnitRandom.Set();
            }

            // クリックSEを再生する
            clickSE = (AudioClip)Resources.Load("Sounds/SE/OnClickOKinUnitPlace");
            audioCompo.PlayOneShot(clickSE);

            // エフェクトを表示
            string effectSprite = "BattleStage/UnitPlace/OnClickOkEffect";
            playEffect.PlayOnce(effectSprite, this.gameObject, new Vector3(0, 0.5f, 0f));

            // 初期配置完了報告送信メソッドをコールして完了を相手側に通知し、自分も完了にする
            unitPlaceCompJudRPC.SendCompRPC();

            // 自身（OKボタンGO）とアンダーラインを破棄
            StartCoroutine(Destroy());
        }
    }

    /// <summary>
    /// OKボタンGO消去メソッド
    /// <para>　自身を時間差で消去する。</para>
    /// </summary>
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.0f);

        // 自身（Oボタン）を消去
        Destroy(this.gameObject);
        // アンダーライン（とユニットアイコン）を消去
        var line = GameObject.Find("WT Panel");
        Destroy(line);
    }
}
