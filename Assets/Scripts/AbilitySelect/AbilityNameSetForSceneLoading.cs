using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class AbilityNameSetForSceneLoading : MonoBehaviour
{
    //// <summary>全ユニット数（16個）分のアビリティ名表示用テキストフィールドリスト</summary>
    private List<Text> AbilityNameList = new List<Text>();
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>アビリティID→文字列変換クラス</summary>
    private AbilityIDtoStringConv convertAbilityIDtoStrings;

    /// <summary>コンストラクタ</summary>
    public AbilityNameSetForSceneLoading() { }

    /// <summary>
    /// シーンロード時アビリティ名表示フィールド設定メソッド
    /// <para>　シーンがロードされる時に設定されているアビリティがあれば</para>
    /// <para>　表示する。一度このシーンにてアビリティを設定後、ユニットフォームを経て</para>
    /// <para>　再度このシーンに来た時は設定済みアビリティ名が本メソッドにより</para>
    /// <para>　アビリティ表示枠に表示される。</para>
    /// </summary>
    public void SetMethod()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // アビリティID→文字列変換クラスを取得
        convertAbilityIDtoStrings = new AbilityIDtoStringConv();

        // 全ユニット数分のアビリティ名表示用テキストコンポを取得し、リストに格納
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName0").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName1").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName2").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName3").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName4").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName5").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName6").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName7").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName8").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName9").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName10").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName11").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName12").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName13").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName14").GetComponent<Text>());
        AbilityNameList.Add(GameObject.FindWithTag("Abl_SetAbilityName15").GetComponent<Text>());

        int unitID = 0;
        foreach (Text t in AbilityNameList)
        {
            // アビリティID→アビリティ文字列正引きメソッドをコール
            string abilityName = convertAbilityIDtoStrings.Converter(gameManager.unitStateList[unitID].ability_A);

            // 引いてきたアビリティ名をアビリティ表示枠に設定
            t.text = abilityName;

            unitID++;
        }
    }
}
