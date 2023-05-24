using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
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

    private void Update()
    {
        if (_maxHealth < 0)
        {
            _maxHealth = 0;
        }

        if (_maxHealth > 100)
        {
            _maxHealth = 100;
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
        _healthBar.value -= (_maxHealth - _currentHealth);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser")
        {
            TakeDamage(1);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(3);
        }
    }
}
