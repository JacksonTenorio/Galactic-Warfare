using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroAleatorio : MonoBehaviour
{
    public GameObject _BulletPrefab;
    public float _FireRate = 2f;
    public float _Speed = 10f;

    private float _FireTimer = 0f; // A timer to control the rate of fire

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
            float angle = Random.Range(-120f, 120f);
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Vector2 direction = rotation * Vector2.right;

            // Cria a bala e adicona a velocidade
            GameObject bullet = Instantiate(_BulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * _Speed;
        }
    }
}
