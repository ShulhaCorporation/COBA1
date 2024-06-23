using System.Collections.Generic;
using UnityEngine;

public abstract class BatController : MonoBehaviour
{
    [SerializeField]
    protected List<Vector3> points;
    protected int index;
    [SerializeField]
    private float speed;
    private Vector3 movement;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        movement = points[index] - transform.position;
        rigidbody2D.velocity = movement.normalized * speed;
        ChangeIndex();
    }

    protected abstract void ChangeIndex();
}