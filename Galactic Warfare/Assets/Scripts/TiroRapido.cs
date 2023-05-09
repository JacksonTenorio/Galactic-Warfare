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
        Destroy(gameObject, 1.4f);
    }
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * velocidade;
    }
}
