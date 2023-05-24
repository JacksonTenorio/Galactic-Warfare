using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    public bool _Enemy1;
    public bool _Enemy2;
    public bool _Enemy3;

    public GameObject _escudo;

    public int _MaxHP;
    public static int _HPAtual;
    
    public int _escudoHPMax = 3;
    public int _escudoHPAtual;
    private bool _escudoAtivado;
    
    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        _HPAtual = _MaxHP;
        _escudoHPAtual = _escudoHPMax;
        _escudoAtivado = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_Enemy1 == true && col.gameObject.tag == "Bala")
        {
            _HPAtual -= 1;
            Destroy(col.gameObject);

            if (_HPAtual <= 0)
            {
                Destroy(gameObject);
                scoreManager.IncreaseScore();
            }
        }
        if (_Enemy2 == true && col.gameObject.tag == "Bala")
        {
            _escudo.SetActive(true);
            _escudoAtivado = true;
            
            _escudoHPAtual -= 1;
            Destroy(col.gameObject);

            if (_escudoHPAtual <= 0)
            {
                _escudo.SetActive(false);
                _escudoAtivado = false;
            }
        }
        if (_Enemy2 == true && _escudoAtivado == false && col.gameObject.tag == "Bala")
        {
            _HPAtual -= 1;
            Destroy(col.gameObject);

            if (_HPAtual <= 0)
            {
                Destroy(gameObject);
                scoreManager.IncreaseScore();
            }
        }
        
        if (_Enemy3 == true && col.gameObject.tag == "Bala")
        {
            _escudo.SetActive(true);
            _escudoAtivado = true;
            
            _escudoHPAtual -= 1;
            Destroy(col.gameObject);

            if (_escudoHPAtual <= 0)
            {
                _escudo.SetActive(false);
                _escudoAtivado = false;
            }
        }
        if (_Enemy3 == true && _escudoAtivado == false && col.gameObject.tag == "Bala")
        {
            _HPAtual -= 1;
            Destroy(col.gameObject);

            if (_HPAtual <= 0)
            {
                Destroy(gameObject);
                scoreManager.IncreaseScore();
            }
        }
    }
}
