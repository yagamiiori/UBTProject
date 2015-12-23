using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

/// <summary>
/// XMLマップデータ読み込みクラス
/// </summary>
public class MapXmlLoader
{
    /// <summary>
    /// チップデータ生成クラス
    /// </summary>
    MapLayer2D tipData = null;

    /// <summary>
    /// チップレイヤー取得メソッド
    /// </summary>
    /// <returns></returns>
    public MapLayer2D GetTipData()
    {
        return tipData;
    }
    
    /// <summary>
    /// XMLマップデータ読み込みメソッド
    /// <para>　マップデータであるXMLファイルを読み込み、解析する。</para>
    /// </summary>
    /// <param name="mapFileName"></param>
    public void XmlLoad(string mapFileName)
    {
        // チップデータ生成クラスをインスタンス化
        tipData = new MapLayer2D();
        // マップファイル（XML）を取得
        TextAsset tmx = Resources.Load(mapFileName) as TextAsset;

        // 取得したXMLマップファイルを解析
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(tmx.text);
        XmlNodeList mapElements = xmlDoc.GetElementsByTagName("map");

        // XMLマップファイル内にある"map"属性を取得
        foreach (XmlNode choseMapElement in mapElements)
        {
            // map属性配下の子ノードを取得
            XmlNodeList childList = choseMapElement.ChildNodes;
            foreach (XmlNode child in childList)
            {
                // layerノードのみを見るため、layerノード以外を除外する
                if (child.Name != "layer") { continue; }

                // xmlファイルよりマップ属性を取得し、属性からチップの縦および横のPixelを取得する
                XmlAttributeCollection attrs = child.Attributes;
                int w = int.Parse(attrs.GetNamedItem("width").Value);
                int h = int.Parse(attrs.GetNamedItem("height").Value);
                // レイヤー生成
                tipData.Create(w, h);
                XmlNode node = child.FirstChild; // 子ノードは<data>属性のみ
                XmlNode n = node.FirstChild; // テキストノードを取得
                string val = n.Value; // テキストを取得

                // XMLマップファイル内にあるCSV形式のマップデータ（<data>属性）を解析
                // 一行分をループする
                int y = 0;
                foreach (string line in val.Split('\n'))
                {
                    // 空文字を除外
                    if (line == "") { continue; }

                    // 一行の中から1つずつチップ種別を読み込む
                    int x = 0;
                    foreach (string s in line.Split(','))
                    {
                        // ","で終わるのでチェックが必要
                        int v = 0;
                        if (int.TryParse(s, out v) == false) { continue; }
                        // チップのXY座標およびチップ種別をチップ配列に設定
                        tipData.Set(x, y, v);
                        x++; // チップ座標Xをインクリメント
                    }
                    y++; // チップ座標Yをインクリメント
                }
            }
        }
    }
}
