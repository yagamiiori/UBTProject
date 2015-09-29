using UnityEngine;
using System.Collections;

public class SubCameraFollow : MonoBehaviour {

    /// <summary>追従するオブジェクト</summary>
    [SerializeField]
    private Transform target;
    /// <summary>追従する位置</summary>
    private Vector3 pos;

    void LateUpdate()
    {
        if (target == null)
        {
            this.enabled = false;
        }

        pos.x = target.position.x;
        pos.y = 17.0f;
        pos.z = target.position.z;

        //カメラの移動
        transform.position = pos;

        transform.LookAt(target);
    }
}
