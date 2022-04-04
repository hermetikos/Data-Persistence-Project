using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int HighScore { get; set; }
    public string Name { get; set; }

    [System.Serializable]
    private class SaveDataStruct
    {
        public int score;
        public string name;
    }

    private void Awake() {
        // INIT SINGLETON
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // SET UP SCENE PERSISTANCE 
        DontDestroyOnLoad(gameObject);

        // LOAD SAVE DATA
        LoadData();
    }
    
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Save path: " + path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataStruct data = JsonUtility.FromJson<SaveDataStruct>(json);
            HighScore = data.score;
            Name = data.name;
        }
        else {
            HighScore = 0;
            Name = "";
        }
    }

    public void SaveData()
    {
        SaveDataStruct data = new SaveDataStruct();
        
        data.score = HighScore;
        data.name = Name;

        File.WriteAllText(
            Application.persistentDataPath + "/saveFile.json",
            JsonUtility.ToJson(data)
        );
    }
}
