using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : Photon.MonoBehaviour 
{
    /// <summary>タイマー値　※インスペクタから設定する</summary>
    [SerializeField]
    private float timerValue = 50;
    /// <summary>初期配置選択中タイマーのTextコンポ</summary>
    private Text timerValueText;
    /// <summary>経過した秒</summary>
    private float elapsedSec = 0;
    /// <summary>初期配置選択中タイマーMAX値のTextコンポ</summary>
    private Text maxTimerValueText;

    void Start()
    {
        // 初期配置選択中タイマー、および初期配置選択中タイマーMax値のTextコンポ取得
        timerValueText = this.gameObject.GetComponent<Text>();
//        timerValueText = this.gameObject.transform.FindChild("Value").gameObject.GetComponent<Text>();
//        maxTimerValueText = this.gameObject.transform.FindChild("MaxTime").gameObject.GetComponent<Text>();
//        maxTimerValueText.text = timerValue.ToString(); // MAX値表示TextにMax値を設定
    }

    void Update()
    {
        // 経過時間を測定
//        elapsedSec += Time.deltaTime * 1;
//        timerValue = (int)Mathf.Floor(timerValue - (elapsedSec % 60f));
//        timerValue -= 1f * Time.deltaTime;

        // タイマー値をTextコンポに書き出し
//        timerValueText.text = ((int)timerValue).ToString();
        if (PhotonNetwork.isMasterClient)
        {
            timerValue += 1;
            timerValueText.text = timerValue.ToString();
        }
    }
}
