using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class PlaceAreaUnitButton :
    MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    private GameManager gameManager;             // マネージャコンポ
    private PlaceSelect abilityCommon;         // アビリティシーンコントローラ
    public int unitID = 0;                       // ユニットID（InstantiateするAbilitySelectクラスから設定される）
    public int mouseOverJug = 0;                 // マウスオーバー判定フラグ
    public AudioSource audioCompo;               // オーディオコンポ
    public AudioClip clickSE;                    // クリックSE
    private SpriteRenderer spRenderer;           // レンダラーコンポ
    private Renderer _renderer;                  // レンダラーコンポ
    private Color colorYellow = Color.yellow;    // ユニット選択時反転カラー（黄色）

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // アビリティシーンコントローラ取得
        abilityCommon = GameObject.FindWithTag("Canvas").GetComponent<PlaceSelect>();

        // オーディオコンポを取得
        audioCompo = this.gameObject.GetComponent<AudioSource>();

        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/UnitSelect_CountUp");
        audioCompo.clip = clickSE;
    }

    // -----------------------------------
    // カーソルエントリーメソッド
    // -----------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをON
        mouseOverJug = 1;

        // マウスクリック用イベントハンドラをコール
        StartCoroutine("MouseClickHandler");
    }

    // -----------------------------------
    // カーソルエスケープメソッド
    // -----------------------------------
    public void OnPointerExit(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをOFF
        mouseOverJug = 0;

        // マウスクリック用イベントハンドラを停止
        StopCoroutine("MouseClickHandler");
    }

    // -----------------------------------
    // マウスクリック判定メソッド
    // -----------------------------------
    public IEnumerator MouseClickHandler()
    {
        // 自分のアビリティがセット済みか判定し、判定結果を設定
        bool alreadySetAbl = false;
        if (Defines.ABL_NO_ABILITY != gameManager.unitStateList[unitID].ability_A) alreadySetAbl = true;

        // 永続ループ（ただし、マウスオーバーを抜けたらreturnする）
        while (1 == mouseOverJug)
        {
            // マウス左クリックされ、かつまだ本ユニット未選択、かつアビリティ未セットの場合
            if (Input.GetMouseButtonDown(0) && Defines.ABL_NON_VALUE == abilityCommon.unitSelect && false == alreadySetAbl)
            {
                // クリックSEを鳴らす
                audioCompo.Play();

                // ユニットスプライトを発光
                this.GetComponent<Image>().color = Color.yellow;

                // シーンコントローラのユニット選択判定に自分のIDを設定
                abilityCommon.unitSelect = unitID;
            }
            // マウス右クリックされ、かつ本ユニット選択済みの場合
            else if (Input.GetMouseButtonDown(1) && Defines.ABL_NON_VALUE != abilityCommon.unitSelect)
            {
                // クリックSEを鳴らす
                audioCompo.Play();

                // ユニットスプライトの発光を解除
                this.GetComponent<Image>().color = Color.white;

                // シーンコントローラのユニット選択判定を初期化
                abilityCommon.unitSelect = Defines.ABL_NON_VALUE;

                // アビリティを解除
                gameManager.unitStateList[unitID].ability_A = Defines.ABL_NO_ABILITY;
            }
            else // フェールセーフ
            {
            }

            // コルーチンを抜ける
            yield return null;
        }
    }
}
