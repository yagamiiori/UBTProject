using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// プルダウンメニューボタン生成クラス
/// <para>　プルダウンメニュー内に表示されるボタンの個数および</para>
/// <para>　表示クラス名やボタン画像を設定するクラス。</para>
/// </summary>
////////////////////////////////////////////////////////////////////////////////
public class SettingComboBoxClass : MonoBehaviour 
{
    /// <summary>ComboBoxクラスを持つゲームオブジェクト（インスペクタからのみ設定する）</summary>
    [SerializeField]
    private ComboBoxClass comboBox;
    /// <summary>ユニットIDを表示しているTextコンポ（インスペクタからのみ設定する）</summary>
    [SerializeField]
    private Text text_UnitID;
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>ソルジャーボタンの画像</summary>
    public Sprite imageSolder;
    /// <summary>ウィザードボタンの画像</summary>
    public Sprite imageWizard;
    /// <summary>ランサーボタンの画像</summary>
    public Sprite imageLancer;
    /// <summary>アーチャーボタンの画像</summary>
    public Sprite imageArcher;
    /// <summary>サムライボタンの画像</summary>
    public Sprite imageSamurai;
    /// <summary>リッチボタンの画像</summary>
    public Sprite imageRich;

	private void Start() 
	{
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // プルダウンメニューに追加するボタンを生成
        var buttonSolder  = new ComboBoxItem("Solder", imageSolder, false);  // ソルジャー
        var buttonWizard  = new ComboBoxItem("Wizard", imageWizard, false);  // ウィザード
        var buttonLancer  = new ComboBoxItem("Lancer", imageLancer, false);  // ランサー
        var buttonArcher  = new ComboBoxItem("Archer", imageArcher, false);  // アーチャー
        var buttonSamurai = new ComboBoxItem("Samurai", imageSamurai, false);// サムライ
        var buttonRich    = new ComboBoxItem("Rich", imageRich, false);      // リッチ

        // ソルジャーのプルダウンメニューボタンがクリックされた時の処理
		buttonSolder.OnSelect += () =>
		{
            // プルダウンメニューの大きさを変える
			// comboBox.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 180);
			// comboBox.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);

            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
			comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
			buttonSolder.IsDisabled = true;
            buttonWizard.ClassName = "Wizard";      // ウィザード
			buttonWizard.IsDisabled = false;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = false;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = false;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = false;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = false;
        };
        // ウィザードのプルダウンメニューボタンがクリックされた時の処理
        buttonWizard.OnSelect += () =>
		{
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
            buttonSolder.IsDisabled = false;
            buttonWizard.ClassName = "Wizard";      // ウィザード
            buttonWizard.IsDisabled = true;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = false;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = false;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = false;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = false;
        };
        // ランサーのプルダウンメニューボタンがクリックされた時の処理
        buttonLancer.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
            buttonSolder.IsDisabled = false;
            buttonWizard.ClassName = "Wizard";      // ウィザード
            buttonWizard.IsDisabled = false;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = true;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = false;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = false;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = false;
        };
        // アーチャーのプルダウンメニューボタンがクリックされた時の処理
        buttonArcher.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
            buttonSolder.IsDisabled = false;
            buttonWizard.ClassName = "Wizard";      // ウィザード
            buttonWizard.IsDisabled = false;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = false;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = true;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = false;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = false;
        };
        // サムライのプルダウンメニューボタンがクリックされた時の処理
        buttonSamurai.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
            buttonSolder.IsDisabled = false;
            buttonWizard.ClassName = "Wizard";      // ウィザード
            buttonWizard.IsDisabled = false;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = false;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = false;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = true;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = false;
        };
        // リッチのプルダウンメニューボタンがクリックされた時の処理
        buttonRich.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonSolder.ClassName = "Solder";      // ソルジャー
            buttonSolder.IsDisabled = false;
            buttonWizard.ClassName = "Wizard";      // ウィザード
            buttonWizard.IsDisabled = false;
            buttonLancer.ClassName = "Lancer";      // ランサー
            buttonLancer.IsDisabled = false;
            buttonArcher.ClassName = "Archer";      // アーチャー
            buttonArcher.IsDisabled = false;
            buttonSamurai.ClassName = "Samurai";    // サムライ
            buttonSamurai.IsDisabled = false;
            buttonRich.ClassName = "Rich";          // リッチ
            buttonRich.IsDisabled = true;
        };

        // 上記の設定内容でアイテムを追加する
        // ここの追加順序でプルダウンメニュー内ボタンの並び順が決まる
		comboBox.AddItems(buttonSolder, buttonWizard, buttonLancer, buttonArcher, buttonSamurai, buttonRich);

        if (!text_UnitID)
        {
            // ユニットIDのTextコンポがインスペクタからアタッチされていない場合はワーニング後、終了する
            Debug.Log("ユニットIDのTextコンポを持つゲームオブジェクトがアタッチされていません。インスペクタより設定して下さい。");
            return;
        }

        // ユニットIDのTextからユニットIDである最後の1文字(または2文字)を抜き出して定数リテラルに変換する
        int unitID = 0;
        if (4 == text_UnitID.text.Length)
        {
            // IDが1桁の場合は末尾1文字を抽出
            unitID = int.Parse(text_UnitID.text.Substring(text_UnitID.text.Length - 1, 1));
        }
        else
        {
            // IDが2桁の場合は末尾2文字を抽出
            unitID = int.Parse(text_UnitID.text.Substring(text_UnitID.text.Length - 2, 2));        
        }
        // TextコンポのID文字列とユニットリスト内のID値の差分を補正
        unitID = unitID - 1;
        // 最初に表示されるプルダウンメニューのクラスを決定
        comboBox.SelectedClass = gameManager.unitStateList[unitID].classType - 1;

        // プルダウンメニューから何れかのボタンをクリックしSelectedClassフィールドが変更された時の処理
		comboBox.OnSelectionChanged += (int index) =>
		{
            // とりあえず処理なし
		};
	}
}
