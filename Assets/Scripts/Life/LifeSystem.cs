using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField]
    private int hp = 3;
    private PlayerDeath playerDeath;
    public int Hp
    {
        get
        {
            return hp;
        }
    }
    void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();

    }

    public void AddHp(int increment)
    { if (hp + increment <= 3)
        {
            hp += increment;
        }
        if (hp <= 0)
        {
            playerDeath.SetIsDead(true);
        }
    }
    public void SetHp(int value)
    {
        hp = value;
    }
}
