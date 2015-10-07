﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectButtonSol : 
    MonoBehaviour,
    IUnitSelect,                            //  ユニットセレクトIF
    IPointerEnterHandler,
    IPointerExitHandler
{
    private GameManager gameManager;        // マネージャコンポ
    private GameObject canVas;              // ゲームオブジェクト"Canvas"
    private Slider sliderSolder;            // ソルジャーのスライダーコンポ
    public int mouseOverJug = 0;            // マウスオーバー判定フラグ
    public AudioSource audioCompo;          // オーディオコンポ
    public AudioClip clickSE;               // クリックSE
    public Text counterUnitValue;           // ユニット数表示Textコンポ
    private PlayEffect playEffect;          // エフェクト表示クラス
    private string effectSprite = "Effect_1"; // エフェクトスプライト名
    
    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // エフェクト表示クラス取得
        playEffect = new PlayEffect();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();

        // ユニット数表示Textコンポ取得
        counterUnitValue = GameObject.FindWithTag("Unit_CounterSold").GetComponent<Text>();

        // ソルジャーのスライダーコンポを取得
        sliderSolder = GameObject.Find("Slider_Solder").GetComponent<Slider>();
    }

    // -----------------------------------
    // カーソルエントリーメソッド
    // -----------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをON
        mouseOverJug = 1;

        // マウスクリック用イベントハンドラをコール
        StartCoroutine(MouseClickHandler());
    }

    // -----------------------------------
    // カーソルエスケープメソッド
    // -----------------------------------
    public void OnPointerExit(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをOFF
        mouseOverJug = 0;

        // マウスクリック用イベントハンドラを停止
        StopCoroutine(MouseClickHandler());
    }

    // -----------------------------------
    // マウスクリック判定メソッド
    // -----------------------------------
    public IEnumerator MouseClickHandler()
    {
        // 永続ループ（ただし、マウスオーバーを抜けたらreturnする）
        while (1 == mouseOverJug)
        {
            // マウス左クリックされた場合
            if (Input.GetMouseButtonDown(0))
            {
                // 現選択ユニット数がオプションで決定したユニット数以下の場合
                if (gameManager.opt_unitNum > gameManager.unt_NowAllUnits)
                {
                    // クリックSEを設定
                    clickSE = (AudioClip)Resources.Load("Sounds/SE/Click4");
                    // 設定したSEを鳴らす
                    audioCompo.PlayOneShot(clickSE);

                    // ソルジャー数をインクリメント
                    gameManager.sodlerNum += 1;

                    // 現在選択されている選択参加ユニットの総数をインクリメント
                    gameManager.unt_NowAllUnits += 1;

                    // ユニット数表示Textコンポに現ユニット数を表示
                    counterUnitValue.text = gameManager.sodlerNum.ToString();

                    // クリックエフェクト表示メソッドをコール(this.gameObjectとするとなぜかバグる)
                    playEffect.PlayOnce(effectSprite, canVas, new Vector3(-282f, 135f, 0f));

                    // ソルジャーのスライダー値をインクリメント
                    if (sliderSolder.value < sliderSolder.maxValue) sliderSolder.value += 1;
                }
            }
            // マウス右クリックされた場合
            else if (Input.GetMouseButtonDown(1))
            {
                // ソルジャーが1以上選択されている場合
                if (1 <= gameManager.sodlerNum)
                {
                    // クリックSEを設定
                    clickSE = (AudioClip)Resources.Load("Sounds/SE/Cancel");
                    audioCompo.PlayOneShot(clickSE);

                    // クリックSEを鳴らす
                    audioCompo.Play();

                    // ソルジャー数をデクリメント
                    gameManager.sodlerNum -= 1;

                    // 現在選択されている選択参加ユニットの総数をデクリメント
                    gameManager.unt_NowAllUnits -= 1;

                    // ユニット数表示Textコンポに現ユニット数を表示
                    counterUnitValue.text = gameManager.sodlerNum.ToString();

                    // ソルジャーのスライダー値をデクリメント
                    if (sliderSolder.value > sliderSolder.minValue) sliderSolder.value -= 1;
                }
            }

            // コルーチンを抜ける
            yield return null;
        }
    }
}
