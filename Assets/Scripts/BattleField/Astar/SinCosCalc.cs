using UnityEngine;
using System.Collections;

public class SinCosCalc : MonoBehaviour
{
	void Start ()
    {
	
	}

    /// <summary>
    /// Mathf.Cosの角度指定版
    /// </summary>
    /// <param name="Deg"></param>
    /// <returns></returns>
    public static float CosEx(float Deg)
    {
        return Mathf.Cos(Mathf.Deg2Rad * Deg);
    }

    /// <summary>
    /// Mathf.Sinの角度指定版
    /// </summary>
    /// <param name="Deg"></param>
    /// <returns></returns>
    public static float SinEx(float Deg)
    {
        return Mathf.Sin(Mathf.Deg2Rad * Deg);
    }
}
