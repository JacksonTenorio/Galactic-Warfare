using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Vector2 _MisselPosition;
    public GameObject _LaserQueSegue;
    private GameObject _Player;
    private Vector3 _PlayerPosition;
    private Vector2 vec2;

    public float _SpeedFire;
    private float _Timer1;
    private float _Timer2;

    private bool Nvl1;
    private bool Nvl2;
    private bool Nvl3;
    
    // ===== NaveMãe =====
    private Rigidbody2D _Rig;

    public float _Speed;

    // ===== Escudo =====
    public GameObject _Escudo;

    public float _EscudoVidaMax;
    private float _EscudoVidaMin;
    
    // ===== Vida =====
    public Slider _BarraDeVida;

    public float _VidaMax;
    private float _VidaAtual;
    

    // Start is called before the first frame update
    void Start()
    {
        _Rig = GetComponent<Rigidbody2D>();

        Nvl1 = true;
        Nvl2 = false;
        Nvl3 = false;
        
        _Timer1 = 2;
        _Timer2 = 2;

        _VidaAtual = _VidaMax;
        VidaUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerPosition = _Player.transform.position;

        _MisselPosition = _Missel.transform.position;
        
        Move();

        if (Nvl1)
        {
            Laser();
        }
        if (Nvl2)
        {
            Missel();
        }
        if (Nvl3)
        {
            _LaserQueSegue.SetActive(true);
            LaserQueSegue();
        }
        if (!Nvl3)
        {
            _LaserQueSegue.SetActive(false);
        }
        
    }

    public void Move()
    {
        _Rig.velocity = Vector2.right * _Speed;
    }

    public void Laser()
    {
        _Timer1 -= Time.deltaTime;

        if (_Timer1 <= 0)
        {
            // Calcula a direção de bala
            float angle = Random.Range(-90, 91);
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Vector2 direction = rotation * Vector2.left;
            
            // Cria a bala e adicona a velocidade
            GameObject bullet = Instantiate(_Laser, _FirePosition.position, rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * _SpeedFire;

            _Timer1 = 2;
        }
    }

    public void Missel()
    {
        _Timer2 -= Time.deltaTime;
        
        if (_Timer2 <= 0)
        {
            Instantiate(_Missel, _FirePosition2.position, _Missel.transform.rotation);
            Instantiate(_Missel, _FirePosition3.position, _Missel.transform.rotation);
            
            if (_MisselPosition.x >= _PlayerPosition.x)
            {
                _MisselPosition = Vector2.MoveTowards(_MisselPosition, _PlayerPosition, _SpeedFire * Time.deltaTime);
            }
            else
            {
                _Missel.GetComponent<Rigidbody2D>().velocity = Vector2.left * _SpeedFire;
            }

            _Timer2 = 2;
        }
    }

    public void LaserQueSegue()
    {
        vec2 = (_LaserQueSegue.transform.position - _PlayerPosition).normalized;
        float angle = Mathf.Atan2(vec2.y, vec2.x) * Mathf.Rad2Deg;
        _LaserQueSegue.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void VidaUpdate()
    {
        _BarraDeVida.value = _VidaAtual;

        if (_VidaAtual >= 50)
        {
            Nvl1 = true;
            Nvl2 = false;
            Nvl3 = false;
        }
        else if (_VidaAtual >= 25 && _VidaAtual < 50)
        {
            Nvl1 = false;
            Nvl2 = true;
            Nvl3 = false;
        }
        else if (_VidaAtual > 0 && _VidaAtual < 25)
        {
            Nvl1 = false;
            Nvl2 = false;
            Nvl3 = true;
        }
        if (_VidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DanoEnemy(float _Dano = -10)
    {
        _VidaAtual -= _Dano;
        VidaUpdate();
    }
}
