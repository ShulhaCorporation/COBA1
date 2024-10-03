using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextFinder : MonoBehaviour
{
    [SerializeField]
    private LanguagePreset languageBase;
    [SerializeField]
    private string key;
    private TextMeshProUGUI message;
    void Start()
    {
        message = gameObject.GetComponent<TextMeshProUGUI>();
        switch (languageBase.CurrentLanguage)
        {
            case "en":
                message.SetText(languageBase.English[key]);
                break;
            case "ua":
                message.SetText(languageBase.Ukrainian[key]);
                break;
            default:
                message.SetText(languageBase.English[key]); 
                break;
        }
       
    }
}
