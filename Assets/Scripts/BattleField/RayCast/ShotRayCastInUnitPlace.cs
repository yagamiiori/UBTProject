using UnityEngine;
using System.Collections;

/// <summary>
/// Ray投射クラス（UnitPlace時専用）
/// <para>　UnitPlace時において、アンダーライン内のユニットアイコン選択後に</para>
/// <para>　チップにRayがヒットした場合、クリック中のユニットIDからユニットGOを作成し、</para>
/// <para>　Rayがヒットしたチップの座標に、作成したユニットGOを配置する。</para>
/// <para>　アタッチGO：Canvas_TimerInUnitPlace
/// </summary>
public class ShotRayCastInUnitPlace : Photon.MonoBehaviour
{
    /// <summary>
    /// ユニットアイコンSubject
    /// </summary>
    private UnitPlaceSubject unitplaceSubject = null;
    /// <summary>
    /// ユニットインスタンス作成クラス
    /// </summary>
    private InstantiateUnitOnTip unitCreate;
    /// <summary>
    /// バトル参加中ユニット管理クラス
    /// </summary>
    private BattleUnitList battleUnitList;
    /// <summary>
    /// サブジェクトコンポ
    /// </summary>
    private UnitPlaceSubject subjectCompo;

    void Start()
    {
        // ユニットアイコンSubjectコンポを取得
        unitplaceSubject = this.gameObject.GetComponent<UnitPlaceSubject>();
        
        // バトル参加中ユニット管理クラスを取得
        battleUnitList = GameObject.Find("Canvas").GetComponent<BattleUnitList>();

        // ユニットインスタンス作成クラスを取得
        unitCreate = this.gameObject.GetComponent<InstantiateUnitOnTip>();

        // サブジェクトコンポを取得し、オブサーバリストに自身を追加
        subjectCompo = GameObject.Find("Canvas_TimerInUnitPlace").GetComponent<UnitPlaceSubject>();
    }

    void FixedUpdate()
    {
        // Rayを作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, (Vector2)ray.direction);
        if (hit.collider != null)
        {
            if ("Tip" == hit.collider.gameObject.tag)
            {
                // チップにRayがヒットしている時にマウスを左クリックした場合
                if (Input.GetButtonDown("Fire1"))
                {
                    // アンダーライン内のユニットアイコンがクリックされている状態か判定
                    if ((int)Enums.ObserverState.OnClick == unitplaceSubject.status)
                    {
                        // クリックされているユニットのIDを取得
                        int unitId = unitplaceSubject.NowClickUnitID;
                        // クリックされたチップの座標を取得
                        Vector3 tipPosition = hit.collider.gameObject.transform.position;

                        // ユニットのインスタンスをチップ上に作成する
                        unitCreate.CreateUnitGO(unitId, tipPosition);

                        // バトル参加中ユニット管理クラスの自軍ユニットリストに配置したユニットのIDを追加
                        battleUnitList.AddMyList(unitId);

                        // ユニットアイコン選択中判定を解除
                        unitplaceSubject.status = (int)Enums.ObserverState.None;
                    }
                }
            }
        }
    }
}
