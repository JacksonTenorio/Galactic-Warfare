using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private bool _IsShooting;

    private Rigidbody2D rig;
    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameControls = new GameControls();
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnAction(InputAction.CallbackContext PlayerAct)
    {
        if (PlayerAct.action.name == _gameControls.GamePlay.Atirar.name)
        {
            //Faz o jogador atirar
            
            //GetButtonDown -> Ativa no momento que o botão é apertado
            //GetButton -> Fica ativo enquanto o botão estiver apertado
            //GetButtonUp -> Ativa na momento que o botão é solto
            
            //started -> Ativa no momento que o botão é apertado
            //canceled -> Ativa no momento que o botão é solto
            
            //performed -> Ativa no momento que o botão é apertado e solto

            if (PlayerAct.started) _IsShooting = true;
            if (PlayerAct.canceled) _IsShooting = false;
        }

        if (PlayerAct.action.name == _gameControls.GamePlay.Movi.name)
        {
            //Faz o jogador se mover
            _moveInput = PlayerAct.ReadValue<Vector2>();
            rig.velocity = _moveInput*3;
        }
    }
}
