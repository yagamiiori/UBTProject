using UnityEngine;
using System.Collections;

public class BattleFieldRPC : Photon.MonoBehaviour
{
    public static bool myTurnJud;                              // ターン判定フラグ
    public PhotonView photonView;                              // 自身のphotonView

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // とりあえずマスターが先行ターン
        if (2 != PhotonNetwork.countOfPlayers) myTurnJud = true;

        // 自身のphotonViewを取得（photonViewコンポを最低一つはアタッチしていること）
        photonView = this.gameObject.GetComponent<PhotonView>();
    }

    // ------------------------------------------------------------------------
    // ターン判定受信メソッド
    // 相手側よりRPCにて送信されるターン判定を受信し、自分のターンであれば
    // myTurnJudをtrueにして自分のターン行動を行う。
    // ------------------------------------------------------------------------
    [PunRPC]
    public void RecivedTurnRPC(bool turn, PhotonMessageInfo inf)
    {
        // dataを受け取る処理を記述
        Debug.Log("相手プレイヤーよりRPC受信");

        // 受信したターン判定フラグを設定
        myTurnJud = turn;
    }

    // ------------------------------------------------------------------------
    // ターン判定送信メソッド
    // 相手側へRPCにてターン判定を送信する。
    // 同時に、myTurnJudをfalseにして自分のターン行動を終了する。
    // ------------------------------------------------------------------------
    [PunRPC]
    public void SendingTurnRPC()
    {
        // ターン判定フラグを送信（相手側をtrue）
        photonView.RPC("RecivedTurnRPC", PhotonTargets.Others, (bool)true);

        // 自分側ターンをfalseに
        myTurnJud = false;
    }
}
