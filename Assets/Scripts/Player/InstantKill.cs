using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private LifeSystem death;
    void Start()
    {
        death = gameObject.GetComponent<LifeSystem>();
    }
void OnCollisionEnter2D(Collision2D collision2D)
    {  if (collision2D.gameObject.tag == "InstantKill")
        {
            death.AddHp(-3);
        }
    }
}
