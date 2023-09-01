using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNaveMae : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHP _PlayerHP = other.gameObject.GetComponent<PlayerHP>();
            PlayerHP _EscudoPlayer = other.gameObject.GetComponent<PlayerHP>();
            
            if (_EscudoPlayer._VerificaEscudoPlayer == false)
            {
                PlayerHP._VidaDoEscudoPlayer = false;
                _PlayerHP.TakeDamage(0.5f);
            }
            else if (_EscudoPlayer._VerificaEscudoPlayer)
            {
                PlayerHP._VidaDoEscudoPlayer = true;
            }
        }
    }
}
