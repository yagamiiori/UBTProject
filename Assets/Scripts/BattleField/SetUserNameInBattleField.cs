using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ユーザー名表示クラス
/// <para>　バトルフィールドにおいて、マスター/スレイブ判定を行い、</para>
/// <para>　自分がマスターなら1P側に、スレイブなら2P側にユーザー名を表示する。</para>
/// </summary>
public class SetUserNameInBattleField : Photon.MonoBehaviour
{
    /// <summary>
    /// 自分のユーザー名
    /// </summary>
    private string myUserName = "";
    /// <summary>
    /// 相手のユーザー名
    /// </summary>
    private string oppUserName = "";
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private SetUserNameInBattleField() { }

    void Start()
    {
        // 自分のユーザー名を取得する
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myUserName = gameManager.userName;
    }

    /// <summary>
    /// RPCによる相手側ユーザー名取得開始メソッド
    /// </summary>
    public void StartGetUserName()
    {
        // RPCを投げて相手のユーザー名を取得する
        SendingUserNameRPC();
    }

    /// <summary>
    /// ユーザー名表示メソッド
    /// <para>　自分のユーザー名とRPCにて取得した相手のユーザー名をTextコンポに表示する。</para>
    /// </summary>
    private void SetUserName()
    {
        // マスター側のユーザー名表示用Textコンポを取得
        var userText1P = this.gameObject.transform.FindChild("Name_1P").GetComponent<Text>();
        // スレイブ側のユーザー名表示用Textコンポを取得
        var userText2P = this.gameObject.transform.FindChild("Name_2P").GetComponent<Text>();

        if (PhotonNetwork.isMasterClient)
        {
            // 自分がマスターの場合、マスター側のTextコンポに自分のユーザー名を設定
            userText1P.text = myUserName;
            userText2P.text = oppUserName;
        }
        else
        {
            // 自分がスレイブの場合、スレイブ側のTextコンポに自分のユーザー名を設定
            userText2P.text = myUserName;
            userText1P.text = oppUserName;
        }
    }

    [PunRPC]
    public void RecivedUserNameRPC(string oppName, PhotonMessageInfo inf)
    {
        // 受信した相手のユーザー名を取得したらSetUserName()メソッドをコール
        oppUserName = oppName;
        SetUserName();
    }

    [PunRPC]
    public void SendingUserNameRPC()
    {
        // ユーザー名を相手に送信
        photonView.RPC("RecivedUserNameRPC", PhotonTargets.Others, (string)myUserName);
    }

    /// <summary>
    /// 形だけ記載
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="info"></param>
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) { }
}
