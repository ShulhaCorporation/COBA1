using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Blindfold : MonoBehaviour
{
    [SerializeField]
    private float transitionTime;
    private Image blindfold;
    void Start()
    {
       
        blindfold = GetComponent<Image>();
    }

    public void Enable(bool turnOn)
    {
        StartCoroutine(Loop(transitionTime/255f, turnOn));
    }
    IEnumerator Loop(float delay, bool turnOn)
    {
        Color32 currentColor = blindfold.color;
        if (turnOn)
        {
            for (int i = 0; i < 256; i++)
            {
                currentColor.a = (byte)i;
                blindfold.color = currentColor;
         
                yield return new WaitForSeconds(delay);
            }
        }
        else {
            for (int i = 255; i >= 0; i--)
            {
                currentColor.a = (byte)i;
                blindfold.color = currentColor;
         
                yield return new WaitForSeconds(delay);
            } 
        }
    }
}
