using System.IO;
using UnityEngine;

public class SaveSystem: MonoBehaviour
{
    public static SaveSystem instance;
    [SerializeField]
    private GameProgressData gameData;
    [SerializeField]
    private string fileName;

    private string dataPath;

    void Awake(){
        if (instance == null){
            instance = this;


            dataPath = Application.persistentDataPath +"/"+ fileName; 
            // отримання шляху до файлу збереження, незалежно від ос
            Debug.Log(dataPath);

            Load();
            DontDestroyOnLoad(instance); // робота на всіх сценах
        }
    }

    public void Save(){
        
        string json = JsonUtility.ToJson(gameData); // створює json з публічних змінних аргументу
        Debug.Log(json);
        File.WriteAllText(dataPath, json); 
        // приймає шлях до файлу, та контент файлу. записує контент до файлу за шляхом
    }

    public void Load(){
        string json = File.ReadAllText(dataPath);
        // читає контент файлу за шляхом

        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json,gameData);
        // створює новий об'єкт з json формату певного типу
    }
}
