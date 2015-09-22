using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectButtonOK : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private string nextScene = "NameSelect";            // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ
    public AudioSource audioCompo;                      // オーディオコンポ
    public AudioClip clickSE_OKbutton;                  // OKボタンクリックSE

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポ取得とOKボタンクリック時SEの設定
        audioCompo = this.gameObject.GetComponent<AudioSource>();
        clickSE_OKbutton = (AudioClip)Resources.Load("Sounds/SE/OKButtonSE");
    }

    // -------------------------------
    // OKボタンクリック判定メソッド（ユニットセレクトシーン）
    // ユニットセレクトシーンにてOKボタンが押された場合（ユニット確定した場合）にコールされ
    // 選択したユニットをユニットリストに格納、アビリティシステム有無フラグを確認し
    // アビリティセレクトシーンまたはポジションセレクトシーンに遷移する。
    // -------------------------------
    public void OnClick()
    {
        // スタートボタン未プッシュの場合、かつオプションで選択したユニット数と選択済みユニット数が同じ場合
        if (0 == isStarted && (gameManager.unt_NowAllUnits == gameManager.opt_unitNum))
        {
            // クリックSEを設定および再生
            audioCompo.clip = clickSE_OKbutton;
            audioCompo.Play();

            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // オプションが変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // 確定済み全ユニットリスト生成メソッドをコール
            MyUnitListConst();

            // Scene遷移実施
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
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
        if (0 < gameManager.unt_Sodler)
        {
            // ソルジャー数分ループ
            for (int j = 0; j < gameManager.unt_Sodler; j++)
            {
                // ユニットステート用GOのインスタンス化とコンポ取得
                GameObject unitState = Instantiate(Resources.Load("UnitState"), transform.position, Quaternion.identity) as GameObject;
                UnitState unitstate = unitState.GetComponent<UnitState>();

                // インスタンス化したユニットステート用GOをGameManagerの子オブジェクトに設定
                unitState.transform.parent = gameManager.transform;

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
        if (0 < gameManager.unt_Wizard)
        {
            // ウィザード数分ループ
            for (int j = 0; j < gameManager.unt_Wizard; j++)
            {
                // ユニットステート用GOのインスタンス化とコンポ取得
                GameObject unitState = Instantiate(Resources.Load("UnitState"), transform.position, Quaternion.identity) as GameObject;
                UnitState unitstate = unitState.GetComponent<UnitState>();

                // インスタンス化したユニットステート用GOをGameManagerの子オブジェクトに設定
                unitState.transform.parent = gameManager.transform;

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
