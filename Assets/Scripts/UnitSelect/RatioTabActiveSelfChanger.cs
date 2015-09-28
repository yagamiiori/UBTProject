using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// アクティブ状態切替クラス
/// <para>　各アビリティタイプタブのアクティブ状態を切替える。</para>
/// <para>　AbilityParentオブジェクトにアタッチする。</para>
/// <para>　本機能はタブをクリックした場合の動作のみであり、ユニット画像クリック時</para>
/// <para>　におけるアビリティCanvas内BGを含めた全てのオブジェクトのアクティブ状態</para>
/// <para>　の切替えは、AbilitySubject.csにて実装する。</para>
/// </summary>
public class RatioTabActiveSelfChanger : MonoBehaviour
{
    /// <summary>クリックSEのファイル</summary>
    public AudioClip clickSE;
    /// <summary>定数 - レシオ１タブ</summary>
    private const int RATIO1_TAB = 1;
    /// <summary>定数 - レシオ２タブ</summary>
    private const int RATIO2_TAB = 2;
    /// <summary>定数 - レシオ３タブ</summary>
    private const int RATIO3_TAB = 3;
    /// <summary>定数 - レシオ４タブ</summary>
    private const int RATIO4_TAB = 4;
    /// <summary>レシオ１の親であるMaskアタッチオブジェクト</summary>
    private GameObject ratio1ParentGO;
    /// <summary>レシオ２の親であるMaskアタッチオブジェクト</summary>
    private GameObject ratio2ParentGO;
    /// <summary>レシオ３の親であるMaskアタッチオブジェクト</summary>
    private GameObject ratio3ParentGO;
    /// <summary>レシオ４の親であるMaskアタッチオブジェクト</summary>
    private GameObject ratio4ParentGO;
    /// <summary>レシオ１タブのテキストコンポ</summary>
    private Text ratio1TabTextCompo;
    /// <summary>レシオ２タブのテキストコンポ</summary>
    private Text ratio2TabTextCompo;
    /// <summary>レシオ３タブのテキストコンポ</summary>
    private Text ratio3TabTextCompo;
    /// <summary>レシオ４タブのテキストコンポ</summary>
    private Text ratio4TabTextCompo;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;

    /// <summary>コンストラクタ/// </summary>
    private RatioTabActiveSelfChanger() { }

    void Start()
    {
        // 各レシオタブの親であるMaskをアタッチしているオブジェクトを取得
        ratio1ParentGO = GameObject.Find("Tab_Ratio1").transform.FindChild("Mask").gameObject;
        ratio2ParentGO = GameObject.Find("Tab_Ratio2").transform.FindChild("Mask").gameObject;
        ratio3ParentGO = GameObject.Find("Tab_Ratio3").transform.FindChild("Mask").gameObject;
        ratio4ParentGO = GameObject.Find("Tab_Ratio4").transform.FindChild("Mask").gameObject;

        // 初期化としてレシオタブをアクティブ化、それ以外のタブを非アクティブ化する
        ratio1ParentGO.SetActive(true);
        ratio2ParentGO.SetActive(false);
        ratio3ParentGO.SetActive(false);
        ratio4ParentGO.SetActive(false);

        // 非アクティブタブのテキスト文字色変更のためタブのテキストコンポを取得
        ratio1TabTextCompo = GameObject.Find("Tab_Ratio1").transform.FindChild("Text_Ratio1").GetComponent<Text>();
        ratio2TabTextCompo = GameObject.Find("Tab_Ratio2").transform.FindChild("Text_Ratio2").GetComponent<Text>();
        ratio3TabTextCompo = GameObject.Find("Tab_Ratio3").transform.FindChild("Text_Ratio3").GetComponent<Text>();
        ratio4TabTextCompo = GameObject.Find("Tab_Ratio4").transform.FindChild("Text_Ratio4").GetComponent<Text>();
        // 初期化としてアタックタブ以外を灰色にする
        ratio1TabTextCompo.color = new Color(255, 255, 255);
        ratio2TabTextCompo.color = Color.grey;
        ratio3TabTextCompo.color = Color.grey;
        ratio4TabTextCompo.color = Color.grey;

        // オーディオコンポを取得
        audioCompo = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// アクティブ状態切替メソッド
    /// <para>　各レシオTABクリック時にコールされ、以下の処理を行う。</para>
    /// <para>　・クリックされたタブのアクティブ化</para>
    /// <para>　・クリックされたタブ以外を非アクティブ化</para>
    /// <para>　・クリックされたタブ以外のタブ文字の色を灰色に変える</para>
    /// <para>　・クリックSEを鳴らす</para>
    /// </summary>
    /// <param name="onClickTabType"></param>
    public void RatioTabActiveSelfChange(int onClickTabType)
    {
        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click2");
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        switch (onClickTabType)
        {
            case RATIO1_TAB:
                // レシオ１タブがクリックされた場合はアタックタブをアクティブ化する
                ratio1ParentGO.SetActive(true);
                ratio2ParentGO.SetActive(false);
                ratio3ParentGO.SetActive(false);
                ratio4ParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                ratio1TabTextCompo.color = new Color(255, 255, 255);
                ratio2TabTextCompo.color = Color.grey;
                ratio3TabTextCompo.color = Color.grey;
                ratio4TabTextCompo.color = Color.grey;
                break;
            case RATIO2_TAB:
                // レシオ２タブがクリックされた場合はディフェンスタブをアクティブ化する
                ratio1ParentGO.SetActive(false);
                ratio2ParentGO.SetActive(true);
                ratio3ParentGO.SetActive(false);
                ratio4ParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                ratio1TabTextCompo.color = Color.grey;
                ratio2TabTextCompo.color = new Color(255, 255, 255);
                ratio3TabTextCompo.color = Color.grey;
                ratio4TabTextCompo.color = Color.grey;
                break;
            case RATIO3_TAB:
                // レシオ３タブがクリックされた場合はリアクションタブをアクティブ化する
                ratio1ParentGO.SetActive(false);
                ratio2ParentGO.SetActive(false);
                ratio3ParentGO.SetActive(true);
                ratio4ParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                ratio1TabTextCompo.color = Color.grey;
                ratio2TabTextCompo.color = Color.grey;
                ratio3TabTextCompo.color = new Color(255, 255, 255);
                ratio4TabTextCompo.color = Color.grey;
                break;
            case RATIO4_TAB:
                // レシオ４タブがクリックされた場合はムーブタブをアクティブ化する
                ratio1ParentGO.SetActive(false);
                ratio2ParentGO.SetActive(false);
                ratio3ParentGO.SetActive(false);
                ratio4ParentGO.SetActive(true);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                ratio1TabTextCompo.color = Color.grey;
                ratio2TabTextCompo.color = Color.grey;
                ratio3TabTextCompo.color = Color.grey;
                ratio4TabTextCompo.color = new Color(255, 255, 255);
                break;
            default:
                // 処理なし
                break;
        }
    }
}
