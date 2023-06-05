using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private int _escudoHPMax = 2;
    private int _escudoHPAtual;
    
    public static bool _escudoAtivado1;
    public static bool _escudoAtivado2;
    public bool _Escudo1;
    public bool _Escudo2;
    
    private void Start()
    {
        _escudoHPAtual = _escudoHPMax;
        _escudoAtivado1 = true;
        _escudoAtivado2 = true;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_Escudo1 == true)
        {
            if (col.gameObject.tag == "Bala" && _escudoAtivado1 == true)
            {
                _escudoHPAtual -= 1;
                Destroy(col.gameObject);
            
                if (_escudoHPAtual <= 0)
                {
                    _escudoAtivado1 = false;
                    Destroy(gameObject);
                }
            }
        }
        
        if (_Escudo2 == true)
        {
            if (col.gameObject.tag == "Bala" && _escudoAtivado2 == true)
            {
                _escudoHPAtual -= 1;
                Destroy(col.gameObject);
            
                if (_escudoHPAtual <= 0)
                {
                    _escudoAtivado2 = false;
                    Destroy(gameObject);
                }
            }
        }
    }
}
