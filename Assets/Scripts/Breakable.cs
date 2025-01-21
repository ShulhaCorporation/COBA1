using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    public GameObject platform;
    [SerializeField]
    private Rigidbody2D player;
   private bool allowedBreaking = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && allowedBreaking)
        {
            allowedBreaking = false;
             platform.SetActive(false);
        }
    }
    public void AllowBreaking(bool allowed)
    {
        allowedBreaking = allowed;
        Debug.Log("Allowed");
    }
}
