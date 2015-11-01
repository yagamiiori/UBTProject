using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// BattleStartクラス
/// <para>　ユニットの初期配置完了後にコールされ、以下のBattleStart処理を上から順に実施する。</para>
/// <para>　　・画面全体を黄色化</para>
/// <para>　　・黒帯背景の表示</para>
/// <para>　　・BattleStart文字の表示と移動</para>
/// <para>　　・UnitPlaceeタイマウィンドウのキャンバスを破棄
/// <para>　　・WTパネルをアクティブ化
/// <para>　　・黒帯背景の消去</para>
/// <para>　　・画面全体の黄色化を解除</para>
/// <para>　　・FieldStatusウィンドウをアクティブ化</para>
/// <para>　　・画面カラーのキャンバスを破棄</para>
/// </summary>
public class BattleStart : MonoBehaviour
{
    /// <summary>画面カラーのフェード時間</summary>
    public float fadeTime = 0;
    /// <summary>経過した秒</summary>
    private float elapsedSec = 0;
    /// <summary>フェード実施中判定</summary>
    private bool isFading = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private BattleStart() { }

    /// <summary>
    /// BattleStart初期起動メソッド
    /// </summary>
    public void StartingMeth()
    {
        // 画面カラーのフェード時間がインスペクタから設定されてなければ初期化する
        if (0 == fadeTime) fadeTime = 0.9f;

        // 画面カラーCanvasをアクティブ化し、ゲームオブジェクトとコンポを取得
        var dispColorCanv = GameObject.Find("Canvas_DisplayColor");
        var dispColorCompo = dispColorCanv.GetComponent<DisplayColorActiveManager>();
        dispColorCompo.displayColorParentGO.SetActive(true);
        var imageGO = GameObject.Find("DisplayColorAtBattleStart");
        var imageCompo = imageGO.GetComponent<Image>();

        // 初期カラーと到達カラーを設定
        Color startColor = new Color(0.51f, 0.41f, 0.13f, 0);
        Color endColor = new Color(0.51f, 0.41f, 0.13f, 0.601f);

        // 画面カラー透明→黄色メソッドをコール
        StartCoroutine(ColorUp(startColor, endColor, imageCompo));

        // 画面カラー黄色→透明メソッドをコール
        StartCoroutine(ColorDown(startColor, endColor, imageCompo));

        // 画面カラーゲームオブジェクトを破棄する
        var displayColorCanv = GameObject.Find("Canvas_DisplayColor");
        if (!isFading) Destroy(displayColorCanv);
    }

    /// <summary>
    /// 画面カラー透明→黄色変更メソッド
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="imageCompo"></param>
    /// <returns></returns>
    private IEnumerator ColorUp(Color a, Color b, Image imageCompo)
    {
        // フェード処理開始を宣言
        isFading = true;

        // 経過時間を初期化
        elapsedSec = 0;
        while (true)
        {
            if (b == imageCompo.color)
            {
                // Lerp処理が終了したら黒背景表示メソッドをコールし、ループを抜ける
                StartCoroutine(ViewBgBlackCor());
                break;
            }
            // アルファ値をLerp
            elapsedSec += Time.deltaTime;
            imageCompo.color = Color.Lerp(a, b, elapsedSec * fadeTime);
            yield return null;
        }
    }

    /// <summary>
    /// 画面カラー黄色→透明変更メソッド
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="imageCompo"></param>
    /// <returns></returns>
    private IEnumerator ColorDown(Color a, Color b, Image imageCompo)
    {
        // BattleStart画像表示中は処理を停止する
        yield return new WaitForSeconds(5.0f);

        // 経過時間を初期化
        elapsedSec = 0;
        while (true)
        {
            if (a == imageCompo.color)
            {
                // FieldStatusウィンドウをアクティブ化
                var fieldStatusGO = GameObject.Find("Canvas_FieldStatusWindow").GetComponent<FieldStatusActiveManager>();
                fieldStatusGO.fieldStatusWindowParentGO.SetActive(true);

                // 画面カラーキャンバスを破棄
                var dispColorGO = GameObject.Find("Canvas_DisplayColor");
                Destroy(dispColorGO);

                // フェード終了を宣言
                isFading = false;

                // Lerp処理が終了したらループを抜ける
                yield return new WaitForSeconds(0.6f);
                break;
            }
            // アルファ値をLerp
            elapsedSec += Time.deltaTime;
            imageCompo.color = Color.Lerp(b, a, elapsedSec * fadeTime);
            yield return null;
        }
    }

    /// <summary>
    /// 黒背景表示メソッド
    /// <para>　黒背景を表示する。</para>
    /// </summary>
    /// <returns></returns>
    private IEnumerator ViewBgBlackCor()
    {
        // 一時停止
        yield return new WaitForSeconds(0.5f);

        // 黒背景ゲームオブジェクトを取得
        var bgBlack = GameObject.Find("Text_BattleStartParent").transform.FindChild("BGblack");
        // スケーリングする速度を設定
        float scalingTime = 6.6f;

        // 黒背景のY値の初期値と到達値を設定
        Vector3 a = new Vector3(1, 0, 1);
        Vector3 b = new Vector3(1, 1, 1);

        // 経過時間を初期化
        elapsedSec = 0;
        while (true)
        {
            if (b == bgBlack.transform.localScale)
            {
                // BattleStart黒背景画像消去メソッドをコール
                StartCoroutine(DeleteBgBlackCor());

                // 非同期でBattleStart文字表示メソッドをコール
                StartCoroutine(ViewBattleStartText());

                // Lerp処理が終了したらループを抜ける
                break;
            }
            // 黒背景のY値のスケールをLerp
            elapsedSec += Time.deltaTime;
            bgBlack.transform.localScale = Vector3.Lerp(a, b, elapsedSec * scalingTime);
            yield return null;
        }
    }

    /// <summary>
    /// 黒背景消去メソッド
    /// <para>　黒背景を消去する。</para>
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeleteBgBlackCor()
    {
        // 一時停止
        yield return new WaitForSeconds(3.0f);

        // 黒背景ゲームオブジェクトを取得
        var bgBlack = GameObject.Find("Text_BattleStartParent").transform.FindChild("BGblack");
        // スケーリングする速度を設定
        float scalingTime = 6.6f;

        // 黒背景のY値の初期値と到達値を設定
        Vector3 a = new Vector3(1, 0, 1);
        Vector3 b = new Vector3(1, 1, 1);

        // 経過時間を初期化
        elapsedSec = 0;
        while (true)
        {
            if (a == bgBlack.transform.localScale)
            {
                // Lerp処理が終了したらループを抜ける
                break;
            }
            // 黒背景のY値のスケールをLerp
            elapsedSec += Time.deltaTime;
            bgBlack.transform.localScale = Vector3.Lerp(b, a, elapsedSec * scalingTime);
            yield return null;
        }
    }

    /// <summary>
    /// BattleStart文字表示メソッド
    /// <para>　BattleStart文字のフェード表示と移動、フェードアウトまでを管理する。</para>
    /// </summary>
    /// <returns></returns>
    private IEnumerator ViewBattleStartText()
    {
        // BattleStart文字ゲームオブジェクトを取得
        var textBattleStart = GameObject.Find("Text_BattleStartParent").transform.FindChild("Text");
        // BattleStart文字Textコンポ取得
        var textImageCompo = textBattleStart.gameObject.GetComponent<Text>();
        // 初速度を設定
        float addFource = 6.6f;
        // ゆっくり速度を設定
        float slowFource = 0.5f;
        // 消去速度を設定
        float afterFource = 6.6f;
        /// <summary>画面カラーのフェードイン時間</summary>
        float fadeInTime = 1.6f;
        /// <summary>画面カラーのフェードアウト時間</summary>
        float fadeOutTime = 6.2f;
        // BattleStartTextが移動する初期位置
        Vector3 a = new Vector3(403, 56, 0);
        // BattleStartTextが移動する画面中央位置
        Vector3 b = new Vector3(80, 56, 0);
        // BattleStartTextが移動するゆっくり速度開始位置
        Vector3 c = new Vector3(80, 56, 0);
        // BattleStartTextが移動するゆっくり速度終了位置
        Vector3 d = new Vector3(30, 56, 0);
        // BattleStartTextが移動する消去開始位置
        Vector3 e = new Vector3(30, 56, 0);
        // BattleStartTextが移動する消去完了位置
        Vector3 f = new Vector3(-300, 56, 57);
        // フェード時のカラーを作成
        Color colorA = new Color(1, 1, 1, 1);
        Color colorB = new Color(1, 1, 1, 0);

        // 初速
        while (true)
        {
            if (b == textBattleStart.transform.localPosition)
            {
                // ここのタイミングでUnitPlaceeタイマとかのウィンドウを破棄する
                var canvas = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<CanvasDelete>();
                canvas.Delete();

                // WTパネルをアクティブ化
                var wtPanel = GameObject.Find("Canvas_WaitTurnPanel").GetComponent<WaitTurnPanelActiveManager>();
                wtPanel.waitTurnPanelParentGO.SetActive(true);

                // positionおよびcolorのLerp処理が終了したら経過時間をクリアしてループを抜ける
                elapsedSec = 0;
                break;
            }
            // BattleStart文字の移動位置をLerp
            elapsedSec += Time.deltaTime;
            textBattleStart.transform.localPosition = Vector3.Lerp(a, b, elapsedSec * addFource);

            // BattleStartTextコンポのカラーをLerp
            textImageCompo.color = Color.Lerp(colorB, colorA, elapsedSec * fadeInTime);

            yield return null;
        }
        // ゆっくり
        while (true)
        {
            if (d == textBattleStart.transform.localPosition)
            {
                // Lerp処理が終了したら経過時間をクリアしてループを抜ける
                elapsedSec = 0;
                break;
            }
            // BattleStart文字の移動位置をLerp
            elapsedSec += Time.deltaTime;
            textBattleStart.transform.localPosition = Vector3.Lerp(c, d, elapsedSec * slowFource);

            // BattleStartTextコンポのカラーをLerp
            textImageCompo.color = Color.Lerp(textImageCompo.color, colorA, elapsedSec * fadeInTime);

            yield return null;
        }
        // 消去
        while (true)
        {
            if (f == textBattleStart.transform.localPosition)
            {
                // Lerp処理が終了したら経過時間をクリアしてループを抜ける
                elapsedSec = 0;
                break;
            }
            // BattleStart文字の移動位置をLerp
            elapsedSec += Time.deltaTime;
            textBattleStart.transform.localPosition = Vector3.Lerp(e, f, elapsedSec * afterFource);

            // BattleStartTextコンポのカラーをLerp
            textImageCompo.color = Color.Lerp(colorA, colorB, elapsedSec * fadeOutTime);
            yield return null;
        }
    }
}
