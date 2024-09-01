using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
   private bool isDead = false;
    [SerializeField]
    private GameObject deathPanel;
    [SerializeField]
    private GameObject player;

    public void SetIsDead(bool isDead)
    {
        this.isDead = isDead;
    }

    void Update()
    {
        if(isDead)
        {
            isDead = false;
           deathPanel.SetActive(true);
            player.SetActive(false);
            
        }
    }
  
}
