using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveMae : MonoBehaviour
{
    // ===== Tiros =====
    public Transform _FirePosition;
    public Transform _FirePosition2;
    public Transform _FirePosition3;
    
    public GameObject _Laser;
    public GameObject _Missel;
    public GameObject _LaserQueSegue;

    private float _SpeedFire;
    private float _Timer;

    private bool Nvl1;
    private bool Nvl2;
    private bool Nvl3;
    
    // ===== NaveMãe =====
    private Rigidbody2D _Rig;

    public int _Speed;
    
    // ===== Escudo =====
    public GameObject _Escudo;

    public int _EscudoVidaMax;
    private int _EscudoVidaMin;
    
    // ===== Vida =====
    public Slider _BarraDeVida;

    public int _VidaMax;
    private int _VidaMin;
    

    // Start is called before the first frame update
    void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();

        Nvl1 = true;
        Nvl2 = false;
        Nvl3 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _Rig.velocity = Vector2.right * _Speed;
    }

    void Laser()
    {
        
    }

    void Missel()
    {
        
    }

    void LaserQueSegue()
    {
        
    }
}
