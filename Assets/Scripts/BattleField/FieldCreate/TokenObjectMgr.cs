using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// TokenObject管理クスラ
/// <para>　Tokenクラスをリスト化し、管理するマネージャークラス。</para>
/// </summary>
/// <typeparam name="Type"></typeparam>
public class TokenObjectMgr<Type> where Type : TipObject
{
    /// <summary>
    /// 管理しているTokenクラスのリスト
    /// </summary>
    private List<Type> tokenList = null;
    /// <summary>
    /// チップGOのPrefab
    /// </summary>
    private GameObject _prefab = null;
    /// <summary>
    /// Sorting Layer名
    /// </summary>
    private string sortingLayerName = "";
    /// <summary>
    /// Order In Layerの値
    /// </summary>
    private int orderInLayerVal = 999;
    /// <summary>
    /// ForEachメソッドに渡す関数のデリゲート型
    /// </summary>
    public delegate void FuncT(Type t);

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="tipPrefabName">チップのPrefab名</param>
    /// <param name="size">サイズ指定（任意）。よく分からん</param>
    public TokenObjectMgr(string tipPrefabName)
    {
        _prefab = Resources.Load(tipPrefabName) as GameObject;
        tokenList = new List<Type>();
    }

    /// <summary>
    /// オブジェクト再利用メソッド
    /// </summary>
    /// <param name="obj">Tokenクラスの親クラス</param>
    /// <param name="x">位置X</param>
    /// <param name="y">位置Y</param>
    /// <param name="direction">向き</param>
    /// <param name="speed">移動速度</param>
    /// <returns></returns>
    Type RecycleGO(Type obj, float x, float y, float direction, float speed)
    {
        // SetActiveメソッドをtrue、また、生存フラグと描画フラグをtrueにして画面表示する
        obj.Revive();
        // 位置Xおよび位置Yをtransform.positionに設定
        obj.SetPosition(x, y);
        // 向きおよび速度をRigidBody.velocityに設定
        obj.SetVelocity(direction, speed);
        // 角度は0固定
        obj.Angle = 0;
        // Sortin Layer名を設定する
        sortingLayerName = "TipObject";
        obj.SortingLayer = sortingLayerName;
        // Order in Layerを設定する
        obj.SortingOrder = orderInLayerVal;
        orderInLayerVal--;
        return obj;
    }

    /// <summary>
    /// Tipクラス管理リスト追加メソッド
    /// <para>　生成したインスタンスが持つTipクラスをTipクラス管理リストに追加する。</para>
    /// <para>　TypeはTipクラス。ExistsはTipの基底クラスToken内のフィールド</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public Type Add(float x, float y, float direction = 0.0f, float speed = 0.0f)
    {
        foreach (Type obj in tokenList)
        {
            if (obj.Exists == false)
            {
                // 未使用のオブジェクトを見つけた場合、再利用メソッドをコールし、再利用する
                return RecycleGO(obj, x, y, direction, speed);
            }
        }

        if (true)
        {
            // インスタンスを生成
            GameObject g = GameObject.Instantiate(_prefab, new Vector3(), Quaternion.identity) as GameObject;
            g.name = "TipObject";
            g.tag = "TipObject";
            // 生成したインスタンスのコンポのTipクラスを取得し、リストに追加する
            Type obj = g.GetComponent<Type>();
            tokenList.Add(obj);
            // 再利用メソッドを利用
            return RecycleGO(obj, x, y, direction, speed);
        }
    }

    /// 生存するインスタンスに対してラムダ式を実行する
    public void ForEachExist(FuncT func)
    {
        foreach (var obj in tokenList)
        {
            if (obj.Exists)
            {
                func(obj);
            }
        }
    }

    /// <summary>
    /// 全インスタンス破棄メソッド
    /// </summary>
    public void Vanish()
    {
        ForEachExist(t => t.Vanish());
    }

    /// <summary>
    /// インスタンス生存数取得メソッド
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        int ret = 0;
        ForEachExist(t => ret++);

        return ret;
    }
}
