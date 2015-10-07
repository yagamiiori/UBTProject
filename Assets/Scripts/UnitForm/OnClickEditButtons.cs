using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// UnitFormにある3種のエディットボタンクリック時のイベントハンドラ
/// </summary>
public class OnClickEditButtons :
    MonoBehaviour,
    IMessageWriteToMW                                 // メッセージウィンドウ書き込みIF
{
    /// <summary>Canvasマネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>ワーニングウィンドウの親オブジェクト</summary>
    private GameObject warningParentGO;
    /// <summary>ワーニングウィンドウのテキストコンポ</summary>
    private Text warningText;
    /// <summary>メッセージウィンドウ表示有無判定フラグ</summary>
    private bool IsWarningWindow = false;

    /// <summary>コンストラクタ</summary>
    private OnClickEditButtons() { }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ワーニングウィンドウの親GOをワーニングウィンドウ管理クラスより取得（取得できなければ直に取りに行く）
        warningParentGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>().warningWindowParentGO;
        if (!warningParentGO) warningParentGO = GameObject.Find("Canvas_WarningWindow").transform.FindChild("Parent").gameObject;
	}

    /// <summary>
    /// Reconstructionボタンクリックメソッド
    /// <para>ReconstructionボタンのOnClick()よりコールされ、ワーニングウィンドウを表示する。</para>
    /// </summary>
    public void OnClickReconstructionButton()
    {
        MessageWriteToWindow("部隊を最初から編成し直します。\n全ての構成が削除されますが、よろしいですか？");
    }

    /// <summary>
    /// ワーニングウィンドウ書き込みIF
    /// <para>　ワーニングウィンドウのTextコンポに文字を書き込む</para>
    /// </summary>
    /// <param name="a">書き込む文字列</param>
    public void MessageWriteToWindow(string a)
    {
        // ワーニングウィンドウをアクティブ化した後、ワーニングウィンドウTextコンポを取得する
        warningParentGO.SetActive(true);
        warningText = warningParentGO.transform.FindChild("MessageWindowText").GetComponentInChildren<Text>();

        // ワーニングウィンドウ表示判定フラグをONにする
        IsWarningWindow = true;

        // メッセージ表示
        warningText.text = a;
    }

    /// <summary>
    /// NameEditボタンクリックメソッド
    /// <para>NameEditボタンのOnClick()よりコールされ、シーン遷移を実施する。</para>
    /// </summary>
    public void OnClickNameEditButton()
    {
        // ワーニングウィンドウが表示されていない場合
        if (!IsWarningWindow)
        {
            string nextScene = "NameSelect";  // 遷移先シーン

            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.2f, 0.1f, Color.black, nextScene);
        }
    }

    /// <summary>
    /// AbilityEditボタンクリックメソッド
    /// <para>AbilityEditボタンのOnClick()よりコールされ、シーン遷移を実施する。</para>
    /// </summary>
    public void OnClickAbilityEditButton()
    {
        // ワーニングウィンドウが表示されていない場合
        if (!IsWarningWindow)
        {
            string nextScene = "AbilitySelect";  // 遷移先シーン

            // Scene遷移実施（アビリティセレクトへ）
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.2f, 0.1f, Color.black, nextScene);
        }
    }
}
