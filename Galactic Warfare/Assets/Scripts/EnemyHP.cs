using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHP : MonoBehaviour
{
    //PowerUP
    public GameObject _Raio;
    public GameObject _Municao;
    public GameObject _Escudo;
    private Transform _EnemyAtual;
    
    private int _Chance;

    private bool _Pu;
    
    //Enemy
    
    public GameObject _Enemy1;
    public GameObject _Enemy2;
    public GameObject _Enemy3;
    
    private ScoreManager scoreManager;
    private PlayerController _playerController;

    public float _MaxHP;
    private float _HPAtual;
    
    private bool _estaVivo;
    public bool _1;
    public bool _2;
    public bool _3;

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _HPAtual = _MaxHP;
    }

    private void FixedUpdate()
    {
        PowerUP();
        PowerUpIsOn();
        
        if (_Enemy1 != null)
        {
            _estaVivo = true;
        }
        if (_Enemy2 != null)
        {
            _estaVivo = true;
        }
        if (_Enemy3 != null)
        {
            _estaVivo = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_1 == true)
        {
            if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
            {
                if (_playerController.tiros == 3)
                {
                    _HPAtual -= 0.2f;
                }

                if (_HPAtual <= 0)
                {
                    scoreManager.IncreaseScore();
                    _estaVivo = false;
                    _EnemyAtual = _Enemy1.transform;
                    SpawnerPowerUp();
                    Destroy(gameObject);
                }
            }
        }

        if (_2 == true)
        {
            if (Escudo._escudoAtivado1 == false)
            {
                if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
                {
                    if (_playerController.tiros == 3)
                    {
                        _HPAtual -= 0.2f;
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
                        _EnemyAtual = _Enemy2.transform;
                        SpawnerPowerUp();
                        Destroy(gameObject);
                    }
                }
            }
        }
        
        if (_3 == true)
        {
            if (Escudo._escudoAtivado2 == false)
            {
                if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
                {
                    if (_playerController.tiros == 3)
                    {
                        _HPAtual -= 0.2f;
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
                        _EnemyAtual = _Enemy3.transform;
                        SpawnerPowerUp();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_1 == true)
        {
            if (col.gameObject.tag == "Bala" && _estaVivo == true)
            {
                if (_playerController.tiros == 1)
                {
                    _HPAtual -= 1;
                    Destroy(col.gameObject);
                }
                if (_playerController.tiros == 2)
                {
                    _HPAtual -= 2;
                    Destroy(col.gameObject);
                }
                if (_HPAtual <= 0)
                {
                    scoreManager.IncreaseScore();
                    _estaVivo = false;
                    _EnemyAtual = _Enemy1.transform;
                    SpawnerPowerUp();
                    Destroy(gameObject);
                }
            }
        }

        if (_2 == true)
        {
            if (Escudo._escudoAtivado1 == false)
            {
                if (col.gameObject.tag == "Bala" && _estaVivo == true)
                {
                    if (_playerController.tiros == 1)
                    {
                        _HPAtual -= 1;
                        Destroy(col.gameObject);
                    }
                    if (_playerController.tiros == 2)
                    {
                        _HPAtual -= 2;
                        Destroy(col.gameObject);
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
                        _EnemyAtual = _Enemy2.transform;
                        SpawnerPowerUp();
                        Destroy(gameObject);
                    }
                }
            }
        }
        
        if (_3 == true)
        {
            if (Escudo._escudoAtivado2 == false)
            {
                if (col.gameObject.tag == "Bala" && _estaVivo == true)
                {
                    if (_playerController.tiros == 1)
                    {
                        _HPAtual -= 1;
                        Destroy(col.gameObject);
                    }
                    if (_playerController.tiros == 2)
                    {
                        _HPAtual -= 2;
                        Destroy(col.gameObject);
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
                        _EnemyAtual = _Enemy3.transform;
                        SpawnerPowerUp();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void PowerUP()
    {
        _Chance = Random.Range(1,10);
    }

    public void SpawnerPowerUp()
    {
        if (_Chance == 1 && _Pu)
        {
            Instantiate(_Municao, _EnemyAtual.position, _Municao.transform.rotation);
        }
        if (_Chance == 2 && _Pu)
        {
            Instantiate(_Raio, _EnemyAtual.position, _Raio.transform.rotation);
        }
        if (_Chance == 3 && _Pu)
        {
            Instantiate(_Escudo, _EnemyAtual.position, _Escudo.transform.rotation);
        }
    }

    public void PowerUpIsOn()
    {
        if (_Municao != null || _Raio != null || _Escudo != null)
        {
            _Pu = true;
        }
        else
        {
            _Pu = false;
        }
    }
}
