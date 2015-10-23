using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// エレメント画像表示クラス
/// <para>　AbilitySelectシーンでエレメントの画像を生成、表示する。</para>
/// </summary>
public class ElementViewerInAbilityScene : MonoBehaviour
{
    /// <summary>Canvasマネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>エレメントのImageコンポを持つゲームオブジェクト</summary>
    private GameObject[] elementsGO;
    /// <summary>エレメントのImageコンポ配列（2つあるため）</summary>
    private Image elementImage;
    /// <summary>エレメントの画像</summary>
    private Sprite sprite;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private ElementViewerInAbilityScene() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // エレメント画像表示メソッドをコール
        // ※元画像の関係で画像1枚では薄く表示されるため2枚作るので2回コール
        SetElementSprite();
        SetElementSprite();
    }

    /// <summary>
    /// エレメント画像表示メソッド
    /// <para>　エレメントGOの生成、画像設定、ポジション設定を行う。</para>
    /// </summary>
    private void SetElementSprite()
    {
        // Imageを持つゲームオブジェクトを作成
        elementsGO = new GameObject[16];
        for (int i = 0; i < 16; i++)
        {
            elementsGO[i] = new GameObject("Element");
            elementsGO[i].AddComponent<Image>();
        }

        // エレメントの画像を設定
        Vector3 vec = new Vector3(-38.2f, -26.0f, 0);  // スプライト表示位置

        for (int i = 0; i < 16; i++)
        {
            // ユニットのエレメントを判定
            switch (gameManager.unitStateList[i].element)
            {
                case Defines.ELEM_FIRE:
                    sprite = Resources.Load<Sprite>("Elements/Fire");
                    break;
                case Defines.ELEM_WATER:
                    sprite = Resources.Load<Sprite>("Elements/Water");
                    break;
                case Defines.ELEM_EARTH:
                    sprite = Resources.Load<Sprite>("Elements/Earth");
                    break;
                case Defines.ELEM_WIND:
                    sprite = Resources.Load<Sprite>("Elements/Wind");
                    break;
                case Defines.ELEM_DIVINE:
                    sprite = Resources.Load<Sprite>("Elements/Divine");
                    break;
                case Defines.ELEM_DARKNESS:
                    sprite = Resources.Load<Sprite>("Elements/Darkness");
                    break;
                default:
                    // 処理なし
                    break;
            }
            // エレメント用GOのImageコンポにエレメント画像、およびスケールとアス比を設定する
            var elementImage = elementsGO[i].GetComponent<Image>();
            elementImage.sprite = sprite;
            elementImage.preserveAspect = true;
            elementsGO[i].transform.localScale = new Vector3(0.36f, 0.36f, 1.0f);

            // エレメント画像のゲームオブジェクトをElementParentゲームオブジェクトの子に設定する
            GameObject unitGO = GameObject.Find("Unit_" + (i + 1).ToString());
            GameObject elementParentGO = unitGO.transform.FindChild("ElementParent").gameObject;
            elementsGO[i].transform.SetParent(elementParentGO.transform, false);
            // エレメント画像GOの位置を設定する
            elementsGO[i].transform.localPosition = vec;
        }
    }

}
