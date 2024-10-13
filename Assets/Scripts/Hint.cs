using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMesh;
    public byte opacity = 0;

    private Coroutine routine;
    
    private void Start() {
        textMesh.color = new Color(255,255,255,opacity);
    }

    public void Show(){
        if (routine != null) StopCoroutine(routine);

        routine = StartCoroutine(ShowRoutine());
    }
    public void Hide(){
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(HideRoutine());
        
    }

    IEnumerator ShowRoutine(){
        while(opacity < 255)
        {
            Color32 color = textMesh.color;
            color.a = opacity;
            textMesh.color = color;
            opacity++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator HideRoutine(){
        while(opacity > 0)
        {
            Color32 color = textMesh.color;
            color.a = opacity;
            textMesh.color = color;
            opacity--;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
}





