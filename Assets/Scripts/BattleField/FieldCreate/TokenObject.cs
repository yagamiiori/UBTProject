using UnityEngine;
using System.Collections;

/// <summary>
/// キャラクターとチップの基底クラス
/// <para>　自身のインスタンス化や座標の決定などのメソッドを有する。</para>
/// </summary>
public class TokenObject : MonoBehaviour
{
    /// <summary>
    /// このチップが属するマップ構成マトリクス上のX軸
    /// </summary>
    public int matrixX = 0;
    /// <summary>
    /// このチップが属するマップ構成マトリクス上のY軸
    /// </summary>
    public int matrixY = 0;
    /// <summary>
    /// 生存フラグ
    /// </summary>
    bool _exists = false;
    public bool Exists
    {
        get { return _exists; }
        set { _exists = value; }
    }
    /// <summary>
    /// スプライトレンダラーコンポ
    /// </summary>
    SpriteRenderer _renderer = null;
    public SpriteRenderer Renderer
    {
        get { return _renderer ?? (_renderer = gameObject.GetComponent<SpriteRenderer>()); }
    }
    /// <summary>
    /// 描画有無判定
    /// </summary>
    public bool Visible
    {
        get { return Renderer.enabled; }
        set { Renderer.enabled = value; }
    }
    /// <summary>
    /// SortingLayer名
    /// </summary>
    public string SortingLayer
    {
        get { return Renderer.sortingLayerName; }
        set { Renderer.sortingLayerName = value; }
    }
    /// <summary>
    /// SortingOrder番号
    /// </summary>
    public int SortingOrder
    {
        get { return Renderer.sortingOrder; }
        set { Renderer.sortingOrder = value; }
    }
    /// <summary>
    /// X座標
    /// </summary>
    public float X
    {
        set { Vector3 pos = transform.position; pos.x = value; transform.position = pos; }
        get { return transform.position.x; }
    }
    /// <summary>
    /// Y座標
    /// </summary>
    public float Y
    {
        set { Vector3 pos = transform.position; pos.y = value; transform.position = pos; }
        get { return transform.position.y; }
    }
    /// <summary>
    /// スケール値X
    /// </summary>
    public float ScaleX
    {
        set { Vector3 scale = transform.localScale; scale.x = value; transform.localScale = scale; }
        get { return transform.localScale.x; }
    }
    /// <summary>
    /// スケール値Y
    /// </summary>
    public float ScaleY
    {
        set { Vector3 scale = transform.localScale; scale.y = value; transform.localScale = scale; }
        get { return transform.localScale.y; }
    }
    /// <summary>
    /// 剛体（RigidBody2Dコンポ）
    /// </summary>
    Rigidbody2D _rigidbody2D = null;
    public Rigidbody2D RigidBody
    {
        get { return _rigidbody2D ?? (_rigidbody2D = gameObject.GetComponent<Rigidbody2D>()); }
    }
    /// <summary>
    /// 移動量(X)
    /// </summary>
    public float VX
    {
        get { return RigidBody.velocity.x; }
        set { Vector2 v = RigidBody.velocity; v.x = value; RigidBody.velocity = v; }
    }
    /// <summary>
    /// 移動量(Y)
    /// </summary>
    public float VY
    {
        get { return RigidBody.velocity.y; }
        set { Vector2 v = RigidBody.velocity; v.y = value; RigidBody.velocity = v; }
    }
    /// <summary>
    /// 向き
    /// </summary>
    public float Direction
    {
        get { Vector2 v = GetComponent<Rigidbody2D>().velocity; return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg; }
    }
    /// <summary>
    /// 速度
    /// </summary>
    public float Speed
    {
        get { Vector2 v = GetComponent<Rigidbody2D>().velocity; return Mathf.Sqrt(v.x * v.x + v.y * v.y); }
    }
    /// <summary>
    /// 重力
    /// </summary>
    public float GravityScale
    {
        get { return RigidBody.gravityScale; }
        set { RigidBody.gravityScale = value; }
    }
    /// <summary>
    /// 回転角度
    /// </summary>
    public float Angle
    {
        set { transform.eulerAngles = new Vector3(0, 0, value); }
        get { return transform.eulerAngles.z; }
    }
    /// <summary>
    /// アルファ値
    /// </summary>
    public float Alpha
    {
        set { SetAlpha(value); }
        get { return GetAlpha(); }
    }
    /// <summary>
    /// サイズ横
    /// </summary>
    float _width = 0.0f;
    /// <summary>
    /// サイズ高さ
    /// </summary>
    float _height = 0.0f;
    /// <summary>
    /// スプライトの横幅
    /// </summary>
    public float SpriteWidth
    {
        get { return Renderer.bounds.size.x; }
    }
    /// <summary>
    /// スプライトの高さ
    /// </summary>
    public float SpriteHeight
    {
        get { return Renderer.bounds.size.y; }
    }
    /// <summary>
    /// コリジョン（円）
    /// </summary>
    CircleCollider2D _circleCollider = null;
    public CircleCollider2D CircleCollider
    {
        get { return _circleCollider ?? (_circleCollider = GetComponent<CircleCollider2D>()); }
    }
    /// <summary>
    // 円コリジョンの半径
    /// </summary>
    public float CollisionRadius
    {
        get { return CircleCollider.radius; }
        set { CircleCollider.radius = value; }
    }
    /// <summary>
    // 円コリジョンの有効無効
    /// </summary>
    public bool CircleColliderEnabled
    {
        get { return CircleCollider.enabled; }
        set { CircleCollider.enabled = value; }
    }
    /// <summary>
    /// コリジョン（矩形）
    /// </summary>
    BoxCollider2D _boxCollider = null;
    public BoxCollider2D BoxCollider
    {
        get { return _boxCollider ?? (_boxCollider = GetComponent<BoxCollider2D>()); }
    }
    /// <summary>
    /// Boxコライダーの横幅
    /// </summary>
    public float BoxColliderWidth
    {
        get { return BoxCollider.size.x; }
        set
        {
            var size = BoxCollider.size;
            size.x = value;
            BoxCollider.size = size;
        }
    }
    /// <summary>
    /// Boxコライダーの高さ
    /// </summary>
    public float BoxColliderHeight
    {
        get { return BoxCollider.size.y; }
        set
        {
            var size = BoxCollider.size;
            size.y = value;
            BoxCollider.size = size;
        }
    }

    /// <summary>
    /// プレハブ取得メソッド
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject GetPrefab(GameObject prefab, string name)
    {
        return prefab ?? (prefab = Resources.Load("Prefabs/" + name) as GameObject);
    }

    /// <summary>
    /// インスタンス化（Instantiate）開始メソッド
    /// <para>　引数で指定された名前のPrefabをInstantiate（インスタンス化）し、</para>
    /// <para>　インスタンス化したGOのTokenコンポの親クラス（Tipクラス）を返す。</para>
    /// </summary>
    /// <typeparam name="Type">Tokenクラスの親クラス</typeparam>
    /// <param name="prefab">インスタンス化するGOのPrefab名</param>
    /// <param name="x">画面座標X軸</param>
    /// <param name="y">画面座標Y軸</param>
    /// <param name="direction">向き</param>
    /// <param name="speed">移動速度</param>
    /// <returns></returns>
    public static Type CreateInstance<Type>(GameObject prefab, float x, float y, float direction = 0.0f, float speed = 0.0f) where Type : Token
    {
        Vector3 pos = new Vector3(x, y, 0);
        return RunInstantiate<Type>(prefab, pos, direction, speed);
    }

    /// <summary>
    /// インスタンス化（Instantiate）実行メソッド
    /// <para>　CreateInstanceメソッドからコールされ、Instantiate（インスタンス化）を実行する。</para>
    /// </summary>
    /// <typeparam name="Type">Tokenクラスの親クラス</typeparam>
    /// <param name="prefab">インスタンス化するGOのPrefab名</param>
    /// <param name="p">GOを配置するVector3座標</param>
    /// <param name="direction">向き</param>
    /// <param name="speed">移動速度</param>
    /// <returns></returns>
    public static Type RunInstantiate<Type>(GameObject prefab, Vector3 p, float direction = 0.0f, float speed = 0.0f) where Type : Token
    {
        GameObject g = Instantiate(prefab, p, Quaternion.identity) as GameObject;
        Type obj = g.GetComponent<Type>();
        obj.SetVelocity(direction, speed);
        return obj;
    }

    /// <summary>
    /// 座標加算メソッド
    /// </summary>
    public void AddPosition(float dx, float dy)
    {
        X += dx;
        Y += dy;
    }

    /// <summary>
    /// 座標設定メソッド
    /// </summary>
    public void SetPosition(float x, float y)
    {
        Vector3 pos = transform.position;
        pos.Set(x, y, 0);
        transform.position = pos;
    }

    /// <summary>
    /// スケール値設定メソッド
    /// </summary>
    /// <param name="x">設定するスケール値X</param>
    /// <param name="y">設定するスケール値Y</param>
    public void SetScale(float x, float y)
    {
        Vector3 scale = transform.localScale;
        scale.Set(x, y, (x + y) / 2);
        transform.localScale = scale;
    }

    /// <summary>
    /// スケール値（X/Y）
    /// </summary>
    public float Scale
    {
        get { Vector3 scale = transform.localScale; return (scale.x + scale.y) / 2.0f; }
        set { Vector3 scale = transform.localScale; scale.x = value; scale.y = value; transform.localScale = scale; }
    }

    /// <summary>
    /// スケール値加算メソッド
    /// </summary>
    /// <param name="d"></param>
    public void AddScale(float d)
    {
        Vector3 scale = transform.localScale;
        scale.x += d;
        scale.y += d;
        transform.localScale = scale;
    }

    /// <summary>
    /// スケール値乗算メソッド
    /// </summary>
    /// <param name="d"></param>
    public void MulScale(float d)
    {
        transform.localScale *= d;
    }

    /// <summary>
    /// 移動速度設定メソッド
    /// </summary>
    /// <param name="direction">向き</param>
    /// <param name="speed">移動速度</param>
    public void SetVelocity(float direction, float speed)
    {
        Vector2 v;
        v.x = Util.CosEx(direction) * speed;
        v.y = Util.SinEx(direction) * speed;
        RigidBody.velocity = v;
    }

    /// <summary>
    /// 移動速度設定メソッド
    /// </summary>
    /// <param name="vx">X軸の移動速度</param>
    /// <param name="vy">Y軸の移動速度</param>
    public void SetVelocityXY(float vx, float vy)
    {
        Vector2 v;
        v.x = vx;
        v.y = vy;
        RigidBody.velocity = v;
    }

    /// <summary>
    /// 移動量乗算メソッド
    /// </summary>
    /// <param name="d"></param>
    public void MulVelocity(float d)
    {
        RigidBody.velocity *= d;
    }

    /// <summary>
    /// スプライト設定メソッド
    /// </summary>
    /// <param name="sprite">設定するスプライト</param>
    public void SetSprite(Sprite sprite)
    {
        Renderer.sprite = sprite;
    }

    /// <summary>
    /// カラー設定メソッド
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    public void SetColor(float r, float g, float b)
    {
        var c = Renderer.color;
        c.r = r; c.g = g; c.b = b;
        Renderer.color = c;
    }

    /// <summary>
    /// アルファ値を設定メソッド
    /// </summary>
    /// <param name="a">設定するアルファ値</param>
    public void SetAlpha(float a)
    {
        var c = Renderer.color;
        c.a = a;
        Renderer.color = c;
    }

    /// <summary>
    /// アルファ値取得メソッド
    /// </summary>
    /// <returns></returns>
    public float GetAlpha()
    {
        var c = Renderer.color;
        return c.a;
    }

    /// <summary>
    /// 自身の幅＋高さサイズ設定メソッド
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetSize(float width, float height)
    {
        _width = width;
        _height = height;
    }

    /// <summary>
    // 箱コリジョンのサイズ設定メソッド
    /// </summary>
    /// <param name="w"></param>
    /// <param name="h"></param>
    public void SetBoxColliderSize(float w, float h)
    {
        BoxCollider.size.Set(w, h);
    }

    /// <summary>
    // 箱コリジョンの有効無効判定
    /// </summary>
    public bool BoxColliderEnabled
    {
        get { return BoxCollider.enabled; }
        set { BoxCollider.enabled = value; }
    }

    /// <summary>
    /// 画面内強制移動メソッド（歩いて移動）
    /// <para>　画面外にいる場合、画面内に収めるよう移動させる。</para>
    /// </summary>
    /// <param name="v"></param>
    public void ClampScreenAndMove(Vector2 v)
    {
        // 画面左下と右上の座標を取得する
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();

        // 自身の座標を取得する
        Vector2 pos = transform.position;
        pos += v;

        // 画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // プレイヤーの座標を反映
        transform.position = pos;
    }

    /// <summary>
    /// 画面内強制移動メソッド（瞬間移動）
    /// <para>　画面外にいる場合、画面内に収めるよう移動させる。</para>
    /// </summary>
    public void ClampScreen()
    {
        // 画面左下と右上の座標を取得する
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();

        // 自身の座標を取得する
        Vector2 pos = transform.position;

        // 画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // プレイヤーの座標に反映
        transform.position = pos;
    }

    /// <summary>
    /// 画面外判定メソッド
    /// <para>　自身が画面外に出たかを判定する。</para>
    /// </summary>
    /// <returns></returns>
    public bool IsOutside()
    {
        // 画面左下と右上の座標を取得する
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();

        // 自身の座標を取得する
        Vector2 pos = transform.position;

        if (pos.x < min.x || pos.y < min.y)
        {
            return true; // 画面外の場合
        }
        if (pos.x > max.x || pos.y > max.y)
        {
            return true; // 画面外の場合
        }

        // 画面内の場合
        return false;
    }

    /// <summary>
    /// ワールド座標（画面左下）取得メソッド
    /// <para>　画面左下のワールド座標を取得する。</para>
    /// </summary>
    /// <param name="noMergin"></param>
    /// <returns></returns>
    public Vector2 GetWorldMin(bool noMergin = false)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (noMergin)
        {
            // そのまま返す
            return min;
        }

        // 自身のサイズを考慮する
        min.x += _width;
        min.y += _height;
        return min;
    }

    /// <summary>
    /// ワールド座標（画面右上）取得メソッド
    /// <para>　画面右上のワールド座標を取得する。</para>
    /// </summary>
    /// <param name="noMergin"></param>
    /// <returns></returns>
    public Vector2 GetWorldMax(bool noMergin = false)
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (noMergin)
        {
            // そのまま返す
            return max;
        }

        // 自身のサイズを考慮する
        max.x -= _width;
        max.y -= _height;
        return max;
    }

    /// <summary>
    /// 破棄メソッド
    /// <para>　自身を破棄する。</para>
    /// </summary>
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 蘇生メソッド
    /// <para>　自身を可視化する。</para>
    /// </summary>
    public void Revive()
    {
        gameObject.SetActive(true);
        Exists = true;
        Visible = true;
    }

    /// <summary>
    /// 非表示メソッド
    /// <para>　自身を不可視にする。</para>
    /// </summary>
    public void Vanish()
    {
        gameObject.SetActive(false);
        Exists = false;
    }
}
