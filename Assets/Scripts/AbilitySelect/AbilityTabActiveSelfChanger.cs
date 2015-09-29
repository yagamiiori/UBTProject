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
public class AbilityTabActiveSelfChanger : MonoBehaviour
{
    /// <summary>クリックSEのファイル</summary>
    public AudioClip clickSE;
    /// <summary>定数 - アタックタブ</summary>
    private const int ATTACK_TAB   = 1;
    /// <summary>定数 - ディフェンスタブ</summary>
    private const int DEFENCE_TAB  = 2;
    /// <summary>定数 - リアクションタブ</summary>
    private const int REACTION_TAB = 3;
    /// <summary>定数 - ムーブタブ</summary>
    private const int MOVE_TAB     = 4;
    /// <summary>アタックアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject attackParentGO;
    /// <summary>サポートアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject defenceParentGO;
    /// <summary>リアクションアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject reactionParentGO;
    /// <summary>ムーブアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject moveParentGO;
    /// <summary>アタックタブのテキストコンポ</summary>
    private Text attackTabTextCompo;
    /// <summary>ディフェンスタブのテキストコンポ</summary>
    private Text defenceTabTextCompo;
    /// <summary>リアクションタブのテキストコンポ</summary>
    private Text reactionTabTextCompo;
    /// <summary>ムーブタブのテキストコンポ</summary>
    private Text moveTabTextCompo;
    /// <summary>オーディオコンポ</summary>
    private AudioSource audioCompo;

    /// <summary>コンストラクタ/// </summary>
    private AbilityTabActiveSelfChanger() { }

	void Start ()
    {
        // 各アビリティボタンの親であるMaskをアタッチしているオブジェクトを取得
        attackParentGO = GameObject.Find("Tab_Action").transform.FindChild("Mask").gameObject;
        defenceParentGO = GameObject.Find("Tab_Support").transform.FindChild("Mask").gameObject;
        reactionParentGO = GameObject.Find("Tab_Reaction").transform.FindChild("Mask").gameObject;
        moveParentGO = GameObject.Find("Tab_Move").transform.FindChild("Mask").gameObject;

        // 初期化としてアタックタブをアクティブ化、それ以外のタブを非アクティブ化する
        attackParentGO.SetActive(true);
        defenceParentGO.SetActive(false);
        reactionParentGO.SetActive(false);
        moveParentGO.SetActive(false);

        // 非アクティブタブのテキスト文字色変更のためタブのテキストコンポを取得
        attackTabTextCompo = GameObject.Find("Tab_Action").transform.FindChild("Text").GetComponent<Text>();
        defenceTabTextCompo = GameObject.Find("Tab_Support").transform.FindChild("Text").GetComponent<Text>();
        reactionTabTextCompo = GameObject.Find("Tab_Reaction").transform.FindChild("Text").GetComponent<Text>();
        moveTabTextCompo = GameObject.Find("Tab_Move").transform.FindChild("Text").GetComponent<Text>();
        // 初期化としてアタックタブ以外を灰色にする
        attackTabTextCompo.color = new Color(255, 255, 255);
        defenceTabTextCompo.color = Color.grey;
        reactionTabTextCompo.color = Color.grey;
        moveTabTextCompo.color = Color.grey;

        // オーディオコンポを取得
        audioCompo = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// アクティブ状態切替メソッド
    /// <para>　各アビリティTABクリック時にコールされ、以下の処理を行う。</para>
    /// <para>　・クリックされたタブのアクティブ化</para>
    /// <para>　・クリックされたタブ以外を非アクティブ化</para>
    /// <para>　・クリックされたタブ以外のタブ文字の色を灰色に変える</para>
    /// <para>　・クリックSEを鳴らす</para>
    /// </summary>
    /// <param name="onClickTabType"></param>
    public void AblityTabActiveSelfChange(int onClickTabType)
    {
        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click2");
        // 設定したSEを鳴らす
        audioCompo.PlayOneShot(clickSE);

        switch (onClickTabType)
        {
            case ATTACK_TAB:
                // アタックタブがクリックされた場合はアタックタブをアクティブ化する
                attackParentGO.SetActive(true);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                attackTabTextCompo.color = new Color(255, 255, 255);
                defenceTabTextCompo.color = Color.grey;
                reactionTabTextCompo.color = Color.grey;
                moveTabTextCompo.color = Color.grey;
                break;
            case DEFENCE_TAB:
                // サポートタブがクリックされた場合はディフェンスタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(true);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                attackTabTextCompo.color = Color.grey;
                defenceTabTextCompo.color = new Color(255, 255, 255);
                reactionTabTextCompo.color = Color.grey;
                moveTabTextCompo.color = Color.grey;
                break;
            case REACTION_TAB:
                // リアクションタブがクリックされた場合はリアクションタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(true);
                moveParentGO.SetActive(false);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                attackTabTextCompo.color = Color.grey;
                defenceTabTextCompo.color = Color.grey;
                reactionTabTextCompo.color = new Color(255, 255, 255);
                moveTabTextCompo.color = Color.grey;
                break;
            case MOVE_TAB:
                // ムーブタブがクリックされた場合はムーブタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(true);
                // 選択されなかったタブの文字色を灰色にする（グレイアウト表現）
                attackTabTextCompo.color = Color.grey;
                defenceTabTextCompo.color = Color.grey;
                reactionTabTextCompo.color = Color.grey;
                moveTabTextCompo.color = new Color(255, 255, 255);
                break;
            default:
                // 処理なし
                break;
        }
    }
}
