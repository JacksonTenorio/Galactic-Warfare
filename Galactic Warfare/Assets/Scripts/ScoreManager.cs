using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: 0";
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }
}
