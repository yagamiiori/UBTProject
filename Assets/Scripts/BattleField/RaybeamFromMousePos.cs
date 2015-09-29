using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// マウスRay発射クラス
/// <para>　マウス座標からRayCastによりRayを飛ばし、パネルにヒットしたら</para>
/// <para>　パネルの基底クラスを取得し、基底クラス内にあるパネルの色を変える</para>
/// <para>　処理を動かす。</para>
/// </summary>
public class RaybeamFromMousePos : MonoBehaviour
{
    /// <summary>Rayにヒットしたオブジェクト</summary>
    private RaycastHit hit;
    /// <summary>光線</summary>
    private Ray ray;

    /// <summary>コンストラクタ</summary>
    private RaybeamFromMousePos() { }

    void Update()
    {
        // スクリーン座標に対してマウスの位置の光線を取得する
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Rayがオブジェクトにヒットしたら、ヒットしたオブジェクトからパネルの基底クラスを取得する
            PanelBaseClass panelBaseClass = hit.collider.GetComponent<PanelBaseClass>();
            panelBaseClass.isHitRayCastBeam = true;
        }
    }
}