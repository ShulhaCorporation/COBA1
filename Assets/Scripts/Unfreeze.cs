using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfreeze : MonoBehaviour
{
    [SerializeField]
    private GameObject ggPanel;
    public void Update()
    {
        Time.timeScale = 1f;
        ggPanel.SetActive(false);
    }
}
