using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    [SerializeField]
    public GameData gameData;
    private string filePath;
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        filePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        Load();
    }

   public void Save()
        {
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(instance.filePath, json);
    }
       

    
    public void Load()
    {   if(instance == null)
        {
      
        }
        if (File.Exists(instance.filePath))
        {
            string json = File.ReadAllText(instance.filePath);
            JsonUtility.FromJsonOverwrite(json, gameData);
        }
  
    }
}
