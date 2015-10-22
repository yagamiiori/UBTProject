using UnityEngine;
using System.Collections;

// =====================================
// ユニットセレクトインターフェイス
// 機能：ユニットセレクト画面で使用。
// 　　　マウスクリックを検知し、ユニット数の増減を行う。
//
// =====================================
interface IUnitSelect
{
    // -----------------------------
    // ユニット数増減メソッド
    // -----------------------------
    // 機能：マウスオーバーしている事が前提
    // 　　　そのためOnPointerEnterメソッドからコールされ
    // 　　　マウスオーバー状態でマウスの右クリック / 左クリックを検知し
    // 　　　ユニット数の増減処理を行う。
    IEnumerator MouseClickHandler();
}

// =====================================
// ユニットコモンインターフェイス
// 機能：バトルフィールドで使用するHPや能力など基本的なIF
//
// =====================================
interface IBattleField
{
     // -----------------------------
     // ダメージメソッド
     // 機能：攻撃された場合、相手から呼び出される
     // 　　　ダメージを受け、食らいアニメを表示する
     // -----------------------------
    void ApplyDamage();

     // -----------------------------
     // 通常攻撃メソッド
     // 機能：たたかうコマンドによる通常攻撃を行う
     // 　　　与えるダメージを算出した後、相手ユニットの
     // 　　　ApplyDamageメソッドをコールする
     // -----------------------------
     void NormalAttack();

     // -----------------------------
     // ユニットパラメータ設定メソッド
     // 機能：ユニットのパラメータを設定する
     // -----------------------------
     void SettingParams();

}

/// <summary>
/// サブジェクトIF　【◆Observerパターン用IF】
/// <para>　以下の機能を有するIF。</para>
/// <para>　・Observer の登録。</para>
/// <para>　・削除、状態変化の通知の機能を定義する。</para>
/// </summary>
public interface ISubject
{
    /// <summary>
    /// オブザーバ登録メソッド
    /// </summary>
    /// <param name="observer"></param>
    void Attach(IObserver observer);
    
    /// <summary>
    /// オブザーバ削除メソッド
    /// </summary>
    /// <param name="observer"></param>
    void Detach(IObserver observer);

    /// <summary>
    /// オブザーバからの通知受信メソッド
    /// </summary>
    /// <param name="jud"></param>
    void Notify(int jud);
}

/// <summary>
/// オブサーバIF　【◆Observerパターン用IF】
/// <para>　以下の機能を有するIF。</para>
/// <para>　・Subject から通知を受け取る機能を定義する。</para>
/// <para>　・ConcreteSubject‐ConcreteObserver 間の結合を抽象的に</para>
/// <para>　　（直接的な依存関係を排除）するためのインターフェース。</para>
/// </summary>
public interface IObserver
{
    /// <summary>
    /// サブジェクトへの通知メソッド
    /// </summary>
    /// <param name="jud"></param>
    void Notify(int jud);
}


// =====================================
// OKボタンクリックIF（メッセージウィンドウ専用）
// メッセージウィンドウのOKボタンのコールバックOnClick()から
// コールされる。
// 実行処理：
//     　　  ・メッセージウィンドウを非アクティブ化
//      　　 ・メッセージウィンドウ表示有無判定フラグをfalse
// =====================================
public interface IOnMessageWindowOK
{
    void OnMessageWindowOK();
}

// =====================================
// メッセージウィンドウ書き込みIF
// メッセージウィンドウのTextコンポに文字を書き込む
// 実行処理：
//     　　  ・メッセージウィンドウをアクティブ化
//      　　 ・メッセージウィンドウ表示有無判定フラグをtrue
//       　　・メッセージ表示
// =====================================
public interface IMessageWriteToMW
{
    void MessageWriteToWindow(string a);
}


// =====================================
// スプライト表示IF　【◆Strategyパターン用IF】
// アビリティセレクトシーンでユニット画像を表示する
// =====================================
public interface ISpriteViewer
{
    void SpriteViewer(GameObject a, Vector3 b, int c);
}






public class Interfaces : MonoBehaviour { }
