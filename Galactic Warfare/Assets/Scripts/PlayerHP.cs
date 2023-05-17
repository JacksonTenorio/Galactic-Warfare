using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider _BarraDeVida;

    private int _VidaMaxima = 10;
    private int _VidaAtual;

    private bool _Escudo;
    
    // Start is called before the first frame update
    void Start()
    {
        _VidaAtual = _VidaMaxima;
        _BarraDeVida.maxValue = _VidaMaxima;
        _BarraDeVida.value = _VidaAtual;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Damege(int Dano)
    {
        if (_Escudo == false)
        {
            _VidaAtual -= Dano;
            _BarraDeVida.value = _VidaAtual;

            if (_VidaAtual <= 0)
            {
                Debug.Log("Game Over");
            }
        }
        
        
    }
}
