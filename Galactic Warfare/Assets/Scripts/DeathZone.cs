using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Invoke("LoadScene", 1f);
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}