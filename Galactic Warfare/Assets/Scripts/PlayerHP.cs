using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    public static Text scoreLifeText;
    public static int scoreLife = 5;
    
    private float _currentHealth;
    public float _maxHealth;
    
    public int _damageAmount = 5;
    public static int _recoveryAmount = 10;
    
    //Escudo
    public bool _VerificaEscudoPlayer;
    public static bool _VidaDoEscudoPlayer;
    
    private void Start()
    {
        scoreLife = 5;
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        _currentHealth = _maxHealth;
        _VidaDoEscudoPlayer = false;
    }
    
    void Update()
    {
        if (_currentHealth <= 0 )
        {
            _currentHealth = 0;
            Life();
        }
        
        if (_currentHealth > 100)
        {
            _currentHealth = 100;
        }

        _VerificaEscudoPlayer = EscudoPlayer._EscudoAtivado;

        if (_VidaDoEscudoPlayer)
        {
            EscudoPlayer._EscudoLifeAtual -= 0.1f;
        }
        
        Observer.AtualizaVidaPlayer(_currentHealth);
        
        scoreLifeText.text = scoreLife + "X";
        Observer.AtualizarTextoDaVidaPlayer(scoreLifeText.text);
    }

    public void TakeDamage(float damage = -1)
    {
        if (damage < 0)
            damage = _damageAmount;
        
        _currentHealth -= damage;
    }
    
    public void RecoverHealth(float recovery = -1)
    {
        if (recovery < 0)
            recovery = _recoveryAmount;
        
        _currentHealth += recovery;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && EscudoPlayer._EscudoAtivado == false)
        {
            TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && EscudoPlayer._EscudoAtivado == false)
        {
            TakeDamage(10);
        }
        if (col.gameObject.tag == "Laser" && EscudoPlayer._EscudoAtivado == false)
        {
            TakeDamage(10);
            Destroy(col.gameObject);
        }
    }

    public static void Life()
    {
        scoreLife -= 1;

        _recoveryAmount = 100;

        if (scoreLife <= 0)
        {
            //SceneManager.LoadScene("Level1");
            Pause.GameOver();
        }
    }
}
