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
            Debug.Log(dataPath);

            Load();
            DontDestroyOnLoad(instance);
        }
    }

    public void Save(){
        
        string json = JsonUtility.ToJson(gameData);
        Debug.Log(json);
        System.IO.File.WriteAllText(dataPath, json);
    }

    public void Load(){

        string json = File.ReadAllText(dataPath);
        Debug.Log(json);
        gameData = JsonUtility.FromJson<GameProgressData>(json);
    }



    
}
