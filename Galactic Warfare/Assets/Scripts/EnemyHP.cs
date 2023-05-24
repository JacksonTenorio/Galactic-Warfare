using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public static GameObject _escudo;

    public int _MaxHP;
    public static int _HPAtual;
    public static int _escudoHP = 3;

    private void Start()
    {
        _escudo = GameObject.Find("Escudo");
    }
}
