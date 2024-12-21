using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    [SerializeField]
    private int id;
    private Animator animation;
    public event Action<Vector3, int> OnCheckpointEntered;
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"){
            OnCheckpointEntered(this.transform.position, id);
            animation.SetTrigger("Activated");
        }
    }
}
