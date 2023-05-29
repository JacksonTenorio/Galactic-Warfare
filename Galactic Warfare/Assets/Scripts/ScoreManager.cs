using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    
    public Text scoreLifeText;
    private int scoreLife = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: 0";
        
        scoreLifeText = GameObject.Find("Vidas").GetComponent<Text>();
        scoreLifeText.text = "x5";
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void Life()
    {
        DontDestroyOnLoad(this.gameObject);
        
        scoreLife -= 1;
        scoreLifeText.text = "X" + scoreLife.ToString();

        if (scoreLife <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
