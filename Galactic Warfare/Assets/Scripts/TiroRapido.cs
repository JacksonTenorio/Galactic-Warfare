using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRapido : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Rigidbody2D rig;

    public float velocidade;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * velocidade;
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            if (EnemyHP._escudoHP > 0)
            {
                EnemyHP._escudoHP -= 1;
                Destroy(gameObject);
            }
            else
            {
                Destroy(EnemyHP._escudo);
                Destroy(gameObject);
            }

            if (EnemyHP._escudo == null)
            {
                Destroy(gameObject);
                if (EnemyHP._HPAtual >0)
                {
                    Destroy(gameObject);
                    EnemyHP._HPAtual -= 1;
                }
                else
                {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                    scoreManager.IncreaseScore();
                }
            }
        }
    }
}
