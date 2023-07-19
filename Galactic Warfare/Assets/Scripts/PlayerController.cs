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
    //Variavez.
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private Rigidbody2D rig;
    private float _SpeedPlayer;

    //Tiros
    private bool _IsShooting;
    public int tiros;
    public int _BalasTiro2;
    public float _Porcentagemlaser;
    private bool _Tiro2;
    public bool _Tiro3;
    
    public GameObject _tiroRapido;
    public GameObject _tiroFguete;
    public GameObject _tiroLaser;
    public Transform _firePoint;
    
    //Seleção de tiro
    public GameObject _Fundo1;
    public GameObject _Fundo2;
    public GameObject _Fundo3;
    
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
        //movimentos
        _SpeedPlayer = 4;
        _gameControls = new GameControls();
        rig = GetComponent<Rigidbody2D>();
        
        //trios
        _IsShooting = false;
        _Tiro3 = false;
        _BalasTiro2 = 50;
        tiros = 1;
        _Porcentagemlaser = 100;

        //seleção dos tiros
        _Fundo1 = GameObject.Find("Fundo1").gameObject;
        _Fundo2 = GameObject.Find("Fundo2").gameObject;
        _Fundo3 = GameObject.Find("Fundo3").gameObject;
        _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
        _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
    }
    
    //Verifica a cada instante.
    private void Update()
    {
        TiroFoguete();
        TirosOn();
        Contador();
        Selecao();
        LaserPlayer();
    }
    
    // Chama a função.
    void TirosOn()
    {
        if (_IsShooting == false && Input.GetKey(KeyCode.Space)) StartCoroutine("Fire");
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
            if (_Tiro2 == true && _IsShooting == false)
            {
                _IsShooting = true;
                Instantiate(_tiroFguete, _firePoint.position, _firePoint.rotation);
                _BalasTiro2 -= 1;
                yield return new WaitForSeconds(0.4f);
                _IsShooting = false;
            }
        }
    }

    void TiroFoguete()
    {
        if (_BalasTiro2 >= 50)
        {
            _BalasTiro2 = 50;
            _Tiro2 = true;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tiros += 1;
            if (tiros > 3)
            {
                tiros = 1;
            }
        }
    }

    void LaserPlayer()
    {
        if (tiros == 3)
        {
            if (_Porcentagemlaser > 0)
            {
                _Tiro3 = true;
                
                if(_IsShooting)
                {
                    _Porcentagemlaser -= Time.deltaTime;
                }
                if (_Porcentagemlaser <= 0)
                {
                    _Porcentagemlaser = 0;
                    _Tiro3 = false;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && _Tiro3)
            {
                _IsShooting = true;
                _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 1);
                _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _IsShooting = false;
                _tiroLaser.GetComponent<SpriteRenderer>().color = new Color(1, 0.130547f, 0 , 0);
                _tiroLaser.GetComponent<CapsuleCollider2D>().enabled = false;
            }
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
    }
}
