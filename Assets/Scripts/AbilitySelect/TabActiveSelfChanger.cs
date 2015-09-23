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
public class TabActiveSelfChanger : MonoBehaviour
{
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
    /// <summary>ディフェンスアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject defenceParentGO;
    /// <summary>リアクションアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject reactionParentGO;
    /// <summary>ムーブアビリティの親であるMaskアタッチオブジェクト</summary>
    private GameObject moveParentGO;

    /// <summary>コンストラクタ/// </summary>
    private TabActiveSelfChanger() { }

	void Start ()
    {
        // 各アビリティボタンの親であるMaskをアタッチしているオブジェクトを取得
        attackParentGO = GameObject.Find("Button_Attack").transform.FindChild("Mask").gameObject;
        defenceParentGO = GameObject.Find("Button_Defence").transform.FindChild("Mask").gameObject;
        reactionParentGO = GameObject.Find("Button_Reaction").transform.FindChild("Mask").gameObject;
        moveParentGO = GameObject.Find("Button_Move").transform.FindChild("Mask").gameObject;

        // 初期化としてアタックタブをアクティブ化、それ以外のタブを非アクティブ化する
        attackParentGO.SetActive(true);
        defenceParentGO.SetActive(false);
        reactionParentGO.SetActive(false);
        moveParentGO.SetActive(false);
	}

    /// <summary>
    /// アクティブ状態切替メソッド
    /// <para>　各アビリティTAGクリック時にコールされ、以下の処理を行う。</para>
    /// <para>　・クリックされたタブのアクティブ化</para>
    /// <para>　・クリックされたタブ以外を非アクティブ化</para>
    /// </summary>
    /// <param name="onClickTabType"></param>
    public void AblityTabActiveSelfChange(int onClickTabType)
    {
        switch (onClickTabType)
        {
            case ATTACK_TAB:
                // アタックタブがクリックされた場合はアタックタブをアクティブ化する
                attackParentGO.SetActive(true);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(false);
                break;
            case DEFENCE_TAB:
                // ディフェンスタブがクリックされた場合はディフェンスタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(true);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(false);
                break;
            case REACTION_TAB:
                // リアクションタブがクリックされた場合はリアクションタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(true);
                moveParentGO.SetActive(false);
                break;
            case MOVE_TAB:
                // ムーブタブがクリックされた場合はムーブタブをアクティブ化する
                attackParentGO.SetActive(false);
                defenceParentGO.SetActive(false);
                reactionParentGO.SetActive(false);
                moveParentGO.SetActive(true);
                break;
            default:
                // 処理なし
                break;
        }
    }
}
