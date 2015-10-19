using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitMoveStartByAstar : MonoBehaviour
{
    /// <summary>パネルの斜め移動の可否判定</summary>
    public bool isAllowDiagMoving = false;
    /// <summary>A*アルゴリズムクラス</summary>
    private AstarAlgorithm aStarAlgorithm;
    /// <summary>チップのワールド座標取得クラス</summary>
    private GetPanelCoordinate panelCoordinate;
    /// <summary>
    /// ユニットの状態を表す列挙体
    /// </summary>
    private enum unitMoveState
    {
        /// <summary>A*経路計算中</summary>
        AstarExec,
        /// <summary>移動中</summary>
        NowMoving,
        /// <summary>移動終了</summary>
        MoveEnd
    }
    unitMoveState _state = unitMoveState.AstarExec;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UnitMoveStartByAstar() { }

    void Start()
    {
        // A*アルゴリズムクラス取得
        aStarAlgorithm = GameObject.Find("Canvas_Astar").GetComponent<AstarAlgorithm>();
        // パネル座標取得クラス取得
        panelCoordinate = GameObject.Find("Canvas_Astar").GetComponent<GetPanelCoordinate>();
    }

    private void UnitMove()
    {
        // パスリスト（最終的にユニットが通るパネル座標のリスト）
        var pathList = new List<AstarAlgorithm.Point2>();

        // A-star処理関連を実施
        {
            // スタート地点を設定
            Vector3 start = new Vector3(15, 15, 0);
            // ゴール地点を設定
            Vector3 goal = new Vector3(15, 15, 0);

            // コンストラクタにそれぞれの値を渡してインスタンス化
            var anodeManager = new AstarAlgorithm.ANodeManager((int)goal.x, (int)goal.y, isAllowDiagMoving);

            // スタート地点のノードを取得し、最小ノードに設定する。スタート地点なのでコストは「0」
            AstarAlgorithm.ANode minScoreNode = anodeManager.OpenNode((int)start.x, (int)start.y, 0, null);
            // それをオープンノードリストに追加する
            anodeManager.AddOpenNodeList(minScoreNode);

            // 移動試行回数。1000回超えたら強制中断
            int cnt = 0;
            while (cnt < 1000)
            {
                // 今いるパネルをオープンノードリストから削除
                anodeManager.RemoveOpenNodeList(minScoreNode);
                // 周囲を開く
                anodeManager.OpenAround(minScoreNode);
                // 最小スコアのノードを探す.
                minScoreNode = anodeManager.SearchMinScoreNodeFromOpenList();

                if (minScoreNode == null)
                {
                    // 最小スコアのノードがない場合は終了
                    Debug.Log("Not found path.");
                    break;
                }

                // ゴールまでの経路算出が完了した場合？
                if (minScoreNode.X == goal.x && minScoreNode.Y == goal.y)
                {
                    Debug.Log("Success.");
                    // オープンノードリストから最小スコアのノードを削除する
                    anodeManager.RemoveOpenNodeList(minScoreNode);

                    // パスを取得する
                    minScoreNode.GetPath(pathList);

                    // pathListがゴール→現在位置という並びになっているので現在位置→ゴールの並びにするため反転を行う
                    pathList.Reverse();
                    break;
                }
            }
        } // A-star処理関連を実施ここまで

        // ユニットの状態を移動中に変更し、ユニットの移動を実施する
        _state = unitMoveState.NowMoving;
        foreach (var p in pathList)
        {
            // 移動先パネルのXY値を取得
            var x = panelCoordinate.GetPanelX(p.x);
            var y = panelCoordinate.GetPanelY(p.y);

            Vector3 toPanel = new Vector3(x, y, 0);

            // 移動実施
            this.transform.position = toPanel;
        }
        // ユニット状態を移動停止に設定する
        _state = unitMoveState.MoveEnd;
    }
}
