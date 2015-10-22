using UnityEngine;
using System.Collections;

/// <summary>
/// フィールド自動生成クラス
/// <para>　BattleField開始時においてフィールドマップのパネルを自動生成する。</para>
/// </summary>
public class FieldCreator : MonoBehaviour
{
    /// <summary>配置するパネルの個数（横）※インスペクタからのみ設定する</summary>
    public int panelNumWidth;
    /// <summary>配置するパネルの個数（縦）※インスペクタからのみ設定する</summary>
    public int panelNumHight;
    /// <summary>最初に配置するパネルを置くX座標　※インスペクタからのみ設定する</summary>
    public float firstSetPanelPositionX;
    /// <summary>最初に配置するパネルを置くY座標　※インスペクタからのみ設定する</summary>
    public float firstSetPanelPositionY;

    void Start()
    {
        // インスペクタから設定すべき配置パネル数が設定されていない場合、ログをダンプする
        if (0 == panelNumHight || 0 == panelNumWidth) Debug.Log("パネル配置数が未設定。配置パネルの数をインスペクタから設定して下さい。");

        // 配置するパネルのゲームオブジェクト（プレハブ）
        GameObject panelGO = (GameObject)Resources.Load("Panel");
        // 配置する起点となるゲームオブジェクト（グラウンド）
        GameObject panelParent = GameObject.Find("PanelParent");

        // 縦にパネルを配置
        // ※地面オブジェクトのscaleが1,1,1ならscale=0.1,0.1の正方形パネルは10個置ける（0.1*10=1.0）
        for (int i = 0; i < panelNumHight; i++)
        {
            // 横にパネルを配置
            for (int j = 0; j < panelNumWidth; j++)
            {
                // 配置するパネルの位置を決定
                Vector3 panelPos = new Vector3
                    (
                       firstSetPanelPositionX + panelGO.transform.localScale.x * j,  // 横
                       firstSetPanelPositionY + panelGO.transform.localScale.y * -i, // 縦
                        0
                    );

                // パネルGOを複製し、親オブジェクト、複製したオブジェクトのタグ名、アドコンを設定する
                GameObject copiedPanelGO = Instantiate(panelGO, panelPos, Quaternion.identity) as GameObject;
                copiedPanelGO.transform.SetParent(panelParent.transform, false);
                copiedPanelGO.tag = "Panels";
                copiedPanelGO.AddComponent<GetPanelCoordinate>();
                var panelCoordinate = copiedPanelGO.GetComponent<GetPanelCoordinate>();
                panelCoordinate.posX = copiedPanelGO.transform.position.x; // パネルの座標Xを渡す
                panelCoordinate.posY = copiedPanelGO.transform.position.y; // パネルの座標Yを渡す
                panelCoordinate.posZ = copiedPanelGO.transform.position.z; // パネルの座標Zを渡す
                panelCoordinate.gridX = j; // パネルのグリッド値Xをパネルにアタッチしたクラスフィールドに渡す
                panelCoordinate.gridY = i; // パネルのグリッド値Yをパネルにアタッチしたクラスフィールドに渡す
            }
        }
        // 仕事が終わったらスクリプトを停止する
        this.enabled = false;
    }
}
