using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void OnEnable()
    {
        Observer.OnDeathZone += Destoi;
    }

    private void OnDisable()
    {
        Observer.OnDeathZone -= Destoi;
    }

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    private void Destoi()
    {
        scoreManager.Life();
    }
}