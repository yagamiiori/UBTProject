using UnityEngine;
using System.Collections;

/// <summary>
/// Photonネットワーク切断クラス
/// <para>　Photonからの切断を行う。</para>
/// </summary>
public class PhotonNetworkDisconnecter : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    public PhotonNetworkDisconnecter() { }

    /// <summary>
    /// Photonネットワーク切断メソッド
    /// <para>　Photonから切断する。
    /// </summary>
	public void PhotonDisconnecter ()
    {
        // メインサーバから切断する
        PhotonNetwork.Disconnect();
	}
}
