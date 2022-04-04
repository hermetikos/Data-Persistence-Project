using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text HighScoreText;
    public InputField NameField;
    
    private int m_HighScore;
    private string m_Name = "";
    void Start()
    {
        // retrieve the high score data from the score manager
        m_HighScore = ScoreManager.Instance.HighScore;
        m_Name = ScoreManager.Instance.Name;

        HighScoreText.text = $"Best Score : {m_HighScore} Name: {m_Name}";
    }

    // Update is called once per frame
    public void LockInput(InputField input)
    {
        ScoreManager.Instance.Name = input.text;
    }
}
