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
    private Transform objectiv;
    [SerializeField]
    private Transform player;
    public void SetObject(Transform transform)
    {
        objectiv = transform;
    }
    void Start()
    {
        objectiv = player;   
    }
    public void ResetCamera() { 
        objectiv = player;
    }
    void Update()
    {    if (currentLevel == CurrentLevel.Horizontal)
        {
            this.transform.position = new Vector3(objectiv.position.x, transform.position.y, transform.position.z);
        }else if (currentLevel == CurrentLevel.Vertical)
        {
            this.transform.position = new Vector3(objectiv.position.x, objectiv.position.y, transform.position.z);
        }
    }
}
