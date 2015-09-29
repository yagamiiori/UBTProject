using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// パネル基底クラス
/// <para>　全パネルの基底クラスで、以下の機能を有する。</para>
/// <para>　・マウスカーソルがヒット時に色を変える。</para>
/// </summary>
public class PanelBaseClass : MonoBehaviour
{
    /// <summary>初期化カラー</summary>
    private Color defaultColor;
    /// <summary>Rayヒット時のカラー</summary>
    [SerializeField]
    public Color hittingRayCastColor;
    /// <summary>パネルが持っているマテリアル</summary>
    private Material myMaterial;
    /// <summary>Rayのヒット判定（false:Rayはヒットしていない　true:Rayがヒット中）</summary>
    public bool isHitRayCastBeam = false;

    /// <summary>コンストラクタ</summary>
    private PanelBaseClass() { }

    void Start()
    {
        // 自身が持っているマテリアルを取得
        myMaterial = this.gameObject.GetComponent<Renderer>().material;

        // Rayヒット時と無ヒット時のカラーを保持
        defaultColor = myMaterial.color;
        hittingRayCastColor = Color.magenta;
    }

    void Update()
    {
        // Ray無ヒット時は通常カラーを設定
        myMaterial.color = defaultColor;

        if (isHitRayCastBeam)
        {
            // StageBase側からRayヒット判定をtrueにされたら色を変えた後、Rayヒットフラグをクリア
            myMaterial.color = hittingRayCastColor;
            isHitRayCastBeam = false;
        }
    }
}