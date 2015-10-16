using UnityEngine;
using System.Collections;

/// <summary>
/// マスタークライアント判定クラス
/// <para>　自身がルーム内でマスタークライアントか否かを判定する。</para>
/// </summary>
public class MasterClientJud : MonoBehaviour
{
    /// <summary>マスタークライアント判定</summary>
    public bool isMaster = false;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private MasterClientJud() { }

	void Start ()
    {
        isMaster = PhotonNetwork.isMasterClient;
	}
}
