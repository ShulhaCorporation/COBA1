using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    private Button[] buttons;
    
    void Start()
    {
        

        buttons = gameObject.GetComponentsInChildren<Button>();

        GameData maxLevel = SaveSystem.instance.gameData;                                         

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i <= maxLevel.levelId) buttons[i].interactable = true;
            if (i > maxLevel.levelId) buttons[i].interactable = false;
        }
        
    }
        
}
