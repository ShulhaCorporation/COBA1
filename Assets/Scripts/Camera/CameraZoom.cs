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

 public void ScaleCamera(float scale, float duration)
    {   if(zooming != null)
        {
            StopCoroutine(zooming);
        }
        //step = (scale - camera.orthographicSize) / 100;
        zooming = StartCoroutine(Zooming(scale, duration));
      
    }
    

    private IEnumerator Zooming(float targetSize, float duration)
    {
        float startSize = camera.orthographicSize;
       
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the percentage of completion (0 to 1)
            float t = elapsedTime / duration;

            // Use Lerp to find the new orthographic size
            camera.orthographicSize = Mathf.Lerp(startSize, targetSize, t);

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait until the next frame
        }

        // Ensure the final size is set
        camera.orthographicSize = targetSize;
    }

}
