using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class AbilitySelect : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private GameObject canVas;                          // ゲームオブジェクト"Canvas"
    private GameObject abilityArea;                     // アビリティエリア統括オブジェクト
    private GameObject unitArea;                        // ユニットエリア統括オブジェクト
    private AbilitySubject subjectComp;                 // サブジェクトコンポ
    public int unitSelect = Defines.ABL_NON_VALUE;      // ユニットID（選択したユニットの判定）（初期化値:100）
    private PlayEffect playEffect;                      // エフェクト表示クラス
    private string effectSprite = "Effect_2";           // エフェクトスプライト名
    float timer;
    float waitingTime = 3.0f;

    // 全ユニット数（16個）分のクラス名表示用テキストフィールドリスト
    public List<Text> ClassNameList = new List<Text>();
    // 全ユニット数（16個）分のユニット名表示用テキストフィールドリスト
    public List<Text> UnitNameList = new List<Text>();
    // 全ユニット数（16個）分のアビリティ名表示用テキストフィールドリスト
    public List<Text> AbilityNameList = new List<Text>();

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // アビリティエリア統括オブジェクト取得
        abilityArea = GameObject.FindWithTag("Abl_AbilityArea");

        // ユニットエリア統括オブジェクト取得
        unitArea = GameObject.FindWithTag("Abl_UnitArea");

        // サブジェクトコンポ
        subjectComp = canVas.GetComponent<AbilitySubject>();

        // エフェクト表示クラス取得
        playEffect = new PlayEffect();

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

        // クラス名表示フィールド設定メソッドをコール
        ClassNameSet();

        // クラス名表示フィールド設定メソッドをコール
        UnitNameSet();

        // キャラクター画像表示フィールド設定メソッドをコール
        UnitSpriteSet();
	}

    // ------------------------
    // Updateメソッド
    // ------------------------
    void Update()
    {
        // マウス右クリックされ、かつユニット選択済みの場合
        if (Input.GetMouseButtonDown(1) && Defines.ABL_NON_VALUE != unitSelect)
        {
            // ユニット選択済みフラグクリア
            unitSelect = Defines.ABL_NON_VALUE;

            // サブジェクトのトリガーをOFFにする
            subjectComp.status = 3;
        }
    }

    // ------------------------
    // クラス名表示フィールド設定メソッド
    // アビリティセレクトシーンにおいてクラス名を表示する
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
    // アビリティセレクトシーンにおいてユニット名を表示する
    // ------------------------
    void UnitNameSet()
    {
        // ユニットステートリスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // ユニット名が空欄の場合
            if ("名前を入力" == gameManager.unitStateList[i].unitName)
            {
                // とりあえずNo＋固有番号を振る
                UnitNameList[i].text = "Unit No." + (i+1).ToString();
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
    // アビリティセレクトシーンにおいてアビリティ名を表示し、
    // 同時にユニットリストにアビリティIDを設定する
    // アビリティボタンオブジェクトからコールされる
    // ------------------------
    public void AbilityNameSet(int abl_ID)
    {
        // アビリティをセットする対象ユニットがすでに選択済みの場合
        if (Defines.ABL_NON_VALUE != unitSelect)
        {
            // ユニットステートのアビリティIDを設定
            gameManager.unitStateList[unitSelect].ability_A = abl_ID;

            // サブジェクトのトリガーをOFFにする
            // これによりオブサーバ（UnitAreaButton）内Notifyメソッドがコールされるので
            // その中で自身の透明化などの処理を行う。
            subjectComp.status = 2;

            // アビリティID→アビリティ文字列正引きメソッドをコール
            string abilityName = AbilityIDtoStringConv(abl_ID);

            // アビリティセットするユニットIDを文字列化
            string unitid_STR = unitSelect.ToString();
            // アビリティテキストコンポを取得し、表示する
            Text textFieldID = GameObject.FindWithTag("Abl_SetAbilityName" + unitid_STR).GetComponent<Text>();
            textFieldID.text = abilityName;

            // ユニット選択判定をユニット未選択状態に設定
            unitSelect = 100;

            // クリックエフェクト表示メソッドをコール
            playEffect.PlayOnce(effectSprite, GameObject.FindWithTag("Abl_SetAbilityName" + unitid_STR), new Vector3(0, 0, 0f));
        }
    }

    // -------------------------------------------
    // アビリティID→アビリティ文字列正引きメソッド
    // アビリティID（int）を元に対応するアビリティ名（string）を返す
    // -------------------------------------------
    string AbilityIDtoStringConv(int abl_ID)
    {
        string abilityName = "";    // アビリティ名

        // アビリティIDで分岐
        switch(abl_ID)
        {
            // アビリティ - 攻撃力Up
            case Defines.ABL_POWERUP:
                abilityName = "攻撃力Up";
                break;

            // アビリティ - 防御力Up
            case Defines.ABL_DIFFENCEUP:
                abilityName = "防御力Up";
                break;

            // アビリティ - ムーブプラス
            case Defines.ABL_MOVEPLUS:
                abilityName = "ムーブプラス";
                break;

            // アビリティ - 見切り青眼
            case Defines.ABL_HCOUNTER:
                abilityName = "見切り青眼";
                break;

            // アビリティ - ダテレポ
            case Defines.ABL_TEREPORT:
                abilityName = "ダテレポ";
                break;

            // フェールセーフ
            default:
                break;
        }
        return abilityName;
    }

    // ------------------------
    // キャラクター画像表示フィールド設定メソッド
    // キャラクターの画像を表示する
    // ------------------------
    void UnitSpriteSet()
    {
        GameObject sprite;                              // スプライトprefab用フィールド1
        GameObject prefab;                              // スプライトprefab用フィールド2
        Vector3 vec = new Vector3(-368f, 183f, 0);      // スプライト表示位置
        int vecCor = 0;                                 // スプライト表示位置補正用フィールド
        ISpriteViewer spViewer = null;

        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // 2段目(9人目以降)の場合
            if (8 == i)
            {
                // Y値の変更およびX値補正率を初期化
                vec.y = -20.14f;
                vecCor = 0;
            }

            // 位置を設定
            vec.x = -368 + vecCor;
            vec.z = 0;

            // クラスIDを読み出し（Strategyパターン）
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    spViewer = new SpriteViewer_Sol();
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    spViewer = new SpriteViewer_Wiz();
                    break;

                // ユニット未設定の場合
                default:
                    break;
            }

            // Strategyパターン - スプライト表示メソッドをコール
            spViewer.SpriteViewer(canVas, vec, vecCor, i);

            // 補正値を加算
            vecCor += 100;

        }
    }
}
