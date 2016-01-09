using UnityEngine;
using System.Collections;

/// <summary>
/// Ray投射クラス（UnitPlace時専用）
/// <para>　UnitPlace時において、アンダーライン内のユニットアイコン選択後に</para>
/// <para>　チップにRayがヒットした場合、クリック中のユニットIDからユニットGOを作成し、</para>
/// <para>　Rayがヒットしたチップの座標に、作成したユニットGOを配置する。</para>
/// <para>　アタッチGO：Canvas_TimerInUnitPlace
/// </summary>
public class ShotRayCastInUnitPlace : MonoBehaviour
{
    /// <summary>
    /// ユニットアイコンSubject
    /// </summary>
    private UnitPlaceSubject unitplaceSubject = null;
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// ユニットパラメータ設定クラス
    /// </summary>
    private SettingsUnitParam settingUnitParam;

    void Start()
    {
        // ゲームマネージャー取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ユニットパラメータ設定クラス取得
        settingUnitParam = this.gameObject.GetComponent<SettingsUnitParam>();

        // ユニットアイコンSubjectコンポを取得
        unitplaceSubject = this.gameObject.GetComponent<UnitPlaceSubject>();
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
                        // ユニットがクリックされている場合、Subjectのフィールドに格納されている
                        // 現在クリックされているユニットIDを読み出し、そのユニットIDの
                        // ユニットGOを生成し、チップに配置する。
                        int unitId = unitplaceSubject.NowClickUnitID;
                        GameObject classGO = null;
                        Vector3 tipPosition = hit.collider.gameObject.transform.position;
                        tipPosition.y += 0.5f; // Y軸をちょっと補正
                        switch (gameManager.unitStateList[unitId].classType)
                        {
                            case Defines.SOLDLER: // ソルジャー
                                classGO = Resources.Load<GameObject>("UnitSprite_BattleStage/SOLDLER");
                                break;
                            case Defines.WIZARD:  // ウィザード
                                classGO = Resources.Load<GameObject>("UnitSprite_BattleStage/WIZARD");
                                break;
                            default:              // 例外
                                // 処理なし
                                break;
                        }
                        // ユニットGOをインスタンス化し、パラメータを設定する
                        var unit = Instantiate(classGO, tipPosition, Quaternion.identity);
                        settingUnitParam.SettingUnitParams(unitId, unit as GameObject);

                        // ユニットアイコン選択中判定を解除
                        unitplaceSubject.status = (int)Enums.ObserverState.None;
                    }
                }
            }
        }
    }
}
