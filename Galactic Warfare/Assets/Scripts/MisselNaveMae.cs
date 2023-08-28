using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisselNaveMae : MonoBehaviour
{
    private GameObject _Player;
    private Vector3 _PlayerPosition;
    private Rigidbody2D _Rig;
    public float _Speed;
    private float timer;

    private void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();
        timer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Player = GameObject.FindWithTag("Player");
        _PlayerPosition = _Player.transform.position;
        
        // ===== Move O tiro =====
        if (_PlayerPosition.x <= transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, _PlayerPosition, _Speed * Time.deltaTime);
        }
        else
        {
            _Rig.velocity = Vector2.left * _Speed;
        }
        
        // ===== Destroi =====
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
