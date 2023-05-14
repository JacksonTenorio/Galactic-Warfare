using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Variavez.
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private bool _IsShooting;
    private Rigidbody2D rig;
    public GameObject _tiroRapido;
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
            rig.velocity = _moveInput*4;
        }
    }
    
    //Quando inicia o level.
    void Start()
    {
        _gameControls = new GameControls();
        rig = GetComponent<Rigidbody2D>();
        _IsShooting = false;
    }
    
    //Verifica a cada instante.
    private void Update()
    {
        Tiro1();

        
    }
    
    // Chama a função.
    void Tiro1()
    {
        StartCoroutine("TiroRapido");
    }
    
    // Faz o jogador atirar.
    IEnumerator TiroRapido()
    {
        if (_IsShooting == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _IsShooting = true;
                GameObject tiroRapido = Instantiate(_tiroRapido, _firePoint.position, _firePoint.rotation);
                yield return new WaitForSeconds(0.4f);
                _IsShooting = false;
            }
        }
        
        
    }
}
