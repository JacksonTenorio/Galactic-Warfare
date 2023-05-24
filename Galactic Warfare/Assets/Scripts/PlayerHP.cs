using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider _healthBar;
    
    private float _currentHealth;
    public float _maxHealth;
    
    public int _damageAmount = 5;
    public int _recoveryAmount = 10;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    void Update()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            SceneManager.LoadScene("Level1");
        }

        if (_currentHealth > 100)
        {
            _currentHealth = 100;
        }
    }

    public void TakeDamage(float damage = -1)
    {
        if (damage < 0)
            damage = _damageAmount;
        
        _currentHealth -= damage;
        UpdateHealthBar();
    }
    
    public void RecoverHealth(float recovery = -1)
    {
        if (recovery < 0)
            recovery = _recoveryAmount;
        
        _currentHealth += recovery;
        UpdateHealthBar();
    }
    
    void UpdateHealthBar()
    {
        _healthBar.value = _currentHealth;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser")
        {
            TakeDamage(10);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }
}
