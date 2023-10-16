using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private PlayerController _playerController;
    
    private int _escudoHPMax = 2;
    private static int _escudoHPAtual;
    
    public static bool _escudoAtivado1;
    public static bool _escudoAtivado2;
    public bool _Escudo1;
    public bool _Escudo2;
    
    private void OnEnable()
    {
        Observer.OnTriggerLaserPlayer += VidaEcudoEDanoLaserPlayer;
        Observer.OnTriggerBalaPlayer += VidaEcudoEDanoBalaPlayer;
    }

    private void OnDisable()
    {
        Observer.OnTriggerLaserPlayer -= VidaEcudoEDanoLaserPlayer;
        Observer.OnTriggerBalaPlayer -= VidaEcudoEDanoBalaPlayer;
    }
    
    private void Start()
    {
        EscudoEnemyIniciar();
    }

    public void EscudoEnemyIniciar()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _escudoHPAtual = _escudoHPMax;
        _escudoAtivado1 = true;
        _escudoAtivado2 = true;
    }

    private void VidaEcudoEDanoLaserPlayer()
    {
        if (_Escudo1 == true)
        {
            if (_escudoAtivado1 == true)
            {
                if (_playerController.tiros == 3)
                {
                    _escudoHPAtual -= 1;
                }
                if (_escudoHPAtual <= 0)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    _escudoAtivado1 = false;
                }
            }
        }
        if (_Escudo2 == true)
        {
            if (_escudoAtivado1 == true)
            {
                
                if (_playerController.tiros == 3)
                {
                    _escudoHPAtual -= 1;
                }

                if (_escudoHPAtual <= 0)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    _escudoAtivado2 = false;
                }
            }
        }
    }
    
    private void VidaEcudoEDanoBalaPlayer()
    {
        if (_Escudo1 == true)
        {
            if (_escudoAtivado1 == true)
            {
                if (_playerController.tiros == 1)
                {
                    _escudoHPAtual -= 1;
                }
                if (_playerController.tiros == 2)
                {
                    _escudoHPAtual -= 2;
                }

                if (_escudoHPAtual <= 0)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    _escudoAtivado1 = false;
                }
            }
        }
        if (_Escudo2 == true)
        {
            if (_escudoAtivado2 == true)
            {
                if (_playerController.tiros == 1)
                {
                    _escudoHPAtual -= 1;
                }
                if (_playerController.tiros == 2)
                {
                    _escudoHPAtual -= 2;
                }

                if (_escudoHPAtual <= 0)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    _escudoAtivado2 = false;
                }
            }
        }
    }
}
