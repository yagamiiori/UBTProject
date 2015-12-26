using UnityEngine;
using System.Collections;

public class RollingZodiac : MonoBehaviour
{
    /// <summary>角度</summary>
    private Vector3 angle = new Vector3(0, 0, 0);

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private RollingZodiac() { }

    void Update()
    {
        angle.z += Time.deltaTime * 6.0f;
        this.gameObject.transform.eulerAngles = angle;
    }
}
