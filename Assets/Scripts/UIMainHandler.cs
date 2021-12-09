using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMainHandler : MonoBehaviour
{

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI placeholderText;



    // Start is called before the first frame update
    void Start()
    {
        
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            bestScoreText.text = "Best Score: " + NameManager.Instance.lastPlayerName + ": " + NameManager.Instance.highestScore;
            placeholderText.text = NameManager.Instance.lastPlayerName;
            // NameManager.Instance.currentPlayerName = NameManager.Instance.lastPlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            NameManager.Instance.currentPlayerName = playerName.text;
      
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (NameManager.Instance != null && NameManager.Instance.currentPlayerName != NameManager.Instance.lastPlayerName)
        {
            NameManager.Instance.highestScore = 0;
        }
    }

    public void Exit()
    {
        NameManager.Instance.SaveHighestScoreFromStartMenu();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
