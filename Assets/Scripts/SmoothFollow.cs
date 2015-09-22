using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/SmoothFollow")]
public class SmoothFollow : MonoBehaviour
{
    /** 追従するオブジェクト */
    public Transform target;

    /** Z方向の距離 */
    public float distance = 10.0f;

    /** Y方向の高さ */
    public float height = 5.0f;

    /** 上下高さのスムーズ移動速度 */
    public float heightDamping = 2.0f;

    /** 左右回転のスムーズ移動速度 */
    public float rotationDamping = 3.0f;

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        //追従先位置
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        //現在位置
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        //追従先へのスムーズ移動距離(方向)
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle,
            rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //カメラの移動
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;
        transform.position = pos;

        transform.LookAt(target);
    }
}
