using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
   private bool isDead = false;

  public void SetIsDead(bool isDead)
    {
        this.isDead = isDead;
    }

    void Update()
    {
        if(isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isDead = false;
        }
    }
}
