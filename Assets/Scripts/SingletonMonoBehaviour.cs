using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

//================================
// シングルトンクラス生成（型引数：<T>）
//================================
public class SingletonMonoBehaviour<T> : MonoBehaviour
    // 型引数TはMonoBehaviourを継承している
    where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }
            return instance;
        }
    }
}
