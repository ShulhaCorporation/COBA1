using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private float targetY;
    [SerializeField] 
    private float speed;
    [SerializeField]
    private SpinGear gear;
    private Rigidbody2D rigidbody;
    public event Action OnDoorOpen;
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();         
    }

  public void Open()
    {
        StartCoroutine(OpenDoor());
    }  
    IEnumerator OpenDoor()
    {
        while (transform.position.y < targetY)
        {
            rigidbody.velocity = Vector3.up * speed;
            yield return new WaitForEndOfFrame();
        }
        OnDoorOpen?.Invoke();
        gear.StartSpinning(false);
    }
}
