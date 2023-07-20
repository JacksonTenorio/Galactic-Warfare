using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController playerController2;
    public PlayerHP playerHp;
    
    private GameObject _Player;
    public Transform _SpawnPlayer;
    
    public Text scoreText;
    private int score;
    
    public Text scoreLifeText;
    private int scoreLife = 5;
    
    //Tiros
    public TextMeshProUGUI scoreTiroFoguete;
    public TextMeshProUGUI scoreTiroLaser;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("PlayerController").GetComponent<PlayerHP>();

        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: 0";
        
        scoreLifeText = GameObject.Find("Vidas").GetComponent<Text>();
        scoreLifeText.text = "X5";

        scoreTiroFoguete = GameObject.Find("Bala2").GetComponent<TextMeshProUGUI>();
        scoreTiroLaser = GameObject.Find("Bala3").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Player = playerController.GameObject();
        
        playerController2 = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
        Tiros();
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }
    
    public void Life()
    {
        scoreLife -= 1;
        scoreLifeText.text = "X" + scoreLife;
        
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        
        GameObject player = Instantiate(_Player, _SpawnPlayer.position, _Player.transform.rotation);
        playerHp._recoveryAmount = 100;
        playerHp._healthBar.value = playerHp._recoveryAmount;
        
        if (scoreLife <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void Tiros()
    {
        scoreTiroFoguete.text = playerController2._BalasTiro2.ToString();
        scoreTiroLaser.text = Mathf.RoundToInt(playerController2._Porcentagemlaser) + "%";
    }
}
