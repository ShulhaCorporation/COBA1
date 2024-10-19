using System;
using UnityEngine;
public class LanguageSelector : MonoBehaviour {

    public static event Action OnLanguageChanged;
    
    public static void SetLanguage(int id){
        string langCode = "en";

        switch (id)
        {
            case 0:{
                langCode = "en";
                break;
            }
            case 1:{
                langCode = "ua";
                break;
            }
            default: {break;}
        }

        SaveSystem.instance.gameData.languageId = langCode;
        SaveSystem.instance.Save();

        OnLanguageChanged?.Invoke();
       
    }
}