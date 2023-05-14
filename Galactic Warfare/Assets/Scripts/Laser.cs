using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    public bool _laser;
    private bool _fire;
    private bool _if;

    private void Start()
    {
        _if = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_laser == true)
        {
            if (_fire == true)
            {
                transform.Rotate(0,0,+20*Time.deltaTime);
            }
            if (_fire == false)
            {
                transform.Rotate(0,0,-20*Time.deltaTime);
            }
        }

        if (_laser == false)
        {
            if (_fire == true)
            {
                transform.Rotate(0,0,-20*Time.deltaTime);
            }
            if (_fire == false)
            {
                transform.Rotate(0,0,+20*Time.deltaTime);
            }
        }
        
        Angles();

    }

    void Angles()
    {
        StartCoroutine("isAngles");
    }

    IEnumerator isAngles()
    {
        if (_if == true)
        {
            yield return new WaitForSeconds(3);
            _fire = true;
            _if = false;
        }
        
        if (_if == false)
        {
            yield return new WaitForSeconds(3);
            _fire = false;
            _if = true;
        }
    }
}
