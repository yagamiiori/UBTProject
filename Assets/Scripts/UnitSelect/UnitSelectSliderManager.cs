using UnityEngine;
using System.Collections;
using UnityEngine.UI;

////////////////////////////////////////////////////////////////////////////////////////
//　関数名：スライダー統括クラス
//　機能：ユニットセレクトシーンにおいてスライダーの動作を行う
//　継承：MonoBehaviour
//　種別：通常クラス
//　アタッチ先：スライダー専用Canvas（Canvas_Sliders）
//　保持メソッド：
//　リダイレクト：なし
//
//　詳細：
//　　　　スライダーを動かした時にユニット選択カウンターText、各クラスの選択数フィールド、
//　　　　全選択済みユニット数を変更および同期させる。
//　　　　また、スライダー機能によるクラス決定に加え、ボタンによるクラス選択も可能としており
//　　　　ボタンによる機能との連携のため、UnitSelectButtonXXX(UnitSelectButtonSolなど)の
//　　　　透明ボタンクラス内でも本コンポ(UnitSelectSliderManager)を取得して処理を行っている
//　　　　(sliderSolder.value += 1;など)。
//
//  呼び出し例：
//
//　履歴：
//　　　　15.xx.xx 初版
//
////////////////////////////////////////////////////////////////////////////////////////
public class UnitSelectSliderManager : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>ソルジャースライダー</summary>
    private Slider sliderSolder;
    /// <summary>ウィザードスライダー</summary>
    private Slider sliderWizard;
    /// <summary>ソルジャーのユニット数表示カウンターのTextコンポ</summary>
    public Text counterSolderValue;
    /// <summary>ウィザードのユニット数表示カウンターのTextコンポ</summary>
    public Text counterWizardValue;

	void Start ()
    {
        // マネージャコンポを取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 全ユニット数表示カウンターTextコンポを取得
        counterSolderValue = GameObject.FindWithTag("Unit_CounterSold").GetComponent<Text>();
        counterWizardValue = GameObject.FindWithTag("Unit_CounterWiz").GetComponent<Text>();

        // 全スライダーを取得
        sliderSolder = GameObject.Find("Slider_Solder").GetComponent<Slider>();
        sliderWizard = GameObject.Find("Slider_Wizard").GetComponent<Slider>();
    }

    void Update()
    {
        // 全スライダーの最大値を動的に変更
        sliderSolder.maxValue = gameManager.opt_unitNum - gameManager.unt_Wizard;
        sliderWizard.maxValue = gameManager.opt_unitNum - gameManager.unt_Sodler;
    }

    /// <summary>ソルジャースライダー値変更メソッド</summary>
    public void OnValueChangedSolder()
    {
        // スライダーで変更された値をGMに設定
        gameManager.unt_Sodler = (int)sliderSolder.value;

        // ユニット数表示カウンターのTextにスライダーで変更された値を表示
        counterSolderValue.text = gameManager.unt_Sodler.ToString();

        // 現選択済みユニット数算出メソッドをコールして選択済みユニット数を算出
        gameManager.unt_NowAllUnits = AllSelectedUnitsCulc();
    }

    /// <summary>ウィザードスライダー値変更メソッド</summary>
    public void OnValueChangedWizard()
    {
        // スライダーで変更された値をGMに設定
        gameManager.unt_Wizard = (int)sliderWizard.value;

        // ユニット数表示カウンターのTextにスライダーで変更された値を表示
        counterWizardValue.text = gameManager.unt_Wizard.ToString();

        // 現選択済みユニット数算出メソッドをコールして選択済みユニット数を算出
        AllSelectedUnitsCulc();

        // 現選択済みユニット数算出メソッドをコールして選択済みユニット数を算出
        gameManager.unt_NowAllUnits = AllSelectedUnitsCulc();
    }

    /// <summary>
    /// 全選択済みユニット数算出メソッド
    /// <para>選択されているユニットの総数を算出する。</para>
    /// </summary>
    /// <param name="allSelectedUnitsNum">全選択済みユニット数</param>
    /// <returns>全選択済みユニット数</returns>
    private int AllSelectedUnitsCulc()
    {
        int allSelectedUnitsNum =
                gameManager.unt_Sodler +
                gameManager.unt_Wizard;

        return allSelectedUnitsNum;
    }
}
