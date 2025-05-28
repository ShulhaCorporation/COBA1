using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{

    [SerializeField]
    private LightController lightController;
    [SerializeField]
    private DoorController doorController;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        lightController.TurnOn();
        doorController.Open();
        Destroy(gameObject);
    }
}
