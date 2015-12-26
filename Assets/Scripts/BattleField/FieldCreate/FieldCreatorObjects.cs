using UnityEngine;
using System.Collections;

/// <summary>
/// フィールド自動生成クラス（オブジェクト専用）
/// <para>　マップチップの上に配置する木や彫刻などのマップオブジェクトを配置する。</para>
/// </summary>
public class FieldCreatorObjects : MonoBehaviour
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FieldCreatorObjects() { }

    public void StartCreate()
    {
        // ループ毎に加算する位置補正値
        // チップのPixel Per Unitが20の場合：0.8f / 0.4f
        float addPotisionX = 0.8f;
        float addPotisionY = 1.1f;

        // ★
        // マップデータ（XMLファイル）のロード
        // XMLマップファイルを読み込み、XMLに記載されている縦と横のチップ数、座標(0,1、2,4みたいな)
        // チップ種別（芝生か石畳かなど）をMapLayer2D.csのtipImage[]配列に格納する
        var mapXmlLoader = new MapXmlLoader();
        mapXmlLoader.XmlLoad("MapXmls/LouzacPlain_Obj");
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

                // スプライトを設定し、チップGOを作成する
                string tipImage = "Tips_1";
                string tipSprite = "Tips_1_";
                TipObject.Add(tipType, x, y, i, j, tipImage, tipSprite);

                addPotisionX += 0.8f;
                addPotisionY += 0.4f;
            }
            addPotisionX = 0.8f - (0.74f * (i + 1));
            addPotisionY = 1.1f + (0.40f * (i + 1));
        }
        // 全てのマップオブジェクトを並び終えたらスクリプトを停止する
        this.enabled = false;
    }
}
