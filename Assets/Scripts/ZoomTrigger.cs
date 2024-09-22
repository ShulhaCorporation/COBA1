using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger : MonoBehaviour
{
    [SerializeField]
    private float scale;
    [SerializeField]
    private GameObject camera;
    private CameraZoom cameraZoom;
    void Start()
    {
        cameraZoom = camera.GetComponent<CameraZoom>();
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            cameraZoom.ScaleCamera(scale);
        }
    }
}
