using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerInUnitPlace : Photon.MonoBehaviour
{
    /// <summary>タイマー値　※インスペクタから設定する</summary>
    [SerializeField]
    private float timerValue = 0;
    /// <summary>初期配置選択中タイマーのTextコンポ</summary>
    private Text timerValueText;
    /// <summary>初期配置選択中タイマーMAX値のTextコンポ</summary>
    private Text maxTimerValueText;
    /// <summary>経過した秒</summary>
    private float elapsedSec = 0;
    /// <summary>時間経過測定実施有無判定</summary>
    private bool isTimerStop = false;
    /// <summary>初期配置時のRPC管理クラス</summary>
    private UnitPlaceCompJudRPC unitPlaceCompJudRPC;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private TimerInUnitPlace() { }

	void Start()
    {
        // 初期配置時のRPC管理クラスを取得
        unitPlaceCompJudRPC = GameObject.Find("Canvas_StartUpBeforeBattleStart").GetComponent<UnitPlaceCompJudRPC>();

        // インスペクタから設定し忘れていたらデフォルト値を入れる
        if (0 == timerValue) timerValue = 50;

        // 初期配置選択中タイマー、および初期配置選択中タイマーMax値のTextコンポ取得
        timerValueText = this.gameObject.transform.FindChild("Value").gameObject.GetComponent<Text>();
        maxTimerValueText = this.gameObject.transform.FindChild("MaxTime").gameObject.GetComponent<Text>();
        maxTimerValueText.text = timerValue.ToString(); // MAX値表示TextにMax値を設定
	}

	void FixedUpdate()
    {
        if (unitPlaceCompJudRPC.isCompleteMySide && unitPlaceCompJudRPC.isCompleteEnemySide)
        {
            // 自分/相手共に初期配置が完了、かつ自分がマスタークライアントの場合
            if (PhotonNetwork.isMasterClient)
            {
                // BattleState更新メソッドをコールしてBattleStateを「BattleNow」に更新する
                var roomCPmanager = GameObject.Find("Canvas").GetComponent<RoomCPManager>();
                roomCPmanager.BattleStateChanger(Enums.BattleState.BattleNow);
            }
        }

        if (!isTimerStop)
        {
            // 経過時間を測定
            elapsedSec += Time.deltaTime * 1;
            Mathf.Floor(elapsedSec % 60f);

            // タイマー値をTextコンポに書き出し
            timerValueText.text = Mathf.Ceil(timerValue - elapsedSec).ToString();

            // 時間切れにより初期配置が強制完了した場合
            if (0 > (timerValue - elapsedSec))
            {
                // 閾値0で固定して時間経過測定実施有無判定をfalseに設定する
                timerValue = 0;
                elapsedSec = 0;
                isTimerStop = true;

                // 初期配置完了報告送信メソッドをコールして完了を相手側に通知する
                unitPlaceCompJudRPC.SendCompRPC();
            }
        }
        // 時間切れになった場合は文字を表示してタイムオーバーになった事を示す
        if (isTimerStop && "Over" != timerValueText.text) timerValueText.text = "Over";
    }
}
