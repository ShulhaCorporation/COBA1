using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    [SerializeField]
    private CheckpointController checkpointController;

    public void Reload()
    {
        checkpointController.Respawn();
    }
}
