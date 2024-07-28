using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentLevel{
    Horizontal,
    Vertical,
}


public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private CurrentLevel currentLevel;
    [SerializeField]
    private Transform player;

    void Update()
    {    if (currentLevel == CurrentLevel.Horizontal)
        {
            this.transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }else if (currentLevel == CurrentLevel.Vertical)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
