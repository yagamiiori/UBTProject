using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitNameSetForSceneLoading : MonoBehaviour
{
    /// <summary>ユニット名表示用テキストフィールドリスト</summary>
    public List<InputField> UnitNameList = new List<InputField>();
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;

    /// <summary>コンストラクタ</summary>
    private UnitNameSetForSceneLoading() { }

    void Start()
    {
        // マネージャコンポを取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 全ユニット数分のユニット名表示用テキストコンポを取得し、リストに格納
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName0").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName1").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName2").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName3").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName4").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName5").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName6").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName7").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName8").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName9").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName10").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName11").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName12").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName13").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName14").GetComponent<InputField>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName15").GetComponent<InputField>());

        int unitID = 0;
        foreach (InputField t in UnitNameList)
        {
            // ユニット名をユニットネーム表示枠に設定
            t.text = gameManager.unitStateList[unitID].unitName;

            unitID++;
        }
    }
}
