using UnityEngine;
using System.Collections;

// ==============================================================================
// パネルCommonクラス（草・雑草）
// 
// 概要：パネルの基本情報を設定する。
// また、ハイト情報をインスペクタから設定するため、インスペクタから値を変更
// されると不具合の出る懸念のあるフィールドは[HideInInspector]属性を使用し
// インスペクタから隠蔽、保護する。
// 
// 攻撃補正（自分がこのパネルに立って攻撃する場合）
// 　　　火 - 1.15
// 　　　土 - 0.90
// 　　　水 - なし
// 　　　風 - なし
// 　　　神聖 - なし
// 　　　暗黒 - なし
// 　　　物理 - 1.10
// 
// 防御補正（相手がこのパネルに立って攻撃を食らう場合）
// 　　　火 - 1.15
// 　　　土 - 0.90
// 　　　水 - なし
// 　　　風 - なし
// 　　　神聖 - なし
// 　　　暗黒 - なし
// 　　　物理 - 1.10
// 
// ==============================================================================
public class PanelKusa : Photon.MonoBehaviour
{
    [HideInInspector]
    public int type = Defines.BTL_PANEL_KUSA;       // パネル種別
    public int hyte = 0;                            // ハイト情報（基本的にインスペクタからアタッチする）
    [HideInInspector]
    public int effect = 0;                          // パネル効果？（未定）
    [HideInInspector]
    public float fireCor = 1.15f;                   // 属性補正 - 火
    [HideInInspector]
    public float earthCor = 0.90f;                  // 属性補正 - 土
    [HideInInspector]
    public float waterCor = 0f;                     // 属性補正 - 水
    [HideInInspector]
    public float windCor = 0f;                      // 属性補正 - 風
    [HideInInspector]
    public float divineCor = 0f;                    // 属性補正 - 神聖
    [HideInInspector]
    public float darkCor = 0f;                      // 属性補正 - 暗黒
    [HideInInspector]
    public float weaponCor = 1.10f;                 // 物理攻撃補正
    [HideInInspector]
    public bool selectJud = false;                  // パネル選択判定フラグ
    [HideInInspector]
    public bool betweenJud = false;                 // 選択パネル-ユニット間フラグ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
	
	}

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Update()
    {
	
	}
}
