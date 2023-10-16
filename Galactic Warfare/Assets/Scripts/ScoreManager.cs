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
    public PlayerController playerController2;

    public Text scoreText;
    private int score;

    //Tiros
    public TextMeshProUGUI scoreTiroFoguete;
    public TextMeshProUGUI scoreTiroLaser;
    
    private void OnEnable()
    {
        Observer.OnPontosPlayer += AdicionarPontos;
    }

    private void OnDisable()
    {
        Observer.OnPontosPlayer -= AdicionarPontos;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        scoreTiroFoguete = GameObject.Find("Bala2").GetComponent<TextMeshProUGUI>();
        scoreTiroLaser = GameObject.Find("Bala3").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Tiros();
    }

    private void AdicionarPontos(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void Tiros()
    {
        scoreTiroFoguete.text = playerController2._BalasTiro2.ToString();
        scoreTiroLaser.text = Mathf.RoundToInt(playerController2._Porcentagemlaser) + "%";
    }
}
