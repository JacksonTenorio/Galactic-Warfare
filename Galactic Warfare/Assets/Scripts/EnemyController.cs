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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            if (_Enemy1)
            {
                Destroy(gameObject);
            }
            if (PlayerController.tirosNM == 3 && PlayerController._IsShooting)
            {
                playerHp.RecoverHealth();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            _Start = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (PlayerController.tirosNM == 3 && PlayerController._IsShooting)
        {
            playerHp.RecoverHealth();
        }
        if (col.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            _Start = true;
        }
    }

    private void Timer()
    {
        _numero = UnityEngine.Random.Range(1,_range);
    }
}
