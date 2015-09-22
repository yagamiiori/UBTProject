using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectCounterTotal : MonoBehaviour
{

    private GameManager gameManager;                // マネージャコンポ
    private Text a;

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // Textコンポを取得
        a = this.gameObject.GetComponent<Text>();

        // 選べる残りユニット数を表示
        a.text = gameManager.opt_unitNum.ToString();

    }
}
