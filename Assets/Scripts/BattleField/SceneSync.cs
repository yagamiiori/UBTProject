using UnityEngine;
using System.Collections;

public class SceneSync : MonoBehaviour
{
    void Awake()
    {
        if(!PhotonNetwork.isMessageQueueRunning) PhotonNetwork.isMessageQueueRunning = false;
    }
}
