using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float inactiveTime;
    [SerializeField]
    private GameObject steam;
    void Start()
    {
       StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (true)
        {
            steam.SetActive(false);
            yield return new WaitForSeconds(inactiveTime);
            steam.SetActive(true);
            yield return new WaitForSeconds(activeTime);
        }
    }
}
