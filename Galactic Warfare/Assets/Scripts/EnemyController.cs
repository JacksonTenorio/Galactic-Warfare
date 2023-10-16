using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerHP playerHp;
    
    private Rigidbody2D rig;
    private Transform positionPlayer;
    private GameObject player;
    private Transform positonStop;
    private GameObject stop;

    public float _timer;
    public float _Speed;
    public int _range;
    private int _numero;
    
    static public bool _Start;
    public bool _Enemy1;
    public bool _Enemy2;
    public bool _Enemy3;
    
    private void OnEnable()
    {
        Observer.OnCollisionEnterPlayer += DestroiEnemy1;
        Observer.OnTriggerStart += HabilitarStart;
        Observer.OnTriggerStart += DasabilitarStart;
    }

    private void OnDisable()
    {
        Observer.OnCollisionEnterPlayer -= DestroiEnemy1;
        Observer.OnTriggerStart -= HabilitarStart;
        Observer.OnTriggerStart -= DasabilitarStart;
    }
    
    void Start()
    {
        InvokeRepeating("Timer", 0f, _timer);
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        positionPlayer = player.transform;
        stop = GameObject.FindGameObjectWithTag("Stop");
        positonStop = stop.transform;
        
        playerHp = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (_Enemy1 == true)
        {
            if (player != null)
            {
                if (transform.position.x >= positionPlayer.position.x)
                {
                    if (_numero == 1)
                    {
                        rig.velocity = Vector2.up * _Speed;
                    }
                    if (_numero == 2)
                    {
                        rig.velocity = Vector2.down * _Speed;
                    }

                    if (_numero == 3 || _numero == 4)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, positionPlayer.position, _Speed * Time.deltaTime);
                    }
                }
                else
                {
                    rig.velocity = Vector2.left * _Speed;
                }
            }
            else
            {
                rig.velocity = Vector2.left * _Speed;
            }
        }

        if (_Enemy2 == true)
        {
            if (transform.position.x >= positonStop.position.x)
            {
                if (_numero == 1)
                {
                    rig.velocity = Vector2.left * _Speed;
                }
                if (_numero == 2)
                {
                    rig.velocity = Vector2.up * _Speed;
                }
                if (_numero == 3)
                {
                    rig.velocity = Vector2.down * _Speed;
                }
            }
            else
            {
                rig.velocity = Vector2.left * _Speed;
            }
        }

        if (_Enemy3 == true)
        {
            rig.velocity = Vector2.left * _Speed;
        }
    }

    private void DestroiEnemy1()
    {
        if (_Enemy1)
        {
            Destroy(gameObject);
        }
    }

    private void HabilitarStart()
    {
        _Start = true;
    }

    private void DasabilitarStart()
    {
        _Start = false;
    }

    private void Timer()
    {
        _numero = UnityEngine.Random.Range(1,_range);
    }
}
