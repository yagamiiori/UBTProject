using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ユーザーヘルプメッセージ表示クラス
/// <para>　バトルフィールドにおいて、マスター/スレイブ判定を行い、</para>
/// <para>　自分がマスターなら1P側に、スレイブなら2P側にユーザーヘルプメッセージを表示する。</para>
/// </summary>
public class SetUserHelpInBattleField : Photon.MonoBehaviour
{
    /// <summary>
    /// 自分のユーザーヘルプ
    /// </summary>
    private string myUserHelp = "";
    /// <summary>
    /// 相手のユーザーヘルプ
    /// </summary>
    private string oppUserHelp = "";
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetUserHelpInBattleField() { }

    void Start()
    {
        // 自分のユーザーヘルプを取得する
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myUserHelp = gameManager.userHelp;
    }

    /// <summary>
    /// RPCによる相手側ユーザーヘルプメッセージ取得開始メソッド
    /// </summary>
    public void StartGetUserHelp()
    {
        // RPCを投げて相手のユーザーヘルプメッセージを取得する
        SendingUserHelpRPC();
    }

    /// <summary>
    /// ユーザーヘルプメッセージ表示メソッド
    /// <para>　自分のヘルプメッセージとRPCにて取得した相手のヘルプメッセージをTextコンポに表示する。</para>
    /// </summary>
    private void SetUserHelp()
    {
        // マスター側のヘルプメッセージ表示用Textコンポを取得
        var userHelpText1P = this.gameObject.transform.FindChild("Help_1P").GetComponent<Text>();
        // スレイブ側のヘルプメッセージ表示用Textコンポを取得
        var userHelpText2P = this.gameObject.transform.FindChild("Help_2P").GetComponent<Text>();

        if (PhotonNetwork.isMasterClient)
        {
            // 自分がマスターの場合、マスター側のTextコンポに自分のユーザー名を設定
            userHelpText1P.text = myUserHelp;
            userHelpText2P.text = oppUserHelp;
        }
        else
        {
            // 自分がスレイブの場合、スレイブ側のTextコンポに自分のユーザー名を設定
            userHelpText2P.text = myUserHelp;
            userHelpText1P.text = oppUserHelp;
        }
    }

    [PunRPC]
    public void RecivedUserHelpRPC(string oppHelp, PhotonMessageInfo inf)
    {
        // 受信した相手のユーザーヘルプを取得したらSetUserHelp()メソッドをコール
        oppUserHelp = oppHelp;
        SetUserHelp();
    }

    [PunRPC]
    public void SendingUserHelpRPC()
    {
        // ユーザーヘルプを相手に送信
        photonView.RPC("RecivedUserHelpRPC", PhotonTargets.Others, (string)myUserHelp);
    }

    /// <summary>
    /// 形だけ記載
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="info"></param>
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) { }
}
