using UnityEngine;
using System.Collections;

public class SpriteViewer_Sol :
    MonoBehaviour,
    ISpriteViewer                                       // ユニットスプライト表示IF
{
    private GameManager gameManager;                    // マネージャコンポ
    private GameObject canVas;                          // ゲームオブジェクト"Canvas"
    private GameObject abilityArea;                     // アビリティエリア統括オブジェクト

    // ----------------------------------------
    // ユニット画像表示メソッド
    // アビリティセレクトシーンでユニットの画像を表示する
    // ----------------------------------------
    public void SpriteViewer(GameObject canVas, Vector3 vec, int vecCor, int roopCount)
    {
        GameObject sprite;                              // スプライトprefab用フィールド1
        GameObject prefab;                              // スプライトprefab用フィールド2

        // ソルジャーのスプライトを設定
        sprite = Resources.Load("UnitSprite_AbilitySelect/Char_1") as GameObject;

        // prefabを表示
        prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
        prefab.transform.SetParent(canVas.transform, false);

        // ユニットスプライト表示後、ユニットIDを設定
        prefab.GetComponent<AbilityObserver>().unitID = roopCount;
    }
}
