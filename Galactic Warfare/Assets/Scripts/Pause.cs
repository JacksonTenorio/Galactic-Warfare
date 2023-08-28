using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject painelGameOver;
    public GameObject painelVitoria;

    private bool isGameOver;

    private void Start()
    {
        isGameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            {
                if (painelPause.activeSelf)
                {
                    painelPause.SetActive(false);
                    Time.timeScale = 1;
                    DesselecionarButao();
                }
                else
                {
                    painelPause.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }
    public void VoltarPause()
    {
        if (!isGameOver)
        {
            painelPause.SetActive(false);
            Time.timeScale = 1;
            DesselecionarButao();
        }
    }
    public void DesselecionarButao()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            Time.timeScale = 0;
            isGameOver = true;
            painelGameOver.SetActive(true);
        }
    }
    public void Vitoria()
    {
        if (!isGameOver)
        {
            Time.timeScale = 0;
            isGameOver = true;
            painelVitoria.SetActive(true);
        }
    }
}
