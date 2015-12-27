using UnityEngine;
using System.Collections;

/// <summary>
/// Ray投射クラス
/// <para>　Rayを投射し、ヒットしたオブジェクトがRay検出クラスをアタッチしている</para>
/// <para>　オブジェクトの場合は、オブジェクトが持つRay検出メソッドをコールする</para>
/// </summary>
public class ShotRayCast : MonoBehaviour
{
    void FixedUpdate()
    {
        // Rayを作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, (Vector2)ray.direction);
        if (hit.collider != null)
        {
            // Rayがヒットしたオブジェクトがチップ / ユニット / ステータスウィンドウの場合
            if (("Tip" == hit.collider.gameObject.tag) ||
                ("UnitGO" == hit.collider.gameObject.tag) ||
                ("StatusWindow" == hit.collider.gameObject.tag))
            {
                // ヒットしたオブジェクトが持つRay検出クラスの基底クラス側メソッドをコール
                var dRayCast = hit.collider.GetComponent<DetectRayBase>();
                dRayCast.DetectRayHit();
            }
        }
    }
}
