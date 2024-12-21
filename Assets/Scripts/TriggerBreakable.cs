using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBreakable : MonoBehaviour
{
    [SerializeField]
    private Breakable breakable;
    private bool isUsed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isUsed)
        {     
         breakable.AllowBreaking(true); 
            isUsed = true;
        }
    }
    public void ResetIsUsed()
    {
        Debug.Log("reset");
        isUsed = false;
    }
}
