using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Scripts
    
    //Variavez.
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private Rigidbody2D rig;
    private float _SpeedPlayer;

    //Tiros
    public static bool _IsShooting;
    public int tiros;
    public static int tirosNM;
    public float _BalasTiro2;
    public float _Porcentagemlaser;
    public bool _Tiro2;
    public bool _Tiro3;
    
    public GameObject _tiroRapido;
    public GameObject _tiroFguete;
    public GameObject _tiroLaser;
    public GameObject _SuperTiroObj;
    public Transform _firePoint;
    
    //Seleção de tiro
    public GameObject _Fundo1;
    public GameObject _Fundo2;
    public GameObject _Fundo3;
    
    //Power Ups
    public static bool _Municao;
    public static bool _Raio;
    public static bool _SuperTiro;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }
    
    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }
    
    private void OnAction(InputAction.CallbackContext PlayerAct)
    {
        //Faz o jogador se movimentar.
        if (PlayerAct.action.name == _gameControls.GamePlay.Movi.name)
        {
            //Faz o jogador se movimentar.
            _moveInput = PlayerAct.ReadValue<Vector2>();
            rig.velocity = _moveInput*_SpeedPlayer;
        }
    }
    
    //Quando inicia o level.
    void Start()
    {
        //PowerUps
        _Municao = false;
        _Raio = false;
        
        //movimentos
        _SpeedPlayer = 4;
        _gameControls = new GameControls();
        rig = GetComponent<Rigidbody2D>();
        
        //trios
        _IsShooting = false;
        _Tiro3 = false;
        _BalasTiro2 = 0;
        tiros = 1;
        _Porcentagemlaser = 0;
        _SuperTiro = false;

        //seleção dos tiros
        _Fundo1 = GameObject.Find("Fundo1").gameObject;
        _Fundo2 = GameObject.Find("Fundo2").gameObject;
        _Fundo3 = GameObject.Find("Fundo3").gameObject;
        _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
        _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
    }
    
    //Verifica a cada instante.
    public void Update()
    {
        TiroFoguete();
        TirosOn();
        Contador();
        Selecao();
        LaserPlayer();

        tirosNM = tiros;
    }
    
    // Chama a função.
    void TirosOn()
    {
        if (_IsShooting == false && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("Fire");
        }
    }
    
    // Faz o jogador atirar.
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator Fire()
    {
        if (tiros == 1 && _IsShooting == false)
        {
            _IsShooting = true;
            Instantiate(_tiroRapido, _firePoint.position, _firePoint.rotation);
            yield return new WaitForSeconds(0.4f);
            _IsShooting = false;
        }

        if (tiros == 2)
        {
            if (_Tiro2 && _IsShooting == false)
            {
                _IsShooting = true;
                Instantiate(_tiroFguete, _firePoint.position, _firePoint.rotation);
                _BalasTiro2 -= 1.0f;
                yield return new WaitForSeconds(0.4f);
                _IsShooting = false;
            }
        }
        if (tiros == 4 && _IsShooting == false)
        {
            _IsShooting = true;
            Instantiate(_SuperTiroObj, _firePoint.position, _firePoint.rotation);
            _IsShooting = false;
            _SuperTiro = false;
            tiros = 1;
        }
    }

    void TiroFoguete()
    {
        if (_Municao)
        {
            _BalasTiro2 = 50;
            _Municao = false;
        }
        if (_BalasTiro2 > 0 && _BalasTiro2 <= 50)
        {
            _Tiro2 = true;
        }
        if (_BalasTiro2 <= 0)
        {
            _BalasTiro2 = 0;
            _Tiro2 = false;
        }
    }
    void Contador()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !_SuperTiro)
        {
            tiros += 1;
            if (tiros > 3)
            {
                tiros = 1;
            }
        }

        if (_SuperTiro)
        {
            tiros = 4;
        }
    }

    void LaserPlayer()
    {
        if (_Raio)
        {
            _Porcentagemlaser = 100;
            _Raio = false;
        }
        if (tiros == 3)
        {
            if (_Porcentagemlaser > 0)
            {
                _Tiro3 = true;
                
                if(_IsShooting)
                {
                    _Porcentagemlaser -= (Time.deltaTime + 0.1f);
                }
                if (_Porcentagemlaser <= 0)
                {
                    _Porcentagemlaser = 0;
                    _Tiro3 = false;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && _Tiro3)
            {
                if (_Porcentagemlaser > 0)
                {
                    _IsShooting = true;
                    _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 1);
                    _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = true;
                }
                if (_Porcentagemlaser <= 0)
                {
                    _Porcentagemlaser = 0;
                    _IsShooting = false;
                    _Tiro3 = false;
                    _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
                    _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space) && _Tiro3)
            {
                _IsShooting = false;
                _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
                _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
        else
        {
            _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
            _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    void Selecao()
    {
        if (tiros == 1)
        {
            _Fundo1.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0.1960784f);
            _Fundo2.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
            _Fundo3.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
        }
        if (tiros == 2)
        {
            _Fundo1.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
            _Fundo2.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0.1960784f);
            _Fundo3.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
        }
        if (tiros == 3)
        {
            _Fundo1.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
            _Fundo2.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
            _Fundo3.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0.1960784f);
        }
        if (tiros == 4)
        {
            _Fundo1.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0.1960784f);
            _Fundo2.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
            _Fundo3.GetComponent<Image>().color = new Color(1, 0.952381f, 0, 0);
        }
    }
}
