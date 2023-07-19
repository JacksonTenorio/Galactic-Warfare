using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TiroAleatorio : MonoBehaviour
{
    private PlayerHP playerHp;
    
    public Transform _FirePoint;
    public Transform _FirePoint2;
    public Transform _FirePoint3;
    public Transform _FirePoint4;
    public GameObject _BulletPrefab;
    public GameObject _BulletPrefab2;
    
    public bool _Enemy2 = false;
    public bool _Enemy3 = false;
    private bool _Fire;
    
    public float _FireRate = 2f;
    public float _Speed = 10f;
    private float _FireTimer = 0f;
    public float _Range;
    public float _Range2;
    private int _Chance;

    private void Start()
    {
        InvokeRepeating("Timer", 0, 1);
        
        playerHp = GameObject.Find("PlayerController").GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Chance == 1)
        {
            _Fire = true;
        }
        if(_Chance == 4)
        {
            _Fire = false;
        }
        
        // Adiciona o tempo do tiro
        _FireTimer += Time.deltaTime;

        // Verifica se é o tempo de atirar
        if (_FireTimer >= 1f / _FireRate && EnemyController._Start == true)
        {
            // Reseta o tempo da bala
            _FireTimer = 0f;

            // Calcula a direção de bala
            float angle = Random.Range(_Range, _Range2);
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Quaternion rotation2 = Quaternion.Euler(0f, 0f, 0);
            Vector2 direction = rotation * Vector2.left;

            // Cria a bala e adicona a velocidade
            GameObject bullet = Instantiate(_BulletPrefab, _FirePoint.position, rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * _Speed;

            if (_Enemy2 == true)
            {
                GameObject bullet2 = Instantiate(_BulletPrefab, _FirePoint2.position, rotation);
                Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();
                bulletRb2.velocity = direction * _Speed;
            }
            
            // Cria a bala em linha reta do inimigo 3
            if (_Enemy3 == true && _Fire == true)
            {
                GameObject bullet3 = Instantiate(_BulletPrefab2, _FirePoint3.position, rotation2);
                GameObject bullet4 = Instantiate(_BulletPrefab2, _FirePoint4.position, rotation2);
                Rigidbody2D bulletRb3 = bullet3.GetComponent<Rigidbody2D>();
                Rigidbody2D bulletRb4 = bullet4.GetComponent<Rigidbody2D>();
                bulletRb3.velocity = Vector2.left * _Speed;
                bulletRb4.velocity = Vector2.left * _Speed;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Barreira")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            playerHp.TakeDamage(10);
        }
    }

    // Sorteador
    private void Timer()
    {
        _Chance = Random.Range(1, 5);
    }
}
