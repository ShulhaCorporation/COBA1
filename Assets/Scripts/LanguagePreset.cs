using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LanguagePreset", menuName = "LanguagePreset", order = 0)]
public class LanguagePreset : ScriptableObject {
    public string CurrentLanguage;

    public Dictionary<string, string> English = new Dictionary<string, string>(){
        {"mainMenu", "Extreme Owl's Travel" },
        {"start", "Play" },
        {"settings", "Settings" },
        {"continue", "Continue" },
        {"exit", "Exit" },
        {"levelComplete", "Level complete!" },
        {"death", "You died!" },
        {"tryAgain", "Try again" },
        {"thisLanguage", "English" },
    };

    public Dictionary<string, string> Ukrainian = new Dictionary<string, string>(){
        {"mainMenu", "Екстремальний політ"},
        {"start", "Почати гру"},
        {"settings", "Налаштування"},
        {"continue", "Продовжити"},
        {"exit", "Вийти"},
        {"levelComplete", "Рівень завершено!"},
        {"death", "Поразка!"},
        {"tryAgain", "Спробувати знову"},
        {"thisLanguage", "Українська"}
    };
}