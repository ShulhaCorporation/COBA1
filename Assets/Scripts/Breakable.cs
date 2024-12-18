using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private float strenght;
    [SerializeField]
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(player.velocity.y);
        if (collision.gameObject.CompareTag("Player") && player.velocity.y > strenght)
        {   
           
           platform.SetActive(false);
        }
    }

}
