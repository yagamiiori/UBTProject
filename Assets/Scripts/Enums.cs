﻿using UnityEngine;
using System.Collections;

public static class Enums
{
    /// <summary>
    /// バトルフィールドの状態
    /// </summary>
    public enum BattleState
    {
        /// <summary>バトル前のパネル選択中</summary>
        StartingSetUp,
        /// <summary>バトル中</summary>
        BattleNow,
        /// <summary>バトル終了</summary>
        Congratulations
    }

    /// <summary>
    /// オブザーバの状態
    /// </summary>
    public enum ObserverState
    {
        /// <summary>選択された</summary>
        OnClick,
        /// <summary>選択済み</summary>
        AlreadyClicked,
        /// <summary>キャンセルされた</summary>
        Canceled
    }

    /// <summary>
    /// フェードイン/アウトの移動方向
    /// </summary>
    public enum fadeFrom
    {
        /// <summary>上</summary>
        fromUp,
        /// <summary>下</summary>
        fromUnder,
        /// <summary>左</summary>
        fromLeft,
        /// <summary>右</summary>
        fromRight
    }
}
