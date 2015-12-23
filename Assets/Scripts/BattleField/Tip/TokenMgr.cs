using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// Token管理クスラ
public class TokenMgr<Type> where Type : Tip
{
    /// <summary>
    /// ？？？
    /// </summary>
    int _size = 0;
    /// <summary>
    /// チップGOのPrefab
    /// </summary>
    GameObject _prefab = null;
    /// <summary>
    /// ？？？
    /// </summary>
    List<Type> _pool = null;
    /// <summary>
    /// Order In Layerの値
    /// </summary>
    private int orderInLayerVal = 999;
    /// <summary>
    /// ForEach関数に渡す関数のデリゲート型
    /// </summary>
    public delegate void FuncT(Type t);

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="tipPrefabName">チップのPrefab名</param>
    /// <param name="size">サイズ指定（任意）。よく分からん</param>
    public TokenMgr(string tipPrefabName, int size = 0)
    {
        _size = size;
        _prefab = Resources.Load(tipPrefabName) as GameObject;
        _pool = new List<Type>();

        // サイズ指定があれば固定アロケーションとする（今の仕様では使わない）
        if (size > 0)
        {
            for (int i = 0; i < size; i++)
            {
                GameObject g = GameObject.Instantiate(_prefab, new Vector3(), Quaternion.identity) as GameObject;
                Type obj = g.GetComponent<Type>();
                obj.Vanish();
                _pool.Add(obj);
            }
        }
    }

    /// オブジェクトを再利用する
    Type _Recycle(Type obj, float x, float y, float direction, float speed)
    {
        // 復活
        obj.Revive();
        obj.SetPosition(x, y);
        obj.SetVelocity(direction, speed);
        obj.Angle = 0;
        // Order in Layerを設定する
        obj.SortingOrder = orderInLayerVal;
        orderInLayerVal--;
        return obj;
    }

    /// インスタンスを取得する
    public Type Add(float x, float y, float direction = 0.0f, float speed = 0.0f)
    {
        foreach (Type obj in _pool)
        {
            if (obj.Exists == false)
            {
                // 未使用のオブジェクトを見つけた
                return _Recycle(obj, x, y, direction, speed);
            }
        }

        if (_size == 0)
        {
            // 自動で拡張
            GameObject g = GameObject.Instantiate(_prefab, new Vector3(), Quaternion.identity) as GameObject;
            Type obj = g.GetComponent<Type>();
            _pool.Add(obj);
            return _Recycle(obj, x, y, direction, speed);
        }
        return null;
    }

    /// 生存するインスタンスに対してラムダ式を実行する
    public void ForEachExist(FuncT func)
    {
        foreach (var obj in _pool)
        {
            if (obj.Exists)
            {
                func(obj);
            }
        }
    }

    /// 生存しているインスタンスをすべて破棄する
    public void Vanish()
    {
        ForEachExist(t => t.Vanish());
    }

    /// インスタンスの生存数を取得する
    public int Count()
    {
        int ret = 0;
        ForEachExist(t => ret++);

        return ret;
    }
}
