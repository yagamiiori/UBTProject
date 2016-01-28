using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class AbilitySelect : MonoBehaviour
{
    /// <summary>全ユニット数（16個）分のクラス名表示用テキストフィールドリスト</summary>
    public List<Text> ClassNameList = new List<Text>();
    /// <summary>全ユニット数（16個）分のユニット名表示用テキストフィールドリスト</summary>
    public List<Text> UnitNameList = new List<Text>();
    //// <summary>全ユニット数（16個）分のアビリティ名表示用テキストフィールドリスト</summary>
    public List<Text> AbilityNameList = new List<Text>();
    /// <summary>選択されたユニットのID（初期化値:100）</summary>
    public int selectedUnitID = Defines.ABL_NON_VALUE;
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;
    /// <summary>Canvasのゲームオブジェクト</summary>
    private GameObject canVas;
    /// <summary>ユニットエリア統括ゲームオブジェクト</summary>
    private GameObject unitArea;
    /// <summary>オブザーバーパターンのサブジェクトコンポ</summary>
    private AbilitySubject subjectComp;
    /// <summary>エフェクト表示クラス</summary>
    private PlayEffect playEffect;
    /// <summary>エフェクトスプライト名</summary>
    private string effectSprite;
    /// <summary>アビリティID→文字列変換クラス</summary>
    private AbilityIDtoStringConv convertAbilityIDtoStrings;
    /// <summary>シーンロード時アビリティ名取得クラス</summary>
    private AbilityNameSetForSceneLoading abilityNameSetSceneLoading;

    /// <summary>コンストラクタ</summary>
    private AbilitySelect() { }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // ユニットエリア統括オブジェクト取得
        unitArea = GameObject.FindWithTag("Abl_UnitArea");

        // サブジェクトコンポ
        subjectComp = canVas.GetComponent<AbilitySubject>();

        // エフェクト表示クラス取得後、エフェクトのスプライト名を設定する
        playEffect = new PlayEffect();
        effectSprite = "Effect_2";

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

        // ユニット名表示フィールド設定メソッドをコール
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
        if (Input.GetMouseButtonDown(1) && Defines.ABL_NON_VALUE != selectedUnitID)
        {
            // ユニット選択済みフラグクリア
            selectedUnitID = Defines.ABL_NON_VALUE;

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
                // Textコンポに表示
                UnitNameList[i].text = gameManager.unitStateList[i].unitName;
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
        if (Defines.ABL_NON_VALUE != selectedUnitID)
        {
            // ユニットステートのアビリティIDを設定
            gameManager.unitStateList[selectedUnitID].ability_A = abl_ID;

            // サブジェクトのトリガーをOFFにする
            // これによりオブサーバ（UnitAreaButton）内Notifyメソッドがコールされるので
            // その中で自身の透明化などの処理を行う。
            subjectComp.status = 2;

            // アビリティID→アビリティ文字列正引きメソッドをコール
            string abilityName = convertAbilityIDtoStrings.Converter(abl_ID);

            // アビリティセットするユニットIDを文字列化
            string unitid_STR = selectedUnitID.ToString();
            // アビリティテキストコンポを取得し、表示する
            Text textFieldID = GameObject.FindWithTag("Abl_SetAbilityName" + unitid_STR).GetComponent<Text>();
            textFieldID.text = abilityName;

            // ユニット選択判定をユニット未選択状態に設定
            selectedUnitID = Defines.ABL_NON_VALUE;

            // クリックエフェクト再生メソッドをコール
            playEffect.PlayOnce(effectSprite, GameObject.FindWithTag("Abl_SetAbilityName" + unitid_STR), new Vector3(0, 0, 0f));
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
        Vector3 vec = new Vector3(-447.0f, 205.4f, 0);  // スプライト表示位置
        float vecCor = 0;                                 // スプライト表示位置X軸補正率
        ISpriteViewer spViewer = null;

        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            if (8 == i)
            {
                // 2段目(9人目以降)の場合は、Y値の変更およびX軸補正率の初期化を行う
                vec.y = -56.0f;
                vecCor = 0;
            }

            // 位置を設定
            vec.x = -447.0f + vecCor;
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
            spViewer.SpriteViewer(canVas, vec, i);

            // 補正値を加算
            vecCor += 125.6f;

        }
    }
}
