using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSequence : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> points;
    private int index;
    [SerializeField]
    private float speed;
    private Vector3 movement;
    private Rigidbody2D rigidbody2D;
    private bool backwards = false;
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
    void ChangeIndex()
    {
        float pointX = points[index].x;
        float pointY = points[index].y;
        if (Mathf.Abs(transform.position.x - pointX) < 0.2 && Mathf.Abs(transform.position.y - pointY) < 0.2) //Замість магнітуди, використовується різниця між Х об'єкта та Х точки і різниця між У об'єкта та У точки. Mathf.Abs() дає модуль різниці, щоб ігнорувати мінуси.

        {
            if (backwards)
            {
                index--;
            }
            else
            {
                index++;
            }
        }
        if (index == points.Count)
        {
            index -= 2;
            backwards = true;
        }
        if (index <= -1)
        {
            index += 2;
            backwards = false;
        }
    }
}


