using UnityEngine;
using System.Collections;

/// <summary>
/// ユニット初期配置キャンバス消去クラス
/// <para>　ユニット初期配置に関するキャンバスを消去する。</para>
/// <para>　アタッチGO：Canvas_TimerInUnitPlace</para>
/// </summary>
public class CanvasDelete : MonoBehaviour
{
    /// <summary>オブジェクトフェードインアウトクラス</summary>
    private ObjectFadeInOut objectFadeCompo;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CanvasDelete() { }

    /// <summary>
    /// ユニット初期配置キャンバス消去メソッド
    /// <para>　配下のParentゲームオブジェクトにアタッチされている</para>
    /// <para>　フェードアウトクラスをコールし、ParentGOをフェードアウトした後、</para>
    /// <para>　本スクリプトをアタッチしているCanvasを破棄する。</para>
    /// </summary>
    public void Delete()
    {
        // UnitPlaceキャンバスを破棄する
        Destroy(this.gameObject);

        // 配下のParentoGOにアタッチしているオブジェクトフェードクラスをコールしてフェードアウトさせる
        // objectFadeCompo = this.gameObject.transform.FindChild("Parent").gameObject.GetComponent<ObjectFadeInOut>();
        // objectFadeCompo.FadeOutStart(0.08f, 2.0f, Enums.fadeTo.toUp);
    }

    /// <summary>
    /// ParentGOフェードアウト完了時UnitPlaceキャンバス破棄メソッド
    /// <para>　ParentGOのフェードアウトが完了したか判定し、完了していればキャンバスごと破棄する。</para>
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeCompJud()
    {
        if (!objectFadeCompo.isFading)
        {
            // フェードアウトが完了したらUnitPlaceキャンバスを破棄する
            Destroy(this.gameObject);
        }
        yield return null;
    }
}
