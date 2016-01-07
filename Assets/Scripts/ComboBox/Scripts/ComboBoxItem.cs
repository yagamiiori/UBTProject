using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// インスペクタ表示オプションクラス
/// <para>　プルダウンメニュー内のボタンに表示するクラス名、</para>
/// <para>　クラス画像、表示有無判定フィールドおよびそれらを設定する</para>
/// <para>　設定専用メソッドを持つ</para>
/// </summary>
[Serializable]
public class ComboBoxItem
{
	[SerializeField]
	private string _className;
    /// <summary>クラス名</summary>
    public string ClassName
	{
		get
		{
			return _className;
		}
		set
		{
			_className = value;
			if (OnUpdate != null)
				OnUpdate();
		}
	}

	[SerializeField]
	private Sprite _image;
    /// <summary>クラス画像</summary>
    public Sprite Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
			if (OnUpdate != null)
				OnUpdate();
		}
	}

	[SerializeField]
	private bool _isDisabled;
    /// <summary>プルダウンメニューから選択可能にするか否かの選択可否判定（false:選択可　true:選択不可(グレイアウト)）</summary>
    public bool IsDisabled
	{
		get
		{
			return _isDisabled;
		}
		set
		{
			_isDisabled = value;
			if (OnUpdate != null)
				OnUpdate();
		}
	}

    /// <summary>　　　</summary>
    public Action OnSelect;
    /// <summary>　　　</summary>
    internal Action OnUpdate;

    /// <summary>
    /// コンストラクタ（表示クラス名）
    /// </summary>
    public ComboBoxItem(string caption)
	{
		_className = caption;
	}

    /// <summary>
    /// コンストラクタ（クラス画像）
    /// </summary>
    public ComboBoxItem(Sprite image)
	{
		_image = image;
	}

    /// <summary>
    /// コンストラクタ（表示クラス名、選択可否判定）
    /// </summary>
    public ComboBoxItem(string caption, bool disabled)
	{
		_className = caption;
		_isDisabled = disabled;
	}

    /// <summary>
    /// コンストラクタ（クラス画像、選択可否判定）
    /// </summary>
    public ComboBoxItem(Sprite image, bool disabled)
	{
		_image = image;
		_isDisabled = disabled;
	}

    /// <summary>
    /// コンストラクタ（表示クラス名、クラス画像、選択可否判定）
    /// </summary>
    public ComboBoxItem(string caption, Sprite image, bool disabled)
	{
		_className = caption;
		_image = image;
		_isDisabled = disabled;
	}

    /// <summary>
    /// コンストラクタ（表示クラス名、クラス画像、選択可否判定、選択したオブジェクト？）
    /// </summary>
    public ComboBoxItem(string caption, Sprite image, bool disabled, Action onSelect)
	{
		_className = caption;
		_image = image;
		_isDisabled = disabled;
		OnSelect = onSelect;
	}

    /// <summary>
    /// コンストラクタ（表示クラス名、クラス画像、選択したオブジェクト？）
    /// </summary>
    public ComboBoxItem(string caption, Sprite image, Action onSelect)
	{
		_className = caption;
		_image = image;
		OnSelect = onSelect;
	}

    /// <summary>
    /// コンストラクタ（表示クラス名、選択したオブジェクト？）
    /// </summary>
    public ComboBoxItem(string caption, Action onSelect)
	{
		_className = caption;
		OnSelect = onSelect;
	}

    /// <summary>
    /// コンストラクタ（クラス画像、選択したオブジェクト？）
    /// </summary>
    public ComboBoxItem(Sprite image, Action onSelect)
	{
		_image = image;
		OnSelect = onSelect;
	}
}
