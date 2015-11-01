using UnityEngine;
using System.Collections;

/// <summary>
/// 初期配置時のユニットアイコン表示クラス
/// <para>　WTパネルGOにアタッチし、初期配置時に画面下のWTパネルにユニット画像を表示する。</para>
/// </summary>
public class UnitViewerOnUnderLine : MonoBehaviour
{
    /// <summary>マネージャコンポ</summary>
    private GameManager gameManager;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitViewerOnUnderLine(){}

	void Start ()
    {
        // マネージャコンポ取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ユニット画像表示メソッドをコール
        UnitSpriteSet();
	}

    /// <summary>
    /// ユニット画像表示メソッド
    /// <para>　ユニット画像をWTパネルの位置に表示する。</para>
    /// </summary>
    private void UnitSpriteSet()
    {
        /// <summary>属するユニット画像のゲームオブジェクトの名前</summary>
        string spriteName = "UnitSprite";
        /// <summary>ユニット画像スプライト（GameObject）</summary>
        GameObject sprite;
        /// <summary>ユニット画像スプライト（Perfab）</summary>
        GameObject prefab;
        /// <summary>ユニット画像スプライトを表示する位置</summary>
        Vector3 setSpriteVec = new Vector3(-59, -3, 0);
        /// <summary>ユニットGOがアタッチしているオブザーバークラス</summary>
        UnitPlaceObserver observerCompo;

        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // ソルジャーのスプライトを設定
                    sprite = Resources.Load("UnitSprite_InUnitPlace/Soldier_M") as GameObject;

                    // ユニットIDをオブザーバークラス内のプロパティに設定する
                    observerCompo = sprite.GetComponent<UnitPlaceObserver>();
                    observerCompo.UnitID = i;

                    // prefabを表示
                    prefab = Instantiate(sprite, setSpriteVec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(this.transform, false);
                    prefab.name = spriteName + i.ToString();             // スプライト表示GOの名前を設定
                    setSpriteVec.x += 8.0f;                              // 次の画像表示のための位置補正
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // ウィザードのスプライトを設定
                    sprite = Resources.Load("UnitSprite_InUnitPlace/Wizard_M") as GameObject;

                    // ユニットIDをオブザーバークラス内のプロパティに設定する
                    observerCompo = sprite.GetComponent<UnitPlaceObserver>();
                    observerCompo.UnitID = i;

                    // prefabを表示
                    prefab = Instantiate(sprite, setSpriteVec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(this.transform, false);
                    prefab.name = spriteName + i.ToString();             // スプライト表示GOの名前を設定
                    setSpriteVec.x += 8.0f;                              // 次の画像表示のための位置補正
                    break;

                // ユニット未設定の場合
                default:
                    // 処理なし
                    break;
            }
        }
    }
}
