using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

/// <summary>
/// オブジェクト振動クラス
/// 　①コンストラクタに揺らしたいオブジェクトのTransformを渡す　var envShake = new EnvShake(this.transform);
/// 　②揺らしたいタイミングでWiggler.Initializeメソッドをコールする　envShake.Initialize(0.5f, 10, Vector3.one);
/// 　③LateUpdate等の毎フレーム更新処理内でWigglerUpdateをコールする　envShake.UpdateWiggler(Time.deltaTime);
/// </summary>
public class EnvShake : MonoBehaviour
{
    /// <summary>アンカーオブジェクトの名前用string</summary>
    const string ANCHOR_OBJECT_SUFFIX = "Anchor";
    /// <summary>揺れ段階の更新時に変更する揺れ角度の最少値</summary>
    const float MIN_RANDOM_SHAKE_ANGLE_RANGE = 120f;
    /// <summary>揺れ段階の更新時に変更する揺れ角度の最大値</summary>
    const float MAX_RANDOM_SHAKE_ANGLE_RANGE = 240f;

    private float nowAngle = 0f;
    private float nowTime = 0f;
    private float wiggleSegmentTime = 0f;
    private int totalWiggleCount = 1;
    private int nowWiggleCount = 0;
    private GameObject anchorObject = null;
    /// <summary>揺らす対象（親）となるゲームオブジェクトのTransform</summary>
    private Transform parentTransform = null;
    private Vector3 wiggleRange = Vector3.zero;
    private Vector3 nowWigglePoint = Vector3.zero;
    private Vector3 nextWigglePoint = Vector3.zero;
    private Vector3 nextPosition = Vector3.zero;
    /// <summary>
    /// 揺れ終了判定
    /// </summary>
    public bool isEnd
    {
        get
        {
            return (nowWiggleCount >= totalWiggleCount);
        }
    }

    /// <summary>コンストラクタ</summary>
    /// <param name="parentTransform">揺らす対象とするGameObjectのTransform</param>
    public EnvShake(Transform parentTf)
    {
        this.parentTransform = parentTf;

        // 親Transformの子としてアンカーオブジェクトを追加する
        anchorObject = new GameObject(this.parentTransform.gameObject.name + " " + ANCHOR_OBJECT_SUFFIX);
        anchorObject.transform.position = this.parentTransform.position;
        anchorObject.transform.SetParent(this.parentTransform, false); // 新
//        anchorObject.transform.parent = this.parentTransform; 旧いので削除
        Initialize(0, 1, Vector3.zero);
    }

    /// <summary>揺れ初期化メソッド
    /// <param name="totalTime">総振動時間(sec)</param>
    /// <param name="totalWiggleCount">総振動回数</param>
    /// <param name="wiggleRange">振動幅(m)</param>
    /// </summary>
    public void Initialize(float totalTime, int totalWiggleCount, Vector3 wiggleRange)
    {
        this.totalWiggleCount = Mathf.Max(totalWiggleCount, 1);
        this.wiggleRange = wiggleRange;

        nowTime = 0f;
        wiggleSegmentTime = Mathf.Max(totalTime, 0f) / (float)totalWiggleCount;

        if (wiggleSegmentTime <= 0f)
        {
            nowWiggleCount = totalWiggleCount;
        }
        else
        {
            nowWiggleCount = 0;
        }

        SetNextWigglePoint(nowWiggleCount);
    }

    /// <summary>
    /// 揺れ更新メソッド
    /// <param name="updateTime">更新する時間(sec)</param>
    /// </summary>
    public void UpdateEnvShake(float updateTime)
    {
        if (wiggleSegmentTime <= 0) return;
        if (nowWiggleCount >= totalWiggleCount) return;

        // タイマーの更新
        nowTime += updateTime;

        // 線形補間で揺れポイント間の座標を求める
        Vector3 wigglePoint = (wiggleSegmentTime > 0f) ? Vector3.Slerp(nowWigglePoint, nextWigglePoint, Mathf.Min(nowTime / wiggleSegmentTime, 1f)) : Vector3.zero;

        // カウンタが一定値を超えたら揺れポイントの再設定
        if (nowTime > wiggleSegmentTime)
        {
            nowWiggleCount++;
            SetNextWigglePoint(nowWiggleCount);
            nowTime = 0f;
        }

        nextPosition = anchorObject.transform.position;
        anchorObject.transform.position = this.parentTransform.position - wigglePoint;
        this.parentTransform.position = nextPosition + wigglePoint;
    }

    /// <summary>
    /// 次の揺れポイントを設定する
    /// <param name="count">Count.</param>
    /// </summary>
    private void SetNextWigglePoint(int count)
    {
        if (count < 0 || count > totalWiggleCount) return;
        if (parentTransform == null) return;

        // 現在の揺れポイントを保存
        nowWigglePoint = nextWigglePoint;

        // 揺れ幅割合を算出
        // 残り揺れ回数に反比例して揺れ幅割合は小さくなる
        float wigglePower = Mathf.Clamp((float)((float)totalWiggleCount - (float)count) / Mathf.Max((float)totalWiggleCount, 1f), 0f, 1f);

        // 揺れ幅の向きを決めるデグリー角を求める
        float nextAngle = nowAngle + Random.Range(MIN_RANDOM_SHAKE_ANGLE_RANGE, MAX_RANDOM_SHAKE_ANGLE_RANGE);

        // 親Transformのforwardベクトルを軸にして回転させた揺れ幅に揺れ幅割合を乗算する
        Quaternion normalQuatanion = Quaternion.AngleAxis(nextAngle, parentTransform.forward);
        Vector3 rotatedWiggleScale = normalQuatanion * (parentTransform.rotation * wiggleRange);
        nextWigglePoint = rotatedWiggleScale * wigglePower;

        nowAngle = nextAngle;
    }
}