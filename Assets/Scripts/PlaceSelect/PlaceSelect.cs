using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class PlaceSelect : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private GameObject canVas;                          // ゲームオブジェクト"Canvas"
    public int unitSelect = 100;                        // ユニット選択判定（初期化値:100）

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // キャラクター画像表示フィールド設定メソッドをコール
        UnitSpriteSet();
	}

    // ----------------------------------------
    // Updateメソッド
    // ----------------------------------------
    void Update()
    {
	
	}

    // ------------------------
    // キャラクター画像表示フィールド設定メソッド
    // キャラクターの画像を表示する
    // また、子オブジェクトのTextフィールドにクラス名を入れて表示する
    // ------------------------
    void UnitSpriteSet()
    {
        GameObject sprite;              // スプライトprefab用フィールド1
        GameObject prefab;              // スプライトprefab用フィールド2
        Vector3 vec = new Vector3(-375, -53f, 0);    // スプライト表示位置
        int vecCor = 0;                 // スプライト表示位置補正用フィールド
        Text child_Text;                // 子オブジェクトのTextコンポ

        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // 2段目(9人目以降)の場合
            if (8 == i)
            {
                // Y値を変更
                vec.y = -153f;
                // X値補正率を初期化
                vecCor = 0;
            }

            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // ソルジャーのスプライトを設定
                    sprite = Resources.Load("UnitSprite_PlaceSelect/Char_1") as GameObject;
                    // 位置を設定
                    vec.x = -375 + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 100;
                    // ユニットスプライト表示後、ユニットIDを設定
                    prefab.GetComponent<PlaceAreaUnitButton>().unitID = i;

                    // 子のTextコンポ取得後、表示する
                    child_Text = this.transform.gameObject.GetComponentInChildren<Text>();
                    child_Text.text = "ソルジャー";
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // ウィザードのスプライトを設定
                    sprite = Resources.Load("UnitSprite_PlaceSelect/Char_2") as GameObject;
                    // 位置を設定
                    vec.x = -375 + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 100;
                    // ユニットスプライト表示後、ユニットIDを設定
                    prefab.GetComponent<PlaceAreaUnitButton>().unitID = i;

                    // 子のTextコンポ取得後、表示する
                    child_Text = this.transform.gameObject.GetComponentInChildren<Text>();
                    child_Text.text = "ウィザード";

                    break;

                // ユニット未設定の場合
                default:
                    break;
            }
        }
    }
}
