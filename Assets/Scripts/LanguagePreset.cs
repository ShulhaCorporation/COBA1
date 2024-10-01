using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LanguagePreset", menuName = "LanguagePreset", order = 0)]
public class LanguagePreset : ScriptableObject {
    public string CurrentLanguage;

    public Dictionary<string, string> English = new Dictionary<string, string>(){
        {"mainMenu", "Main Menu"}
    };

    public Dictionary<string, string> Ukraian = new Dictionary<string, string>(){
        {"mainMenu", "Головне меню"},
        {"", ""},
        {"", ""},
        {"", ""},
        {"", ""},
        {"", ""},
    };
}