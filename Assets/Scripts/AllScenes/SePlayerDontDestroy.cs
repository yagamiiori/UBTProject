using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤー永続クラス
/// <para>　SE/BGMプレイヤーの親オブジェクトにアタッチする。</para>
/// <para>　SE/BGMプレイヤーを永続オブジェクト化するだけの機能。</para>
/// </summary>
public class SePlayerDontDestroy : MonoBehaviour
{
    /// <summary>永続オブジェクト有無（インスペクタから永続オブジェクトである事を可視化するために設定）</summary>
    [SerializeField]
    private bool isDontDestroy = true;

    /// <summary>コンストラクタ</summary>
    private SePlayerDontDestroy() { }

	void Awake ()
    {
        if (isDontDestroy)
        {
            // TODO Tag + FindGameObjectsWithTagによる検索でなければ個数が取れない。
            // null == Find("Canvas_FadeDisplay")　では自分もFind対象になるため、Find対象自身の中で行うとnullになるケースが無い
            // すでにシーンに画面フェードオブジェクトが存在する場合は重複を抑止するため本オブジェクトを破棄
            if (1 < GameObject.FindGameObjectsWithTag("PlayersParent").Length)
            {
                Destroy(this.gameObject);
                return;
            }
            // シーンに画面フェードオブジェクトが存在しない場合は本オブジェクトを永続オブジェクトにする
            DontDestroyOnLoad(this);
        }
	}
}
