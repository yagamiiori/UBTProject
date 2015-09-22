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
public class Palfx : MonoBehaviour
{
    /// <summary>フェードアウト処理を行う秒</summary>
    public float fadeoutSec;
    /// <summary>フェードアウト処理後にその状態を維持する秒</summary>
    public float fadeoutKeepSec;
    /// <summary>フェードイン処理を行う秒</summary>
    public float fadeinSec;
    /// <summary>フェードイン処理後にその状態を維持する秒</summary>
    public float fadeinKeepSec;
    /// <summary>色を明滅させるImage</summary>
    public Image blinkingImage;
    /// <summary>明滅の有無</summary>
    public bool isBlinking = true;
    /// <summary>明滅で変更する前の色（初期値は白）</summary>
    public Color fromColor = Color.white;
    /// <summary>明滅で変更したい色（初期値は青）</summary>
    public Color toColor = Color.blue;
    /// <summary>経過した秒</summary>
    private float elapsedSec = 0;

    /// <summary>
    /// 
    /// </summary>
    public void Update()
    {
        if (isBlinking)
        {
            if(null == blinkingImage)
            {
                return;
            }
            // フェードアウト及びフェードインを行う秒の設定が不正な場合は明滅を行わない
            if(0 >= fadeoutSec || 0 >= fadeinSec)
            {
                return;
            }
            elapsedSec += Time.deltaTime;
            if(elapsedSec < fadeoutSec)
            {
                // フェードアウト時間中はtoColorへと徐々に変化させる
                blinkingImage.color = Color.Lerp(fromColor, toColor, elapsedSec / fadeoutSec);
            }
            else if(elapsedSec < fadeoutSec + fadeoutKeepSec)
            {
                // フェードアウト維持時間中はtoColorの色を維持する
                blinkingImage.color = toColor;
            }
            else if(elapsedSec < fadeoutSec + fadeoutKeepSec + fadeinSec)
            {
                // フェードイン時間中はfromColorへと徐々に変化させる
                blinkingImage.color = Color.Lerp(toColor, fromColor, (elapsedSec - fadeoutSec - fadeoutKeepSec) / fadeinSec);
            }
            else if(elapsedSec < fadeoutSec + fadeoutKeepSec + fadeinSec + fadeinKeepSec)
            {
                // フェードイン維持時間中はfromColorの色を維持する
                blinkingImage.color = fromColor;
            }
            else
            {
                // 全ての処理が完了したら経過時間を0に戻してフェードアウトから再度実行する
                elapsedSec = 0;
            }
        }
    }

    public void blinkingStart()
    {
        isBlinking = true;
    }

    public void blinkingStop()
    {
        isBlinking = false;
    }

    public void blinkingReset()
    {
        if(null == blinkingImage)
        {
			// ターゲットとなるImageコンポが存在しない場合はリセット処理を行わない
            return;
        }
        
        // ターゲットのImageコンポのカラーを明滅で変更する前の色にする
        blinkingImage.color = fromColor;
        
        // 経過時間を0にする
        elapsedSec = 0;
    }
}

