using UnityEngine;
using System.Collections;

/// <summary>
/// UnitStateシーン専用Photonネットワーク切断クラス
/// <para>　本シーンは一度ユニットリストをクリアするため</para>
/// <para>　UnitFormからの遷移時においてはPhotonに接続されている</para>
/// <para>　可能性があるため、接続処理を実施する。</para>
/// </summary>
public class PUNdisconnectInUnitSelect : MonoBehaviour
{
	void Start ()
    {
        // Photonネットワーク切断メソッドをコールしてPhotonから切断する
        var t = new PhotonNetworkDisconnecter();
        t.PhotonDisconnecter();
	}
}
