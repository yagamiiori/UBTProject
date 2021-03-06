﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class OnClickOkForUnitSelect : MonoBehaviour
{
    public AudioClip clickSE;                           // OKボタンクリックSE
    private GameManager gameManager;                    // マネージャコンポ
    private string nextScene = "NameSelect";            // スタートボタンプッシュ時遷移先シーン
    private bool isClick = false;                       // OKボタンクリック判定（OKボタン連打抑止）
    private AudioSource audioCompo;                      // オーディオコンポ
    /// <summary>LinkToXML(旧mySQL)クラス</summary>
    private XmlManager appSettings;

    /// <summary>コンストラクタ</summary>
    private OnClickOkForUnitSelect() { }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        //  LINQ to XMLクラス取得
        appSettings = GameObject.Find("Canvas").GetComponent<XmlManager>();

        // オーディオコンポを取得
        audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        // TODO 本当はリクワイヤードコンポ属性を使うべき。上手く動いてくれなかったのでとりあえず
        if (null == audioCompo) audioCompo = GameObject.Find("PlayersParent").transform.FindChild("SEPlayer").gameObject.GetComponent<AudioSource>();
        clickSE = (AudioClip)Resources.Load("Sounds/SE/Click7");
    }

    // -------------------------------
    // OKボタンクリック判定メソッド（ユニットセレクトシーン）
    // ユニットセレクトシーンにてOKボタンが押された場合（ユニット確定した場合）にコールされ
    // 選択したユニットをユニットリストに格納、アビリティシステム有無フラグを確認し
    // アビリティセレクトシーンまたはポジションセレクトシーンに遷移する。
    // -------------------------------
    public void OnClick()
    {
        // オプションで選択したユニット数と選択済みユニット数が同じ場合
        if (gameManager.unt_NowAllUnits == gameManager.opt_unitNum)
        {
            // まだOKボタンが押されていない場合（連打の抑止）
            if (!isClick)
            {
                isClick = true;

                // クリックSEを設定および再生
                audioCompo.PlayOneShot(clickSE);

                // 確定済み全ユニットリスト生成メソッドをコール
                MyUnitListConst();

                // ユニット情報をXMLへ書き込み
                var xmlManager = GameObject.Find("XmlManager").GetComponent<XmlManager>();
                xmlManager.UnitStateWriteToXml();

                // Scene遷移実施
                // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
                gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
            }
        }
    }

    // ---------------------------------
    // 確定済み全ユニットリスト生成メソッド
    // ユニットセレクトシーンで確定したユニットのリストを生成する。
    // ---------------------------------
    public void MyUnitListConst()
    {
        int unitVal = 0;        // ユニットID

        // ソルジャーがいる場合
        if (0 < gameManager.sodlerNum)
        {
            // ソルジャー数分ループ
            for (int j = 0; j < gameManager.sodlerNum; j++)
            {
                // ユニットステート用GOのインスタンス化とコンポ取得
                GameObject unitGO = Instantiate(Resources.Load("UnitGO"), transform.position, Quaternion.identity) as GameObject;
                unitGO.name = "Solder" + j.ToString();
                UnitState unitstate = unitGO.GetComponent<UnitState>();

                // インスタンス化したユニットステート用GOをGameManagerの子オブジェクトに設定
                unitGO.transform.parent = gameManager.transform;

                // ユニットIDを設定
                unitstate.unitID = unitVal;

                // クラスIDをソルジャーに設定
                unitstate.classType = Defines.SOLDLER;

                // 武器タイプを設定（クラス固有）
                unitstate.weaponType = Defines.UNT_SWORD;

                // 歩行タイプを設定（クラス固有）
                unitstate.workType = Defines.UNT_KEIHO;

                // 性別を設定（※とりあえずクラス固有にする）
                unitstate.sex = Defines.UNT_MALE;

                // ユニットステートリストに格納
                gameManager.unitStateList.Add(unitstate);

                // ユニットIDをカウントアップ
                unitVal++;
            }
        }

        // ウィザードがいる場合
        if (0 < gameManager.wizardNum)
        {
            // ウィザード数分ループ
            for (int j = 0; j < gameManager.wizardNum; j++)
            {
                // ユニットステート用GOのインスタンス化とコンポ取得
                GameObject unitGO = Instantiate(Resources.Load("UnitGO"), transform.position, Quaternion.identity) as GameObject;
                unitGO.name = "Wizard" + j.ToString();
                UnitState unitstate = unitGO.GetComponent<UnitState>();

                // インスタンス化したユニットステート用GOをGameManagerの子オブジェクトに設定
                unitGO.transform.parent = gameManager.transform;

                // ユニットIDを設定
                unitstate.unitID = unitVal;

                // クラスIDをウィザードに設定
                unitstate.classType = Defines.WIZARD;

                // 武器タイプを設定（クラス固有）
                unitstate.weaponType = Defines.UNT_STAFF;

                // 歩行タイプを設定（クラス固有）
                unitstate.workType = Defines.UNT_KEIHO;

                // 性別を設定（※とりあえずクラス固有にする）
                unitstate.sex = Defines.UNT_FEMALE;

                // ユニットステートリストに格納
                gameManager.unitStateList.Add(unitstate);

                // ユニットIDをカウントアップ
                unitVal++;
            }
        }
    }
}
