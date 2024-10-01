using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    private UnityEngine.Camera camera;
    private float step;
    private Coroutine zooming;
    void Start()
    {
        camera = gameObject.GetComponent<UnityEngine.Camera>();
    }

 public void ScaleCamera(float scale, float speed)
    {   if(zooming != null)
        {
            StopCoroutine(zooming);
        }
        step = (scale - camera.orthographicSize) / 100;
      zooming = StartCoroutine(Zooming(speed));
      
    }
    private IEnumerator Zooming(float delay)
    {
        for(int i = 0; i<100; i++)
        {
            camera.orthographicSize += step;
            yield return new WaitForSeconds(delay);
        }
    }
}
