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

    void Update()
    {
        if (hp <= 0)
        {
            playerDeath.SetIsDead(true);
            hp = 3;
        }
    }
    public void AddHp(int increment)
    { 
        hp += increment;
        Debug.Log(hp);
    }
}
