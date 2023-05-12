using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy1;
    [SerializeField] private GameObject _Enemy2;
    [SerializeField] private GameObject _Enemy3;
    [SerializeField] private Transform _Spawn1;
    [SerializeField] private Transform _Spawn2;
    [SerializeField] private Transform _Spawn3;

    private bool _1 = true;
    private bool _2 = true;
    private bool _3 = true;
    
    private Rigidbody2D rig;
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
        
        if (_1 == true)
        {
            _1 = false;
            GameObject enemy1 = Instantiate(_Enemy1, _Spawn2.position, _Spawn2.rotation);
            yield return new WaitForSeconds(5f);
            //_1 = true;
        }
        
        yield return new WaitForSeconds(20f);

        if (_2 == true)
        {
            _2 = false;
            GameObject enemy2 = Instantiate(_Enemy2, _Spawn1.position, _Spawn1.rotation);
            GameObject enemy_2 = Instantiate(_Enemy2, _Spawn3.position, _Spawn3.rotation);
            yield return new WaitForSeconds(10f);
            //_2 = true;
        }
        
        yield return new WaitForSeconds(40f);

        if (_3 == true)
        {
            _3 = false;
            GameObject enemy3 = Instantiate(_Enemy3, _Spawn1.position, _Spawn1.rotation);
            GameObject enemy_3 = Instantiate(_Enemy3, _Spawn3.position, _Spawn3.rotation);
            yield return new WaitForSeconds(15f);
            //3 = true;
        }

        yield return new WaitForSeconds(60f);
        _1 = false;
        _2 = false;
        _3 = false;
    }
}
