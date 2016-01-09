using UnityEngine;
using System.Collections;

/// <summary>
/// Ray投射クラス
/// <para>　Rayを投射し、ヒットしたオブジェクトがRay検出クラスをアタッチしている</para>
/// <para>　オブジェクトの場合は、オブジェクトが持つRay検出メソッドをコールする</para>
/// </summary>
public class ShotRayCast : MonoBehaviour
{
    private UnitPlaceSubject unitplaceSubject = null;
    private GameManager gameManager;

    void Start()
    {
        // ゲームマネージャー取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (null == unitplaceSubject && "BattleStage" == Application.loadedLevelName)
        {
            // バトルフィールドシーン時においてInUnitPlaceのためにSubjectコンポを取得
            unitplaceSubject = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceSubject>();
        }

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

            // InUnitPlace時の処理
            if ("Tip" == hit.collider.gameObject.tag)
            {
                // アンダーライン内のユニットアイコンが既にクリックされているかを判定
                if (1 == unitplaceSubject.status)
                {
                    // ユニットがクリックされている状態でチップにRayがヒットした場合
                    // Subjectのフィールドに格納されている、現在クリックされているユニットIDを読みだして
                    // そのユニットIDのユニットGOを生成し、チップに配置する。
                    int unitId = unitplaceSubject.NowClickUnitID;

                    // クラス種別を読み出し、クラスに対応したGOをインスタンス化する
                    Sprite classSprite = null;
                    GameObject classGO = null;
                    GameObject unitGO = null;
                    Vector3 tipPosition = hit.collider.gameObject.transform.position;
                    switch (gameManager.unitStateList[unitId].classType)
                    {
                        case Defines.SOLDLER: // ソルジャー
                            classGO = Resources.Load<GameObject>("UnitSprite_Battle/SOLDLER");
                            unitGO = Instantiate(classGO, tipPosition, Quaternion.identity) as GameObject;
                            break;
                        case Defines.WIZARD:  // ウィザード
                            classGO = Resources.Load<GameObject>("UnitSprite_Battle/WIZARD");
                            unitGO = Instantiate(classGO, tipPosition, Quaternion.identity) as GameObject;
                            break;
                        default:             // 例外
                            // 処理なし
                            break;
                    }
                }
            }
        }
    }
}
