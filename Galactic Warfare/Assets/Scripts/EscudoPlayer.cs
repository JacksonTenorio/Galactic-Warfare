using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoPlayer : MonoBehaviour
{
    private PlayerController _playerController;

    // ======================== Player ========================
    private float _EscudoLifeMax;
    public static float _EscudoLifeAtual;
    
    public static bool _EscudoAtivado;

    public static bool _AtivarEscudoPlayer;

    private void Start()
    {
        DesativarEscudoPlayer();
    }

    public void DesativarEscudoPlayer()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        _EscudoAtivado = false;
        _AtivarEscudoPlayer = false;
        _EscudoLifeMax = 5;
        _EscudoLifeAtual = _EscudoLifeMax;
    }

    private void Update()
    {
        if (_AtivarEscudoPlayer)
        {
            IniciarEscudoPlayer();
        }
        else
        {
            DesativarEscudoPlayer();
        }
        if (_EscudoLifeAtual <= 0)
        {
            PlayerHP._VidaDoEscudoPlayer = false;
            DesativarEscudoPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser" && _EscudoAtivado)
        {
            _EscudoLifeAtual -= 1;
            Destroy(col.gameObject);

            if (_EscudoLifeAtual <= 0)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                _EscudoAtivado = false;
                _AtivarEscudoPlayer = false;
                _EscudoLifeAtual = _EscudoLifeMax;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && _EscudoAtivado)
        {
            _EscudoLifeAtual -= 1;

            if (_EscudoLifeAtual <= 0)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                _EscudoAtivado = false;
                _AtivarEscudoPlayer = false;
                _EscudoLifeAtual = _EscudoLifeMax;
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "LaserNM" && _EscudoAtivado)
        {
            _EscudoLifeAtual -= 0.5F;

            if (_EscudoLifeAtual <= 0)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                _EscudoAtivado = false;
                _AtivarEscudoPlayer = false;
                _EscudoLifeAtual = _EscudoLifeMax;
            }
        }
    }

    public void IniciarEscudoPlayer()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        _EscudoAtivado = true;
    }
}
