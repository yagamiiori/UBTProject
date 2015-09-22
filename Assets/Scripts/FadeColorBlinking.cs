using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

////////////////////////////////////////////////////////////////////////////////////////
//　関数名：オブジェクトカラーPalfxクラス
//　機能：オブジェクトのカラーを変更するmugenで言うPalfx
//　継承：MonoBehaviour
//　種別：通常クラス
//　アタッチ先：GameObject
//　保持メソッド：
//　リダイレクト：なし
//
//　詳細：
//　　　　
//
//  呼び出し例：
//
//　履歴：
//
////////////////////////////////////////////////////////////////////////////////////////
public class FadeColorBlinking : MonoBehaviour
{
    private Color from = Color.white;		// 初期カラー（無色）
    private Color to;						// 到達カラー
    private Color now;						// 現在のカラー
    private Color setCloro;					// 指定カラー
    private float time;						// フェードアウト時間
    private float fadewait;					// フェードアウト後の待ち時間
    private float fadeinTime;				// フェードイン時間
    private float waitRestartTime;			// Palfx完了後の待ち時間
    private GameObject targetObject;		// ターゲットオブジェクト
    private Image targetImage;				// Imageコンポ
    private bool roopFlag = true;           // ループフラグ

    // ------------------------
    // Updateメソッド
    // ------------------------
    public void Update()
    {
        if (targetImage) targetImage.color = now;   // ターゲットオブジェクトのカラーをPalfx
    }

    // =====================================================
    // Palfx開始メソッド
    // フェードアウト時間、フェード中待機時間、フェードイン時間、フェード終了後再起動待ち時間、フェードカラー、対象のGameObject
    // 例）青色で点滅させる palfxColor.PalfxStart(0.9f, 0.1f, 0.9f, 1.0f, Color.blue, sprite_Ability);
    // =====================================================
    public void PalfxStart(float t_time, float f_wait, float a_time, float e_time, Color t_color, GameObject go)
    {
        to = setCloro = t_color;
        time = t_time;
        fadewait = f_wait;
        waitRestartTime = e_time;
        targetObject = go;
        targetImage = targetObject.GetComponent<Image>();
        fadeinTime = a_time;
        StartCoroutine(AddPalfx());
    }

    // =====================================================
    // Palfx処理実装コルーチン
    // =====================================================
    public IEnumerator AddPalfx()
    {
        // 永続ループ起動中の場合
        while (true == roopFlag)
        {
            float now_time = 0;
            while (0 < time && now_time < time)
            {
                now_time += Time.deltaTime;
                now = Color.Lerp(from, to, now_time / time);
                yield return 0;
            }

            // フェードアウト完了時のカラーを現カラーに設定
            now = to;

            // フェードアウト完了後の一時停止
            yield return new WaitForSeconds(fadewait);

            // 指定したフェードカラーとフェード時間を設定
            to = setCloro;
            time = fadeinTime;
            float now_time2 = 0;
            while (0 < time && now_time2 < time)
            {
                now_time2 += Time.deltaTime;
                now = Color.Lerp(to, from, now_time2 / time);
                yield return 0;
            }

            // Palfx終了時のカラーを初期カラーに設定
            now = from;

            // 再起動前の一時停止
            yield return new WaitForSeconds(waitRestartTime);
        }
    }

    // =====================================================
    // Palfx停止メソッド
    // =====================================================
    public void PalfxStop()
    {
        roopFlag = false;
    }
}

