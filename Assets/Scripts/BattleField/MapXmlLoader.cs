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
    /// コンストラクタ
    /// </summary>
    public MapXmlLoader() { }

    /// <summary>
    /// チップデータ取得メソッド
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

                // xmlファイルよりマップ構成マトリクスの縦と横の数を取得する（縦*横=マップチップの総数）
                XmlAttributeCollection attrs = child.Attributes;
                int w = int.Parse(attrs.GetNamedItem("width").Value);
                int h = int.Parse(attrs.GetNamedItem("height").Value);

                // チップ管理リストに全チップ数分の領域を生成する。縦*横が10*10なら100個分の領域をList<>に確保
                tipData.CreateTipListIndex(w, h);

                // 子ノードを取得（子ノードは<data>属性のみ）
                XmlNode node = child.FirstChild;
                // 取得した子ノードの子ノード（テキストノード）を取得
                XmlNode n = node.FirstChild;
                // マップ構成データを取得
                string val = n.Value;

                // XMLマップファイル内にあるCSV形式のマップ構成データを解析
                // 改行まで（一行分）をループする
                int y = 0;
                foreach (string line in val.Split('\n'))
                {
                    // 空文字とカンマを除外
                    if (line == "" || line == "\r") { continue; }

                    // 取得した一行の中からカンマまでを読み込む
                    int x = 0;
                    foreach (string s in line.Split(','))
                    {
                        // チップ種別を初期化
                        int v = 0;

                        // 取得した文字が","の場合はループを抜ける
                        if (int.TryParse(s, out v) == false) { continue; }

                        // チップのXY座標およびチップ種別をチップ配列に設定
                        tipData.Set(x, y, v);
                        x++; // チップ構成データのマトリクスX軸をインクリメント
                    }
                    y++; // チップ構成データのマトリクスY軸をインクリメント
                }
            }
        }
    }
}
