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
        // 読み込むファイル名とパスを指定
        // TODO Application.datapathが使えない？
        var fi = new FileInfo(filename);

        // 読み出し準備
        var sr = fi.OpenText();

        // ファイルから読み出す
        string gettingTxt = sr.ReadLine();
        sr.Close();

        return gettingTxt;
    }
}