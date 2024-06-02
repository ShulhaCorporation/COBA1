using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    private GameObject ggPanel;
void OnCollisionEnter2D(Collision2D touch)
    {
        if(touch.gameObject.tag == "EndLevel")
        {
            Time.timeScale = 0f;
            ggPanel.SetActive(true);
        }
    }
}
