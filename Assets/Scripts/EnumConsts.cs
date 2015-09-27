using UnityEngine;
using System.Collections;

public class EnumConsts : MonoBehaviour {

    /// <summary>プレイヤーがどの状態にあるか？</summary>
    public enum GameState : int
    {
        Room = 0,   // ルームにいない
        Play = 1,   // ルームにいる（ゲーム中である）
    }
}
