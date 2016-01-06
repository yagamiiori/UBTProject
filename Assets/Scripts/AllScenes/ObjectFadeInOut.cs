using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// オブジェクトフェードイン/アウトクラス
/// <para>　フェードしながら消去or表示させるオブジェクトにアタッチし、</para>
/// <para>　他コンポーネントのスクリプトからコールする。</para>
/// 
/// コール用サンプル
/// var t = this.gameObject.GetComponent<ObjectFadeInOut>();
/// t.FadeInStart(16.0f,0.08f, 2.0f, Enums.fadeFrom.fromUp);
/// </summary>
public class ObjectFadeInOut : MonoBehaviour
{
    /// <summary>補正値を含めたオブジェクトの位置</summary>
    private Vector3 corPosSet;
    /// <summary>Imageコンポ</summary>
    private Image imageCompo;
    /// <summary>初期カラー</summary>
    private Color fromColor;
    /// <summary>到達カラー</summary>
    private Color toColor;
    /// <summary>フェード実施中判定</summary>
    public bool isFading = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private ObjectFadeInOut() { }

    /// <summary>
    /// フェードインメソッド
    /// <para>　オブジェクトをフェード＋移動させながら表示する。</para>
    /// </summary>
    /// <param name="fromPos">初期位置に加算する値</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="moveTime">移動する時間</param>
    /// <param name="from">移動する方向</param>
    public void FadeInStart(float fromPos, float fadeTime, float moveTime, Enums.fadeFrom from)
    {
        // フェード処理を開始
        isFading = true;

        // オブジェクトの初期位置を変更するため、変更前にスタックしておく
        Vector3 defaultPos = this.transform.localPosition;

        // フェードインしてくる方向によりオブジェクトの初期位置を振り分け
        switch (from)
        {
            // 上から下へのフェード
            case Enums.fadeFrom.fromUp:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.y += fromPos;
                this.transform.localPosition = corPosSet;

                // アルファ値0と255のColorクラスを作成
                Image imageCompo = this.GetComponent<Image>();
                Color fromColor = new Color(255, 255, 255, 0);
                Color toColor = new Color(255, 255, 255, 255);

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(FadeInEnumrator(imageCompo, fadeTime, moveTime, fromColor, toColor, defaultPos));
                break;

            // 下から上へのフェード
            case Enums.fadeFrom.fromUnder:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.y -= fromPos;
                this.transform.localPosition = corPosSet;

                // アルファ値0と255のColorクラスを作成
                imageCompo = this.GetComponent<Image>();
                fromColor = new Color(255, 255, 255, 0);
                toColor = new Color(255, 255, 255, 255);

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(FadeInEnumrator(imageCompo, fadeTime, moveTime, fromColor, toColor, defaultPos));
                break;

            // 左から右へのフェード
            case Enums.fadeFrom.fromLeft:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.x -= fromPos;
                this.transform.localPosition = corPosSet;

                // アルファ値0と255のColorクラスを作成
                imageCompo = this.GetComponent<Image>();
                fromColor = new Color(255, 255, 255, 0);
                toColor = new Color(255, 255, 255, 255);

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(FadeInEnumrator(imageCompo, fadeTime, moveTime, fromColor, toColor, defaultPos));
                break;

            // 右から左へのフェード
            case Enums.fadeFrom.fromRight:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.x += fromPos;
                this.transform.localPosition = corPosSet;

                // アルファ値0と255のColorクラスを作成
                imageCompo = this.GetComponent<Image>();
                fromColor = new Color(255, 255, 255, 0);
                toColor = new Color(255, 255, 255, 255);

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(FadeInEnumrator(imageCompo, fadeTime, moveTime, fromColor, toColor, defaultPos));
                break;

            default:
                // 処理なし
                break;
        }
    }

    /// <summary>
    /// フェードインメソッド（CanvasGroup用）
    /// <para>　オブジェクトとその配下のGOをフェード＋移動させながら表示する。</para>
    /// </summary>
    /// <param name="fromPos">初期位置に加算する値</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="moveTime">移動する時間</param>
    /// <param name="from">移動する方向</param>
    public void CanvasGroupFadeInStart(float fromPos, float fadeTime, float moveTime, Enums.fadeFrom from)
    {
        // フェード処理を開始
        isFading = true;

        // オブジェクトの初期位置を変更するため、変更前にスタックしておく
        Vector3 defaultPos = this.transform.localPosition;
        // CanvasGroup
        CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();

        // フェードインしてくる方向によりオブジェクトの初期位置を振り分け
        switch (from)
        {
            // 上から下へのフェード
            case Enums.fadeFrom.fromUp:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.y += fromPos;
                this.transform.localPosition = corPosSet;

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(CanvasGroupFadeInEnumrator(canvasGroup, fadeTime, moveTime, defaultPos));
                break;

            // 下から上へのフェード
            case Enums.fadeFrom.fromUnder:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.y -= fromPos;
                this.transform.localPosition = corPosSet;

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(CanvasGroupFadeInEnumrator(canvasGroup, fadeTime, moveTime, defaultPos));
                break;

            // 左から右へのフェード
            case Enums.fadeFrom.fromLeft:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.x -= fromPos;
                this.transform.localPosition = corPosSet;

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(CanvasGroupFadeInEnumrator(canvasGroup, fadeTime, moveTime, defaultPos));
                break;

            // 右から左へのフェード
            case Enums.fadeFrom.fromRight:
                // オブジェクトの初期位置をY軸補正値を加算したものに変更する
                corPosSet = defaultPos;
                corPosSet.x += fromPos;
                this.transform.localPosition = corPosSet;

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(CanvasGroupFadeInEnumrator(canvasGroup, fadeTime, moveTime, defaultPos));
                break;

            default:
                // 処理なし
                break;
        }
    }

    /// <summary>
    /// フェードアウトメソッド
    /// <para>　オブジェクトをフェード＋移動させながら消去する。</para>
    /// </summary>
    /// <param name="fromPos">移動前の位置</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="moveTime">移動する時間</param>
    /// <param name="to">移動する方向</param>
    public void FadeOutStart(float fadeTime, float moveTime, Enums.fadeTo to)
    {
        // フェード処理を開始
        isFading = true;

        // オブジェクトの初期位置を変更するため、変更前にスタックしておく
        Vector3 defaultPos = this.transform.localPosition;

        // フェードアウトする方向によりオブジェクトの移動先位置を振り分け
        switch (to)
        {
            // 上へのフェード
            case Enums.fadeTo.toUp:
                // フェード完了位置を設定
                Vector3 toPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
                toPos.y += 200.0f;

                // アルファ値0と255のColorクラスを作成
                Image imageCompo = this.GetComponent<Image>();
                Color fromColor = new Color(255, 255, 255, 0);
                Color toColor = new Color(255, 255, 255, 255);

                // オブジェクト移動とアルファ値のLerp実施
                StartCoroutine(FadeOutEnumrator(imageCompo, fadeTime, moveTime, fromColor, toColor, toPos));
                break;

            default:
                // 処理なし
                break;
        }
    }

    /// <summary>
    /// フェードイン時のカラーおよび位置のLerp実施メソッド
    /// </summary>
    /// <param name="imageCompo">Imageコンポ</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="fromC">初期カラー</param>
    /// <param name="toC">終了時カラー</param>
    /// <param name="defPos">オブジェクトの初期位置</param>
    /// <returns></returns>
    private IEnumerator FadeInEnumrator(Image imageCompo, float fadeTime, float moveTime, Color fromC, Color toC, Vector3 defPos)
    {
        while (true)
        {
            if (this.transform.localPosition == defPos)
            {
                // Lerp処理が終了したらフェード処理を終了してループを抜ける
                isFading = false;
                break;
            }
            // アルファ値をLerp
            imageCompo.color = Color.Lerp(fromC, toC, Time.time * fadeTime);

            // 補正値を加えた現在位置→初期位置へLerp
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, defPos, Time.time * moveTime);

            yield return null;
        }
    }

    /// <summary>
    /// フェードイン時のカラーおよび位置のLerp実施メソッド（CanvasGroup用）
    /// </summary>
    /// <param name="imageCompo">Imageコンポ</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="defPos">オブジェクトの初期位置</param>
    /// <returns></returns>
    private IEnumerator CanvasGroupFadeInEnumrator(CanvasGroup canvasGroup, float fadeTime, float moveTime, Vector3 defPos)
    {
        while (true)
        {
            if (this.transform.localPosition == defPos)
            {
                // Lerp処理が終了したらフェード処理を終了してループを抜ける
                isFading = false;
                break;
            }
            // アルファ値をLerp
            canvasGroup.alpha = Time.time * fadeTime;

            // 補正値を加えた現在位置→初期位置へLerp
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, defPos, Time.time * moveTime);

            yield return null;
        }
    }

    /// <summary>
    /// フェードアウト時のカラーおよび位置のLerp実施メソッド
    /// </summary>
    /// <param name="imageCompo">Imageコンポ</param>
    /// <param name="fadeTime">フェードする時間</param>
    /// <param name="fromC">初期カラー</param>
    /// <param name="toC">終了時カラー</param>
    /// <returns></returns>
    private IEnumerator FadeOutEnumrator(Image imageCompo, float fadeTime, float moveTime, Color fromC, Color toC, Vector3 endPos)
    {
        while (true)
        {
            if (toC == imageCompo.color)
            {
                // オブジェクトが透明になったらフェード処理を終了してループを抜ける
                isFading = false;
                break;
            }
            // アルファ値をLerp
            imageCompo.color = Color.Lerp(fromC, toC, Time.time * fadeTime);

            // 現在位置→フェード完了位置へLerp
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, endPos, Time.time * moveTime);

            yield return null;
        }
    }
}
