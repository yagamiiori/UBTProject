using UnityEngine;
using System.Collections;

public class ButtonSceneReLoad : MonoBehaviour
{
    /// <summary>リロード後、ConnectUsingSettingsにより再接続が完了したか否か</summary>
    private bool isConnectedForPhotonNetwork = false;

    /// <summary>コンストラクタ</summary>
    private ButtonSceneReLoad() { }

    void Update()
    {
        if (isConnectedForPhotonNetwork)
        {
            // リロード後、Photonに再接続が完了したらロビーに入る
            PhotonNetwork.JoinLobby();
            isConnectedForPhotonNetwork = false;
        }
    }

    /// <summary>
    /// シーンリロードメソッド
    /// <para>　シーンリロードボタンよりコールされ、Lobbyシーンにおける</para>
    /// <para>　Photonネットワークの切断および再接続を実施する。</para>
    /// </summary>
    public void OnClick() 
    {
        // 一度Photonネットワークから切断、その後再接続を行う
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectUsingSettings("v0.1");
        // ConnectUsingSettingsは非同期処理のため接続完了を待ち、完了後にロビーに入らなければならない
        isConnectedForPhotonNetwork = true;
    }
}
