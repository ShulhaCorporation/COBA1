using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    private UnityEngine.Camera camera;

    void Start()
    {
        camera = gameObject.GetComponent<UnityEngine.Camera>();
    }

 public void ScaleCamera(float scale)
    {    
        camera.orthographicSize = scale;
    }
}
