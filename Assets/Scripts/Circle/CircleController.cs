using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Down"){
            Destroy(gameObject);
        }
    }
}
