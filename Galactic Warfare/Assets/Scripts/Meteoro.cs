using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteoro : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotacao();
    }
    private void Rotacao()
    {
        transform.Rotate(Vector3.forward);
    }

    private void Move()
    {
        rig.velocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bala")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
