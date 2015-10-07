using UnityEngine;
using System.Collections;

public class RollingGiar : MonoBehaviour
{
    /// <summary>角度</summary>
    private Vector3 angle = new Vector3(0, 0, 0);

    /// <summary>コンストラクタ</summary>
    private RollingGiar() { }
	
	void Update ()
    {
        angle.z += Time.deltaTime* 3.0f;
        this.gameObject.transform.eulerAngles = angle;
	}
}
