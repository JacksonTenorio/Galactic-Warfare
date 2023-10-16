using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHP.Life();
        }
        
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}