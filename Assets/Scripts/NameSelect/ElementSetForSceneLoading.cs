using UnityEngine;
using System.Collections;

/// <summary>
/// NameSelectシーン開始時エレメント設定クラス
/// <para> NameSelectシーン開始時に各ユニットのエレメントを</para>
/// <para> ユニットリストより読み出し、プルダウンメニューへ設定する。</para>
/// </summary>
public class ElementSetForSceneLoading : MonoBehaviour
{
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;

    /// <summary>コンストラクタ</summary>
    private ElementSetForSceneLoading() { }

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
}
