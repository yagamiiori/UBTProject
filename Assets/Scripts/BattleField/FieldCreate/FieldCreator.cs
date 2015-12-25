using UnityEngine;
using System.Collections;

/// <summary>
/// フィールド自動生成クラス（マップチップ専用）
/// <para>　BattleField開始時においてマップの最小単位であるチップを作成する。</para>
/// <para>　マップの生成はマスタークライアント側のみ行い、他はPhotonViewで同期する。</para>
/// </summary>
public class FieldCreator : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FieldCreator() { }

    void Start()
    {
        // マスタークライアントでなければマップ生成を行わない
//        if (!PhotonNetwork.isMasterClient) return;

        // マップオブジェクト専用FieldCreatorを起動し、マップオブジェクトを先に作成する
        var fieldCreatorObj = this.gameObject.GetComponent<FieldCreatorObjects>();
        fieldCreatorObj.StartCreate();

        // 配置する起点となるゲームオブジェクト
        GameObject startingPointGO = GameObject.Find("Root_FieldObjects");
        // ループ毎に加算する位置補正値
        // チップのPixel Per Unitが20の場合：0.8f / 0.4f
        float addPotisionX = 0.8f;
        float addPotisionY = 0.4f;

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
                string tipImage = "Tips_1";
                string tipSprite = "Tips_1_";
                Tip.Add(tipType, x, y, i, j, tipImage, tipSprite);

                addPotisionX += 0.8f;
                addPotisionY += 0.4f;
            }
            addPotisionX = 0.8f - (0.74f * (i+1));
            addPotisionY = 0.4f + (0.40f * (i+1));
        }
        // 全ての処理が終わったらスクリプトを停止する
        this.enabled = false;
    }
}
