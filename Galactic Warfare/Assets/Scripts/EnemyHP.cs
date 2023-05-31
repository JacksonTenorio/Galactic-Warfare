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

    public int _MaxHP;
    private int _HPAtual;
    private bool _estaVivo;

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        _HPAtual = _MaxHP;
        _estaVivo = true;
    }

    private void Update()
    {
        if (_Enemy1 != null || _Enemy2 != null || _Enemy3 != null)
        {
            _estaVivo = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Escudo._escudoAtivado == false)
        {
            if (col.gameObject.tag == "Bala" && _estaVivo == true)
            {
                _HPAtual -= 1;
                Destroy(col.gameObject);

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
