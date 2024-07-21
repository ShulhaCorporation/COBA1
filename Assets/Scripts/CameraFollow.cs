using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private int currentLevel;
    [SerializeField]
    private Transform player;

    void Update()
    {    if (currentLevel == 1)
        {
            this.transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }else if (currentLevel == 2)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
