using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy1;
    [SerializeField] private GameObject _Enemy2;
    [SerializeField] private GameObject _Enemy3;
    [SerializeField] private GameObject _Meteoro;
    [SerializeField] private Transform _Spawn1;
    [SerializeField] private Transform _Spawn2;
    [SerializeField] private Transform _Spawn3;
    
    private Rigidbody2D rig;

    private bool _1 = true;
    private bool _2 = true;
    private bool _3 = true;
    private bool _4 = true;
    
    public float velocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * velocidade;
        Spawn();
    }

    private void Spawn()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        
        if (_4 == true)
        {
            _4 = false;
            GameObject meteoro = Instantiate(_Meteoro, _Spawn2.position, transform.rotation);
            yield return new WaitForSeconds(5f);
            _4 = true;
        }
        
        yield return new WaitForSeconds(20f);
        
        
        if (_1 == true)
        {
            _1 = false;
            GameObject enemy1 = Instantiate(_Enemy1, _Spawn3.position, _Spawn2.rotation);
            yield return new WaitForSeconds(10.2f);
            _1 = true;
        }
        
        yield return new WaitForSeconds(20f);

        if (_2 == true)
        {
            _2 = false;
            GameObject enemy2 = Instantiate(_Enemy2, _Spawn1.position, _Spawn1.rotation);
            //GameObject enemy_2 = Instantiate(_Enemy2, _Spawn3.position, _Spawn3.rotation);
            yield return new WaitForSeconds(20.3f);
            _2 = true;
        }
        
        yield return new WaitForSeconds(20f);
        _4 = false;

        if (_3 == true)
        {
            _3 = false;
            GameObject enemy3 = Instantiate(_Enemy3, _Spawn2.position, _Spawn1.rotation);
            yield return new WaitForSeconds(15.01f);
            _3 = true;
        }

        yield return new WaitForSeconds(30f);
        _1 = false;
        _2 = false;
        _3 = false;
    }
}
