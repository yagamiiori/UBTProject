using UnityEngine;
using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////
//　関数名：コマンド「移動」計算クラス
//　機能：ユニットの移動距離や箇所を測定、算出する
//　継承：MonoBehaviour
//　種別：通常クラス
//　アタッチ先：コマンドパネル
//　保持メソッド：CommandJudge
//　リダイレクト：なし
//
//　詳細：
//　　　　コマンド種別振り分けクラス（CommandOrder_Main）からコールされ、
//　　　　移動できる場所や距離を測定および判定し、その結果をユニットへ通知する。
//　　　　ユニットは指定せず、全ユニットへSendMessageによりブロードし、
//　　　　ユニットオブジェクト側で現在行動可能ユニットのみ、受け取った算出結果に
//　　　　従って移動を実施する。
//
//  呼び出し例：
//
//　履歴：
//
////////////////////////////////////////////////////////////////////////////////////////
public class CommandOrder_Move : MonoBehaviour
{
    public GameObject[] unitObject;       // ユニットオブジェクト
    public int calcResult;                // 計算結果
    public GameObject[] panelObject;      // パネルオブジェクト

    void Start()
    {
        // ユニットオブジェクト取得
        unitObject = GameObject.FindGameObjectsWithTag("Unit");

        // パネルオブジェクト取得
        panelObject = GameObject.FindGameObjectsWithTag("Panel");
    }

    // ----------------------------
    // 移動場所算出メソッド
    // 計算や測定、移動できる範囲を算出する
    // 算出した結果はSendMessageで全ユニットオブジェクトに投げて
    // 行動可能判定フラグがtrueのユニット(WT=0になっているユニット)
    // のみ、算出した結果に従ってパネル移動を実施する
    // ----------------------------
    public void MoveCalc()
    {
        // 計算式とか書く

        // 移動先選択待ちメソッドコール
        StartCoroutine("WaitingPanelSelect");
    }

    // ----------------------------
    // 移動先選択待ちメソッド
    // 機能：
    // 　　　①移動可能パネルを光らせる
    // 　　　②移動先が選択されるのを待ち受ける
    // 　　　③移動先が選択されたら移動実施メソッドをコールする
    // ----------------------------
    public IEnumerator WaitingPanelSelect()
    {
        // パネルPalFx発光メソッドコール
//        panelObject[0].GetComponent<AddObjectColor>().PalfxStart(0.5f, 0.1f, 0.5f, Color.blue, panelObject[0]);

        // 選択待ちループ
        while (true)
        {
/*
            if (移動可能なパネルが選択された場合)
            {
                // 算出結果を全ユニットへブロード
                unitObject.SendMessage("RecivedMoveCalc_FromSendMessage");

                // ↑最終的には算出結果を引数につけて渡したい
                // unitObject.SendMessage("RecivedMoveCalc_FromSendMessage", calcResult);

                yield break;
            }
*/
            yield return 0;
        }
    }
}
