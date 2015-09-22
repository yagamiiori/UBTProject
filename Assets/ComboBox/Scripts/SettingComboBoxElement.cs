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
public class SettingComboBoxElement : MonoBehaviour
{
    /// <summary>ComboBoxクラスを持つゲームオブジェクト（インスペクタからのみ設定する）</summary>
    [SerializeField]
    private ComboBoxElement comboBox;
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>炎属性ボタンの画像</summary>
    public Sprite imageFire;
    /// <summary>水属性ボタンの画像</summary>
    public Sprite imageWater;
    /// <summary>土属性ボタンの画像</summary>
    public Sprite imageEarth;
    /// <summary>風属性ボタンの画像</summary>
    public Sprite imageWind;

    private void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // プルダウンメニューに追加するボタンを生成
        var buttonFire  = new ComboBoxItem("Fire", imageFire, false);       // 火属性
        var buttonWater = new ComboBoxItem("Water", imageWater, false);     // 水属性
        var buttonEarth = new ComboBoxItem("Earth", imageEarth, false);     // 土属性
        var buttonWind  = new ComboBoxItem("Wind", imageWind, false);       // 風属性

        // 火属性のプルダウンメニューボタンがクリックされた時の処理
        buttonFire.OnSelect += () =>
        {
            // プルダウンメニューの大きさを変える
            // comboBox.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 180);
            // comboBox.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);

            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonFire.ClassName = "Fire";      // 火属性
            buttonFire.IsDisabled = true;
            buttonWater.ClassName = "Water";    // 水属性
            buttonWater.IsDisabled = false;
            buttonEarth.ClassName = "Earth";    // 土属性
            buttonEarth.IsDisabled = false;
            buttonWind.ClassName = "Wind";      // 風属性
            buttonWind.IsDisabled = false;
        };
        // 水属性のプルダウンメニューボタンがクリックされた時の処理
        buttonWater.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonFire.ClassName = "Fire";      // 火属性
            buttonFire.IsDisabled = false;
            buttonWater.ClassName = "Water";    // 水属性
            buttonWater.IsDisabled = true;
            buttonEarth.ClassName = "Earth";    // 土属性
            buttonEarth.IsDisabled = false;
            buttonWind.ClassName = "Wind";      // 風属性
            buttonWind.IsDisabled = false;
        };
        // 土属性のプルダウンメニューボタンがクリックされた時の処理
        buttonEarth.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonFire.ClassName = "Fire";      // 火属性
            buttonFire.IsDisabled = false;
            buttonWater.ClassName = "Water";    // 水属性
            buttonWater.IsDisabled = false;
            buttonEarth.ClassName = "Earth";    // 土属性
            buttonEarth.IsDisabled = true;
            buttonWind.ClassName = "Wind";      // 風属性
            buttonWind.IsDisabled = false;
        };
        // 風属性のプルダウンメニューボタンがクリックされた時の処理
        buttonWind.OnSelect += () =>
        {
            // すでに選択されているボタンをプルダウンメニューから選択不可に、それ以外を選択可に設定する
            comboBox.UpdateGraphics();
            buttonFire.ClassName = "Fire";      // 火属性
            buttonFire.IsDisabled = false;
            buttonWater.ClassName = "Water";    // 水属性
            buttonWater.IsDisabled = false;
            buttonEarth.ClassName = "Earth";    // 土属性
            buttonEarth.IsDisabled = false;
            buttonWind.ClassName = "Wind";      // 風属性
            buttonWind.IsDisabled = true;
        };

        // 上記の設定内容でアイテムを追加する
        // ここの追加順序でプルダウンメニュー内ボタンの並び順が決まる
        comboBox.AddItems(buttonFire, buttonWater, buttonEarth, buttonWind);

        // 最初に表示されるプルダウンメニューのエレメントを決定
        comboBox.SelectedElement = 0;

        // プルダウンメニューから何れかのボタンをクリックしSelectedClassフィールドが変更された時の処理
        comboBox.OnSelectionChanged += (int index) =>
        {
            // エフェクトとか出す場合はここに書けばいいと思う。とりあえず処理なし
        };
    }
}
