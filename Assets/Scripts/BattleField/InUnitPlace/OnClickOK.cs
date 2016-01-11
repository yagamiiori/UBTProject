using UnityEngine;
using System.Collections;

/// <summary>
/// OnClickOKクラス（InUnitPlace）
/// <para>　UnitPlaceでOKボタンクリック時のコールバッククラス。</para>
/// </summary>
public class OnClickOK : MonoBehaviour
{
    /// <summary>
    /// バトル参加中ユニットリスト管理クラス
    /// </summary>
    private BattleUnitList unitListInBattle;
    /// <summary>
    /// 初期配置時のRPC管理クラス
    /// </summary>
    private UnitPlaceCompJudRPC unitPlaceCompJudRPC;
    /// <summary>
    /// OKボタンクリック判定
    /// </summary>
    private bool isClick = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private OnClickOK() { }

    void Start()
    {
        //　バトル参加中ユニットリスト管理クラスを取得
        unitListInBattle = GameObject.Find("Canvas").GetComponent<BattleUnitList>();

        // 初期配置時のRPC管理クラスを取得
        unitPlaceCompJudRPC = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceCompJudRPC>();
    }

    public void OnClick()
    {
        // まだOKボタンが押されていない場合（連打の抑止）
        if (!isClick)
        {
            isClick = true;

            // ユニットが最低一人配置されているかを確認
            if (0 == unitListInBattle.myUnits.Count)
            {
                // 一人も配置されていなければランダム配置メソッドをコールし、1人をランダムで配置する
                var setUnitRandom = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<SetUnitRandom>();
                setUnitRandom.Set();
            }
            // 初期配置完了報告送信メソッドをコールして完了を相手側に通知し、自分も完了にする
            unitPlaceCompJudRPC.SendCompRPC();
        }
    }
}
