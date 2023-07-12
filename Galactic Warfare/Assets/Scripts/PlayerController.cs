using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
    private int _BalasTiro2;
    private bool _Tiro2;
    
    public GameObject _tiroRapido;
    public GameObject _tiroFguete;
    public GameObject _tiroLaser;
    public Transform _firePoint;

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
        _SpeedPlayer = 4;
        _gameControls = new GameControls();
        rig = GetComponent<Rigidbody2D>();
        
        _IsShooting = false;
        _BalasTiro2 = 50;
        tiros = 1;
    }
    
    //Verifica a cada instante.
    private void Update()
    {
        TiroFoguete();
        TirosOn();
        Contador();
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
            if (tiros > 2)
            {
                tiros = 1;
            }
        }
    }
}
