using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class StreamReaderSingleLine : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    public StreamReaderSingleLine() { }

    /// <summary>
    /// ファイル書き出しメソッド
    /// <para>　ファイルに引数で指定された形式および文字列を書き出す。</para>
    /// <param name="filename">読み込むファイルのファイル名</param>
    /// <returns>ファイルから読み出した文字列</returns>
    /// </summary>
    public string ReadFromStream(string filename)
    {
        // 指定されたファイルのストリームを開く
        // TODO Unity的には簡易パラメータ保存にはPlayerprefsクラスを使うべき。いずれ修正すること。
        StreamReader sr = new StreamReader(filename);

        // 開いたストリームから読み出し、完了後クローズする
        string gettingTxt = sr.ReadLine();
        sr.Close();

        return gettingTxt;
    }
}