using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private PlayerDeath death;
    void Start()
    {
        death = gameObject.GetComponent<PlayerDeath>();
    }
void OnCollisionEnter2D(Collision2D collision2D)
    {  if (collision2D.gameObject.tag == "InstantKill")
        {
            death.SetIsDead(true);
        }
    }
}
