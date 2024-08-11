using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    private Button[] buttons;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        buttons = gameObject.GetComponentsInChildren<Button>();

        int maxLevel = PlayerPrefs.GetInt("maxLevel");

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i <= maxLevel) buttons[i].interactable = true;
            if (i > maxLevel) buttons[i].interactable = false;
        }
        
    }
        
}
