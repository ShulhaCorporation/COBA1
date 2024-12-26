using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGear : MonoBehaviour
{
    private Coroutine spinning;
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
   public void StartSpinning(bool command)
    {
        if (command)
        {
            spinning = StartCoroutine(Spinning());
        }
        else if (spinning != null)
        {
            StopCoroutine(spinning);
        }
    }
    IEnumerator Spinning()
    {    while (true) {
            rigidbody.angularVelocity = speed;
            yield return new WaitForFixedUpdate();
        }
    }
}
