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
        {"tutor1", "Hold A and D to move, \n space to fly" },
        {"tutor2", "You have limited energy to fly \n Restore it before hard obstacles" },
         {"tutor3", "This is a checkpoint \n You will be respawned with full hp if you die after it" },
        {"tutor4", "Press S to fly down fast" }
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
        {"thisLanguage", "Українська"},
         {"tutor1", "Клавіші A, D - рух вліво-вправо \n Пробіл - політ"},
          {"tutor2", "У вас є шкала енергії, що витрачається на політ \n Відновлюйте енергію перед складними перешкодами" },
           {"tutor3", "Ви дійшли до точки збереження \n Ви відродитесь тут після смерті з повним здоров'ям" },
        {"tutor4", "Натисніть S для швидкого ривка вниз" }
    };
    }
