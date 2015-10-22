using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 1P2P初期配置Completeテキスト表示クラス
/// <para>　ウィンドウのComplete表示を実施する。</para>
/// <para>　マスタークライアントなら1P側、そうでないなら2P側に表示する。</para>
/// </summary>
public class CompleteStatusViewer : MonoBehaviour
{
    /// <summary>1P側Complete表示用Textコンポ</summary>
    private Text master;
    /// <summary>2P側Complete表示用Textコンポ</summary>
    private Text slave;
    /// <summary>初期配置時のRPC管理クラス</summary>
    private UnitPlaceCompJudRPC unitPlaceCompJudRPC;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CompleteStatusViewer() { }

    void Start()
    {
        // 初期配置時のRPC管理クラスを取得
        unitPlaceCompJudRPC = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceCompJudRPC>();

        // 1P2PのTextコンポ取得、およびテキストの初期化
        master = this.gameObject.transform.FindChild("1Pvalue").gameObject.GetComponent<Text>();
        slave = this.gameObject.transform.FindChild("2Pvalue").gameObject.GetComponent<Text>();
        master.text = "- - - - - -";
        slave.text = "- - - - - -";
    }
	
	void Update ()
    {
        // 自分のComplete表示
        if (unitPlaceCompJudRPC.isCompleteMySide)
        {
            if (PhotonNetwork.isMasterClient)
            {
                // 自分がマスタークライアントの場合
                master.text = "Complete!";
            }
            else
            {
                // 相手はスレイブ
                slave.text = "Complete!";
            }
        }
        // 相手のComplete表示
        if (unitPlaceCompJudRPC.isCompleteEnemySide)
        {
            if (PhotonNetwork.isMasterClient)
            {
                // 自分がマスタークライアントの場合、相手はスレイブにComplete
                slave.text = "Complete!";
            }
            else
            {
                // 自分がスレイブの場合、相手はマスタークライアントにComplete
                master.text = "Complete!";
            }
        }
	}
}
