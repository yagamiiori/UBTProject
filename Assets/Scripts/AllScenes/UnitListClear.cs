using UnityEngine;
using System.Collections;

/// <summary>
/// ユニットリスト削除クラス
/// </summary>
public class UnitListClear : MonoBehaviour
{
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;

    /// <summary>コンストラクタ</summary>
    public UnitListClear() { }

    /// <summary>
    /// 全ユニットリスト削除メソッド
    /// <para>　全てのユニットリストを削除する。
    /// </summary>
    public void UnitListAllClear()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ユニットリストを全て削除
        if(0 < gameManager.unitStateList.Count) gameManager.unitStateList.Clear();
    }
    /// <summary>
    /// 特定ユニットリスト削除メソッド
    /// <para>　引数にて指定されたユニットのみをユニットリストから削除する。
    /// </summary>
    public void UnitListSelectedClear()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

}
