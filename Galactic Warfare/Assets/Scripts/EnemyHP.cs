using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public GameObject _Enemy1;
    public GameObject _Enemy2;
    public GameObject _Enemy3;
    
    private ScoreManager scoreManager;
    private PlayerController _playerController;

    public int _MaxHP;
    private int _HPAtual;
    
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

    private void Update()
    {
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
                if (_playerController.tiros == 3 && _playerController._Tiro3 == true)
                {
                    _HPAtual -= 1;
                }

                if (_HPAtual <= 0)
                {
                    scoreManager.IncreaseScore();
                    _estaVivo = false;
                    Destroy(gameObject);
                }
            }
            if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
            {
                if (_playerController.tiros == 3)
                {
                    _HPAtual -= 1;
                }

                if (_HPAtual <= 0)
                {
                    scoreManager.IncreaseScore();
                    _estaVivo = false;
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
                        Destroy(gameObject);
                    }
                }
                if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
                {
                    if (_playerController.tiros == 3)
                    {
                        _HPAtual -= 1;
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
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
                        Destroy(gameObject);
                    }
                }
                if (col.gameObject.tag == "LaserPlayer" && _estaVivo == true)
                {
                    if (_playerController.tiros == 3)
                    {
                        _HPAtual -= 1;
                    }

                    if (_HPAtual <= 0)
                    {
                        scoreManager.IncreaseScore();
                        _estaVivo = false;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
