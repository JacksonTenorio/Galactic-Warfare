using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroAleatorio : MonoBehaviour
{
    public Transform _FirePoint;
    public Transform _FirePoint2;
    public GameObject _BulletPrefab;
    
    public float _FireRate = 2f;
    public float _Speed = 10f;
    public bool _Enemy2 = false;
    private float _FireTimer = 0f;

    public float _Range;
    public float _Range2;

    // Update is called once per frame
    void Update()
    {
        // Adiciona o tempo do tiro
        _FireTimer += Time.deltaTime;

        // Verifica se é o tempo de atirar
        if (_FireTimer >= 1f / _FireRate)
        {
            // Reseta o tempo da bala
            _FireTimer = 0f;

            // Calcula a direção de bala
            float angle = Random.Range(_Range, _Range2);
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Vector2 direction = rotation * Vector2.left;

            // Cria a bala e adicona a velocidade
            GameObject bullet = Instantiate(_BulletPrefab, _FirePoint.position, rotation);
            if (_Enemy2 == true)
            {
                GameObject bullet2 = Instantiate(_BulletPrefab, _FirePoint2.position, rotation);
                Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();
                bulletRb2.velocity = direction * _Speed;
            }
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * _Speed;
            Invoke("Destruction", 2f);
        }
    }
    private void Destruction()
    {
        Destroy(GameObject.FindGameObjectWithTag("Laser"));
    }
}
