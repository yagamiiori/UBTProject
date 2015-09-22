using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class AbilityObserver :
    MonoBehaviour,
    IPointerEnterHandler,
    IObserver,                                   // オブサーバIF
    IPointerExitHandler
{
    private GameManager gameManager;             // マネージャコンポ
    private GameObject canVas;                   // ゲームオブジェクト"Canvas"
    private AbilitySelect abilityCommon;         // アビリティシーンコントローラ
    private Image unitSpriteImage;               // 自分のImageコンポ
    private Color thisAlpha;                     // 自身透明化のためのカラーフィールド
    private AbilitySubject subjectComp;          // サブジェクトコンポ
    public int unitID = 100;                     // ユニットID（AbilitySelectクラスから設定される）
    public int mouseOverJug = 0;                 // マウスオーバー判定フラグ
    private SpriteRenderer spRenderer;           // レンダラーコンポ
    private Renderer _renderer;                  // レンダラーコンポ
    private Color colorYellow = Color.yellow;    // ユニット選択時反転カラー（黄色）


    // ----------------------------------------
    // オブサーバ通知メソッド（オブサーバIF）
    // ユニットがクリックされた場合にサブジェクトよりコールされる
    // ----------------------------------------
    public void Notify(int jud)
    {
        // ユニットが左クリックされた場合（アビリティ選択処理を行う）
        if (1 == jud)
        {
            // 自分を透明化
            thisAlpha = new Color(255, 255, 255, -255);
            unitSpriteImage.color = thisAlpha;
        }
        // ユニットが右クリックされた場合（アビリティ選択の解除処理を行う）
        else
        {
            // 透明化を解除
            thisAlpha = new Color(255, 255, 255, 255);
            unitSpriteImage.color = thisAlpha;
        }
    }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // アビリティシーンコントローラ取得
        abilityCommon = GameObject.FindWithTag("Canvas").GetComponent<AbilitySelect>();

        // 自分のImageコンポ取得
        unitSpriteImage = this.gameObject.GetComponent<Image>();

        // サブジェクトコンポ
        subjectComp = canVas.GetComponent<AbilitySubject>();

        // サブジェクトのオブサーバリストに自身を追加
        subjectComp.Attach(this);
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
            // マウス左クリックされ、かつまだ本ユニット未選択の場合
            if (Input.GetMouseButtonDown(0) && Defines.ABL_NON_VALUE == abilityCommon.unitSelect)
            {
                // シーンコントローラのユニット選択判定に自分のIDを設定
                abilityCommon.unitSelect = unitID;

                // サブジェクトのトリガーをONにする
                // これによりオブサーバ（このクラス）内Notifyメソッドがコールされるので
                // その中で自身の透明化などの処理を行う。
                subjectComp.status = 1;
            }

            // コルーチンを抜ける
            yield return null;
        }
    }
}
