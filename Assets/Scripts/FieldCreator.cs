using UnityEngine;
using System.Collections;

// ================================================
// フィールドクリエイタークラス
//
// 機能：フィールドマップをプロシージャルに生成する
//
// ================================================
public class FieldCreator : MonoBehaviour
{
    private GameManager gameManager;                // マネージャコンポ
    protected int _sceneTask;

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        GameObject prefab = (GameObject)Resources.Load("Panels/1");     // 配置するチップ（プレハブ）
        GameObject stageObject = GameObject.FindWithTag("Stage");       // 配置元のオブジェクト

        // X軸とZ軸にチップを配置
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // 配置するチップの位置を決定
                Vector3 tip_pos = new Vector3
                    (
                        0 + prefab.transform.localScale.x * i,
                        0,
                        0 + prefab.transform.localScale.z * j
                    );

                // プレハブの複製 
                GameObject instant_object = Instantiate(prefab, tip_pos, Quaternion.identity) as GameObject;
                // (GameObject)GameObject.Instantiate(prefab, tile_pos, Quaternion.identity);

                // 複製したチップを生成元チップの子に設定 
                instant_object.transform.parent = stageObject.transform;
            }
        }
    }
  	
}
