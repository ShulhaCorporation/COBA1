using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField]    //для босса кажана
    private float intensity; //0.7f
    [SerializeField]
    private float speed;  //0.7f 
    [SerializeField] 
    private float angleSpeed; //18f
    [SerializeField] 
    private float innerAngle; //35.5f
    [SerializeField] 
    private float outerAngle; //79.4f
    [SerializeField]
    private Light2D light;
    private Coroutine lightOn;
    private Coroutine lightOff;
    public void TurnOn()
    {    
       StartCoroutine(LightOn());   
       StartCoroutine(OpenInnerAngle());
       StartCoroutine(OpenOuterAngle());
    }
    public void Explode()
    {   if (lightOff != null)
        {
            StopCoroutine(lightOff);
        }
        lightOn = StartCoroutine(LightOn());
    }
    public void TurnOff()
    {    if (lightOn != null)
        {
            StopCoroutine(lightOn);
        }
        lightOff = StartCoroutine(LightOff());
    }
    IEnumerator LightOn()
    {
       
        while(light.intensity < intensity)
        {
            light.intensity += speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
    IEnumerator LightOff()
    {

        while (light.intensity > 0)
        {
            light.intensity -= speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
    IEnumerator OpenInnerAngle()
    {
       
        while (light.pointLightInnerAngle < innerAngle)
        {
            light.pointLightInnerAngle += angleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
    IEnumerator OpenOuterAngle()
    {
        
        while (light.pointLightOuterAngle < outerAngle)
        {
            light.pointLightOuterAngle += angleSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
}
