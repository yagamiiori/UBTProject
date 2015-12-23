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
        GameObject panelGO = (GameObject)Resources.Load("Tip");
        // 配置する起点となるゲームオブジェクト
        GameObject startingPointGO = GameObject.Find("Root_FieldObjects");
        // パネル一つ一つが持つユニークID
        int panelId = 0;
        // ループ毎に加算する位置補正値
        // チップのPixel Per Unitが20の場合：0.8f / 0.4f
        float addPotisionX = 0.8f;
        float addPotisionY = 0.4f;
        // ソーティングレイヤー名
        string sortingLayerName = "Tips";
        // ソーティングオーダー番号
        int sortingLayerVal = 1;
        // チップ位置情報クラスを取得
        GetTipCoordinate tipCoordinate = this.gameObject.GetComponent<GetTipCoordinate>();

        // ★
        // マップデータ（XMLファイル）のロード
        // XMLマップファイルを読み込み、XMLに記載されている縦と横のチップ数、座標(0,1、2,4みたいな)
        // チップ種別（芝生か石畳かなど）をMapLayer2D.csのtipImage[]配列に格納する
        var mapXmlLoader = new MapXmlLoader();
        mapXmlLoader.XmlLoad("MapXmls/LouzacPlain");
        var tipDataArray = mapXmlLoader.GetTipData();

        // 縦にパネルを配置
        for (int i = 0; i < tipDataArray.Height; i++)
        {
            // 横にパネルを配置
            for (int j = 0; j < tipDataArray.Width; j++)
            {
                // ★
                // チップ種別およびチップを配置するワールド座標XYを取得し、設定する
                var tipType = tipDataArray.Get(j, i);
                var x = addPotisionX;
                var y = addPotisionY;
//                var x = tipCoordinate.GetTipX(i);
//                var y = tipCoordinate.GetTipY(j);
                // スプライトを設定し、チップGOを作成する
                Tip.Add(tipType, x, y);

                addPotisionX += 0.8f;
                addPotisionY += 0.4f;
            }
            addPotisionX = 0.8f - (0.74f * (i+1));
            addPotisionY = 0.4f + (0.40f * (i+1));      // 0.80f;
        }
        // 全てのパネルを並び終えたらスクリプトを停止する
        this.enabled = false;
    }
}
