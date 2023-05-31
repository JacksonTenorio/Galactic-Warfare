using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private int _escudoHPMax = 2;
    private int _escudoHPAtual;
    public static bool _escudoAtivado;

    private void Start()
    {
        _escudoHPAtual = _escudoHPMax;
        _escudoAtivado = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bala" && _escudoAtivado == true)
        {
            _escudoHPAtual -= 1;
            Destroy(col.gameObject);
            
            if (_escudoHPAtual <= 0)
            {
                _escudoAtivado = false;
                Destroy(gameObject);
            }
        }
    }
}
