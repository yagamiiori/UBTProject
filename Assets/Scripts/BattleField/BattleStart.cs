using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// BattleStartクラス
/// <para>　ユニットの初期配置完了後にコールされ、BattleStart処理を実施する。</para>
/// </summary>
public class BattleStart : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BattleStart() { }

	void Start ()
    {
	
	}

    /// <summary>
    /// BattleStart画像表示メソッド
    /// </summary>
    /// <para>　BattleStart画像を表示する。</para>
    /// <returns></returns>
    public IEnumerator ViewBattleStart()
    {
        // 初期配置完了からBattleStart画像の表示までに一時停止する
        yield return new WaitForSeconds(2.0f);

        // BattleStart時の画面カラーのゲームオブジェクト、画面カラークラス、Imageコンポを取得
        GameObject displayColorGO = GameObject.Find("DisplayColorAtBattleStart");
        var displayColorClass = displayColorGO.GetComponent<DestroyDisplayColorGO>();
        Image displayColorCompo = displayColorGO.GetComponent<Image>();

        // 画面カラーを黄色にフェードさせる（アルファ値を変更）
        Color a = new Color(255, 255, 255, 0);
        Color b = new Color(255, 255, 255, 128);
        displayColorCompo.color = Color.Lerp(a, b, 0.2f);

        // 黄色フェードが完了したらBattleStart画像を表示
        // 画像表示処理ここ
        yield return new WaitForSeconds(1.0f); // 画像表示中は停止する

        // 画像カラーを黄色から初期値に戻し、戻し終わったら画面カラーオブジェクトを消去する
        displayColorCompo.color = Color.Lerp(b, a, 0.2f);
        displayColorClass.Destroy();
    }
}
