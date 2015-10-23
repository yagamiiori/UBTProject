using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitForm : MonoBehaviour
{
    /// <summary>ユニット選択判定（初期化値:100）</summary>
    public int unitSelect = 100;
    /// <summary>Canvasマネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>Canvasゲームオブジェクト</summary>
    private GameObject canVas;
    /// <summary>アビリティID→文字列変換クラス</summary>
    private AbilityIDtoStringConv convertAbilityIDtoStrings;
    /// <summary>シーンロード時アビリティ名取得クラス</summary>
    private AbilityNameSetForSceneLoading abilityNameSetSceneLoading;

    // 全ユニット数（16個）分のクラス名表示用テキストフィールドリスト
    public List<Text> ClassNameList = new List<Text>();
    // 全ユニット数（16個）分のユニット名表示用テキストフィールドリスト
    public List<Text> UnitNameList = new List<Text>();
    // 全ユニット数（16個）分のアビリティ名表示用テキストフィールドリスト
    public List<Text> AbilityNameList = new List<Text>();

    /// <summary>コンストラクタ</summary>
    private UnitForm() { }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // 全ユニット数分のクラス名表示用テキストコンポを取得し、リストに格納
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName0").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName1").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName2").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName3").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName4").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName5").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName6").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName7").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName8").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName9").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName10").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName11").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName12").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName13").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName14").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName15").GetComponent<Text>());

        // 全ユニット数分のユニット名表示用テキストコンポを取得し、リストに格納
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName0").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName1").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName2").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName3").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName4").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName5").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName6").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName7").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName8").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName9").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName10").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName11").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName12").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName13").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName14").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName15").GetComponent<Text>());

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

        // クラス名表示フィールドを初期化
        foreach (Text field in ClassNameList)
        {
            field.text = "？？？";
        }

        // ユニット名表示フィールドを初期化
        foreach (Text field in UnitNameList)
        {
            field.text = "NameLess";
        }

        // アビリティ表示フィールドを初期化
        foreach (Text field in AbilityNameList)
        {
            field.text = "- - - -";
        }

        // アビリティID→文字列変換クラスを取得
        convertAbilityIDtoStrings = new AbilityIDtoStringConv();

        // シーンロード時アビリティ名取得クラスを取得し、アビリティ表示枠にアビリティ名を表示する
        abilityNameSetSceneLoading = new AbilityNameSetForSceneLoading();
        abilityNameSetSceneLoading.SetMethod();

        // クラス名表示フィールド設定メソッドをコール
        ClassNameSet();

        // クラス名表示フィールド設定メソッドをコール
        UnitNameSet();

        // アビリティ名表示フィールド設定メソッドをコール
        AbilityNameSet();

        // キャラクター画像表示フィールド設定メソッドをコール
        UnitSpriteSet();
    }

    // ------------------------
    // クラス名表示フィールド設定メソッド
    // クラス名を表示する
    // ------------------------
    void ClassNameSet()
    {
        // リストステートリスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "ソルジャー";
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "ウィザード";
                    break;

                // ユニット空きの場合
                default:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "？？？";
                    break;
            }
        }
    }

    // ------------------------
    // ユニット名表示フィールド設定メソッド
    // ユニット名を表示する
    // ------------------------
    void UnitNameSet()
    {
        // ユニットステートリスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // ユニット名が空欄の場合
            if ("名前を入力" == gameManager.unitStateList[i].unitName)
            {
                // とりあえずGustUnitという名前にする
                UnitNameList[i].text = "NameLess";
            }
            // ユニット名が設定済みの場合
            else
            {
                // Textコンポに表示
                UnitNameList[i].text = gameManager.unitStateList[i].unitName;
            }
        }
    }

    // ------------------------
    // アビリティ名表示フィールド設定メソッド
    // アビリティ名を表示する
    // ------------------------
    void AbilityNameSet()
    {
        // リストステートリスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // アビリティIDからアビリティ名(string)を正引き
            string ability = convertAbilityIDtoStrings.Converter(gameManager.unitStateList[i].ability_A);

            // アビリティ名をTextコンポに表示
            AbilityNameList[i].text = ability;
        }
    }

    // ------------------------
    // アビリティ名表示フィールド設定メソッド
    // アビリティ名を表示し、同時にAリストにアビリティIDを設定する
    // アビリティボタンオブジェクトからコールされる
    // ------------------------
    public void AbilityNameSet(int abl_ID)
    {
        // アビリティをセットする対象ユニットがすでに選択済みの場合
        if (Defines.ABL_NON_VALUE != unitSelect)
        {
            // ユニットステートのアビリティIDを設定
            gameManager.unitStateList[unitSelect].ability_A = abl_ID;

            /*          ボツここから-----------------------------------------------------------
                        // AリストにアビリティIDを設定（ユニットID, アビリティID）
                        gameManager.A_List.Insert(unitSelect, abl_ID);
                        // Insertにより一つインデックスが挿入されるのでそれを削除
                        gameManager.A_List.RemoveAt(unitSelect+1);
                        ボツここまで-----------------------------------------------------------
             */
            // アビリティセットするユニットIDを文字列化
            string unitid_STR = unitSelect.ToString();

            // アビリティID→アビリティ文字列正引きメソッドをコール
            string abilityName = convertAbilityIDtoStrings.Converter(abl_ID);

            // 表示するアビリティテキストフィールドを取得
            Text textFieldID = GameObject.FindWithTag("Abl_SetAbilityName" + unitid_STR).GetComponent<Text>();

            // アビリティ名表示フィールドにアビリティ名を設定
            textFieldID.text = abilityName;

            // ユニット選択判定を初期値
            unitSelect = 100;
        }
    }

    // ------------------------
    // キャラクター画像表示フィールド設定メソッド
    // キャラクターの画像を表示する
    // ------------------------
    void UnitSpriteSet()
    {
        GameObject sprite;                              // スプライトprefab用フィールド1
        GameObject prefab;                              // スプライトprefab用フィールド2
        Vector3 vec = new Vector3(-469.0f, 157.0f, 0);  // スプライト表示位置
        float vecCor = 0;                               // スプライト表示位置補正用フィールド

        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // 2段目(9人目以降)の場合
            if (8 == i)
            {
                // Y値の変更およびX値の補正率を初期化
                vec.y = -81.0f;
                vecCor = 0;
            }

            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // ソルジャーのスプライトを設定
                    sprite = Resources.Load("UnitSprite_UnitForm/Char_1") as GameObject;
                    // 位置を設定
                    vec.x = -469.0f + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 126.0f;
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // ウィザードのスプライトを設定
                    sprite = Resources.Load("UnitSprite_UnitForm/Char_2") as GameObject;
                    // 位置を設定
                    vec.x = -368 + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 126.0f;
                    break;

                // ユニット未設定の場合
                default:
                    break;
            }
        }
    }
}
