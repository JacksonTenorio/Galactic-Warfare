using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rig;

    public float _SpeedVertical;
    public float _SpeedLeft;
    private float _SpeedRight = 0.5f;
    private bool _Direction;
    public bool _Enemy1;
    private bool _Coroutine;
    private bool _Start = false;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        MoveEnemy1();
        Vertical();
        Walk();
    }
    private void Move()
    {
        if (_Direction == true && _Enemy1 == false)
        {
            rig.velocity = Vector2.left * _SpeedLeft;
        }
        else
        {
            rig.velocity = Vector2.right * _SpeedRight;
        }
    }

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Stop" && _Enemy1 == false)
        {
            _Direction = false;
        }
        else
        {
            _Direction = true;
        }

        if (Collision.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
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
            rig.velocity = Vector2.up * 1;
        }
        if (_Coroutine == false && _Enemy1 == true)
        {
            rig.velocity = Vector2.down * 1;
        }
    }

    private void Walk()
    {
        StartCoroutine("OnWalk");
    }

    IEnumerator OnWalk()
    {
        if (_Start == false)
        {
            _Start = true;
            _Coroutine = true;
            yield return new WaitForSeconds(_SpeedVertical);
            _Coroutine = false;
            _Start = false;
        }
    }
}
