using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBoost : AResetable, IBooster
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private LifeSystem player;
    public event Action OnBoosterActivation;
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.AddHp(hp);
            particles.Play();
            OnBoosterActivation?.Invoke();
            gameObject.SetActive(false);
        }
    }
    public override void ResetItem()
    {
        gameObject.SetActive(true);
    }

    public void SetPosition(Vector3 position)
    {
         transform.position = position;
    }

    public void SetActive(bool mode)
    {
        gameObject.SetActive(mode);
    }
}
