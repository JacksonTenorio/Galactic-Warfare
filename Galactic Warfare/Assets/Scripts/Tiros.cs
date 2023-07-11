using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiros : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D rig;
    private float velocidade;
    void Start()
    {
        velocidade = 8;
        rig = GetComponent<Rigidbody2D>();
        _playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }
    void FixedUpdate()
    {
        if (_playerController.tiros == 1)
        {
            rig.velocity = Vector2.right * velocidade;
            Destroy(gameObject, 1.5f);
        }
        if (_playerController.tiros == 2)
        {
            rig.velocity = Vector2.right * velocidade;
            Destroy(gameObject, 1.3f);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
