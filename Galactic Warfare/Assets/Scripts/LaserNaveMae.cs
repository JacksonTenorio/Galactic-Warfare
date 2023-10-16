using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNaveMae : MonoBehaviour
{
    private void OnEnable()
    {
        Observer.OnTriggerStayPlayer += DanoParaDar;
    }
    
    private void OnDisable()
    {
        Observer.OnTriggerStayPlayer -= DanoParaDar;
    }

    public void DanoParaDar()
    {
        if (PlayerHP._VerificaEscudoPlayer == false)
        {
            PlayerHP._VidaDoEscudoPlayer = false;
            PlayerHP.TakeDamage(0.5f);
        }
        else if (PlayerHP._VerificaEscudoPlayer)
        {
            PlayerHP._VidaDoEscudoPlayer = true;
        }
    }
}
