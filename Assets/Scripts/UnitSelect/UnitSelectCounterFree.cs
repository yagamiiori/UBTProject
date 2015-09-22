using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectCounterFree : MonoBehaviour
{
    private Text a;                                 // テキストコンポ
    private int b;                                  // 選べる残りユニット数
    private GameManager gameManager;                // マネージャコンポ

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // Textコンポを取得
        a = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        // 選べる残りユニット数を計算
        b = gameManager.opt_unitNum - gameManager.unt_NowAllUnits;

        // 選べる残りユニット数を表示
        a.text = b.ToString();
    }
}
