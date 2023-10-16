using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Observer : MonoBehaviour
{
    public static event Action OnPowerUpCollected;
    public static event Action OnCollisionEnterPlayer;
    public static event Action OnCollisionEnterEnemy;
    public static event Action OnTriggerEnterPlayer;
    public static event Action OnTriggerStayPlayer;
    public static event Action OnTriggerEnterEnemy;
    public static event Action OnTriggerStayEnemy;
    public static event Action OnTriggerBalaPlayer;
    public static event Action OnTriggerLaserPlayer;
    public static event Action OnDeathZone;
    public static event Action OnTriggerStart; 
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (OnCollisionEnterPlayer != null)
            {
                OnCollisionEnterPlayer?.Invoke();
            }

            if (OnDeathZone != null)
            {
                OnDeathZone?.Invoke();
            }
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (OnDeathZone != null)
            {
                Destroy(col.gameObject);
                OnDeathZone?.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (OnTriggerEnterPlayer != null)
            {
                OnTriggerEnterPlayer?.Invoke();
            }
            
            if (OnPowerUpCollected != null)
            {
                OnPowerUpCollected?.Invoke();
            }
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (OnTriggerEnterEnemy != null)
            {
                OnTriggerEnterEnemy?.Invoke();
            }
        }
        if (col.gameObject.CompareTag("Bala"))
        {
            if (OnTriggerBalaPlayer != null)
            {
                Destroy(col.gameObject);
                OnTriggerBalaPlayer?.Invoke();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (OnTriggerStayPlayer != null)
            {
                OnTriggerStayPlayer?.Invoke();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (OnTriggerStayEnemy != null)
            {
                OnTriggerStayEnemy?.Invoke();
            }
        }

        if (other.gameObject.CompareTag("LaserPlayer"))
        {
            if (OnTriggerLaserPlayer != null)
            {
                OnTriggerLaserPlayer?.Invoke();
            }
        }
        
        if (other.gameObject.CompareTag("Start"))
        {
            if (OnTriggerStart != null)
            {
                OnTriggerStart?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            if (OnTriggerStart != null)
            {
                OnTriggerStart?.Invoke();
            }
        }
    }
}
