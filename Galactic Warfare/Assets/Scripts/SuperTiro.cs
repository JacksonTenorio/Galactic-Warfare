using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTiro : MonoBehaviour
{
    private float _Timer;
    // Start is called before the first frame update
    void Start()
    {
        _Timer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroi();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }

    private void Destroi()
    {
        _Timer -= Time.deltaTime;

        if (_Timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
