using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRapido : MonoBehaviour
{
    private Rigidbody2D rig;

    public float velocidade;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * velocidade;
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
