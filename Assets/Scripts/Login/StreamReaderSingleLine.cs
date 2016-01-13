using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

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
        using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
        {
            // 開いたストリームから読み出し
            string gettingTxt = sr.ReadLine();
            return gettingTxt;
        }
    }
}