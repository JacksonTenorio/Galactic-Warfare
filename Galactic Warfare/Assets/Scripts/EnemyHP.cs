using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float _MaxHP;
    [SerializeField] private int _Damege;
    
    private float _HPAtual;

    // Update is called once per frame
    void FixedUpdate()
    {
        _MaxHP = _MaxHP - _HPAtual;
    }
}
