using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class StreamWriterSingleLine : MonoBehaviour
{
    /// <summary>コンストラクタ</summary>
    public StreamWriterSingleLine() { }

    /// <summary>
    /// ファイル書き出しメソッド
    /// <para>　ファイルに引数で指定された形式および文字列を書き出す。</para>
    /// <param name="filename">書き出すファイルのファイル名</param>
    /// <param name="writingtxt">ファイルに書き込む内容</param>
    /// <returns>書き込み結果（true：正常書き込み　false：書き込み失敗）</returns>
    /// </summary>
    public bool WriteToStream(string filename, string writingtxt)
    {
        // 指定されたファイルのストリームを開く
        // TODO Unity的には簡易パラメータ保存にはPlayerprefsクラスを使うべき。いずれ修正すること。
        StreamWriter sw = File.CreateText(filename);

        // ファイルに改行なしで書き出し
        sw.Write(writingtxt);
        sw.Close();

        // 書き込みに失敗した場合はfalseを返す
        if (null == sw) return false;

        return true;
    }
}