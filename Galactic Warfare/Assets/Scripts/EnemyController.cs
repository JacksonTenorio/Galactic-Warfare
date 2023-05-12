using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rig;
    private Transform tra;

    public float _Time;
    public float _SpeedLeft;
    private float _SpeedRight = 0.5f;
    private bool _Direction = true;
    public bool _Enemy1 = true;
    private bool _Coroutine;
    private bool _Start;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        Walk();
        MoveEnemy1();
        Vertical();
    }
    private void Move()
    {
        if (_Direction == true && _Enemy1 == false)
        {
            rig.velocity = Vector2.left * _SpeedLeft;
        }
        
        if (_Direction == false && _Enemy1 == false)
        {
            rig.velocity = Vector2.right * _SpeedRight;
        }
    }

    private void MoveEnemy1()
    {
        if (_Enemy1 == true)
        {
            rig.velocity = Vector2.left * _SpeedLeft;
        }
    }

    private void Vertical()
    {
        if (_Coroutine == true && _Enemy1 == true)
        {
            tra.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
        }
        if (_Coroutine == false && _Enemy1 == true)
        {
            tra.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Stop" && _Enemy1 == false)
        {
            _Direction = false;
        }
    }

    private void Walk()
    {
        StartCoroutine("OnWalk");
    }

    IEnumerator OnWalk()
    {
        _Start = false;
        while (_Start == false)
        {
            yield return new WaitForSeconds(_Time);
            _Coroutine = true;
            yield return new WaitForSeconds(_Time);
            _Coroutine = false;
        }
    }
}
