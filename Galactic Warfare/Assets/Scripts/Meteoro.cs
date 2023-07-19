using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteoro : MonoBehaviour
{
    private ScoreManager scoreManager;
    private PlayerController _playerController;
    private PlayerHP playerHp;

    private Rigidbody2D rig;
    private float speed = 3;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerHp = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotacao();
    }
    private void Rotacao()
    {
        transform.Rotate(Vector3.forward);
    }

    private void Move()
    {
        rig.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bala")
        {
            if (_playerController.tiros == 1 || _playerController.tiros == 2)
            {
                scoreManager.IncreaseScore();
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "LaserPlayer")
        {
            if (_playerController.tiros == 3)
            {
                scoreManager.IncreaseScore();
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerHp.TakeDamage(20f);
        }
    }
}
