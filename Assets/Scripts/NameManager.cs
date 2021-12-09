using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class NameManager : MonoBehaviour
{

    public static NameManager Instance;

    public string currentPlayerName;
    public string lastPlayerName;
    public int highestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        LoadHighestScore();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    [System.Serializable]
    class SaveData
    {
        public int highestScore;
        public string lastPlayerName;
    }

    public void SaveHighestScore()
    {
        SaveData data = new SaveData();
        data.lastPlayerName = currentPlayerName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            highestScore = data.highestScore;
            lastPlayerName = data.lastPlayerName; 
        }
    }

    
}
