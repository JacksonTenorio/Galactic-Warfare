using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool _Escudo;
    private bool _Direction;
    private float _Cont;
    private float _Speed;
    private float Timer;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _Direction = false;
        _Speed = 1;
        Timer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Destruir();
        
        if (_Direction)
        {
            rig.velocity = Vector2.up * _Speed;
            
            _Cont -= Time.deltaTime;
            
            if (_Cont <= 0)
            {
                _Direction = false;
                _Cont = 0.5f;
            }
        }

        if (!_Direction)
        {
            rig.velocity = Vector2.down * _Speed;
            
            _Cont -= Time.deltaTime;
            
            if (_Cont <= 0)
            {
                _Direction = true;
                _Cont = 0.5f;
            }
        }
    }

    void Destruir()
    {
        Timer -= Time.deltaTime;
        
        if (Timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _Escudo)
        {
            EscudoPlayer._AtivarEscudoPlayer = true;
            Destroy(gameObject);
        }
    }
    
}
