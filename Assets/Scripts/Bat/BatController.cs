using System.Collections.Generic;
using UnityEngine;

public abstract class BatController : MonoBehaviour
{
    [SerializeField]
    protected List<Vector3> points;
    private List<Vector3> defaultPoints;
    protected int index;
    [SerializeField]
    private float speed;
    private Vector3 movement;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        foreach (var point in points)
        {
            defaultPoints.Add(point);
        }
    }

    void Update()
    {
        movement = points[index] - transform.position;
        rigidbody2D.velocity = movement.normalized * speed;
        ChangeIndex();
    }

    protected abstract void ChangeIndex();
    public void ChangePointList(List<Vector3> newPoints)
    {
        index = 0;
       points.Clear();
        foreach (var point in newPoints)
        {
            points.Add(point);
        }
    }
    public void DefaultPoints()
    {
        index = 0;
        points.Clear();
        foreach(var point in defaultPoints)
        {
            points.Add(point);
        }
    }
}