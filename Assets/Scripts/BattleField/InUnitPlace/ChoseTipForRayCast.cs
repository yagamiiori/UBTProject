using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// ユニット配置チップ選択クラス
/// <para>　初期配置時においてRayCastによりユニットを配置するチップを選択する。</para>
/// </summary>
public class ChoseTipForRayCast : MonoBehaviour
{
    /// <summary>
    /// チップ座標管理クラス
    /// </summary>
    private GetTipCoordinate tipCoord;

    void Start()
    {
        // チップ座標管理クラスを取得
        tipCoord = this.gameObject.GetComponent<GetTipCoordinate>();
    }

    void FixedUpdate()
    {
        // Rayを投げる
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, (Vector2)ray.direction);
        if (hit.collider != null)
        {
            // Rayがヒットしたオブジェクトがチップの場合
            if ("Tip" == hit.collider.gameObject.name)
            {
                // Tipクラスのマップ構成マトリクスXY値を取得
                var t = hit.collider.GetComponent<Tip>();
                int matrixX = t.matrixX;
                int matrixY = t.matrixY;
                // 取得したマップ構成マトリクスから割り出したチップのXY座標
                float tipPosX = tipCoord.GetTipPosX(matrixX);
                float tipPosY = tipCoord.GetTipPosX(matrixY);
                Debug.Log("RayHit TipMatrix(X,Y)=(" + matrixX + "," + matrixY + ")");
                Debug.Log("RayHit TipPos(X,Y)=(" + tipPosX + "," + tipPosY + ")");
            }
        }
    }
}
