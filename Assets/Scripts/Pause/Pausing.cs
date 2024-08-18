using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pausing : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;
   public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;

        SaveSystem.instance.Save();
    }

   public void Unpause()
    {   pause.SetActive(false);
        Time.timeScale = 1f;
    }
}
