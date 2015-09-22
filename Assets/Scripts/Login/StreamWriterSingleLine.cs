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
        // 書き出すファイル名とパスを指定
        // TODO 普通に開いて書いて閉じたいだけだがよく分からんので一度諦める。要修正。
        var fi = new FileInfo(filename);

        // ファイルが既に存在していたら一度削除する
        if (fi.Exists) fi.Delete();

        // 書き出し準備（これだと末尾に追記するメソッドなのでおかしい要修正）
        var sw = fi.AppendText();

        // ファイルに改行なしで書き出し
        sw.Write(writingtxt);
        sw.Close();

        // 書き込み失敗した場合はfalseを返す
        if (null == sw) return false;

        return true;
    }
}