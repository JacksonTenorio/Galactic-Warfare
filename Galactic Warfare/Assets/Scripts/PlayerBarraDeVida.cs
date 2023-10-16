using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarraDeVida : MonoBehaviour
 {
     public Slider _healthBar;
     
     public Text scoreLifeText;
 
     private void OnEnable()
     {
         Observer.OnVidaPlayer += UpdateHealthBar;
         Observer.OnTextoDaVidaPlayer += UpdateScoreLife;
     }
 
     private void OnDisable()
     {
         Observer.OnVidaPlayer -= UpdateHealthBar;
         Observer.OnTextoDaVidaPlayer -= UpdateScoreLife;
     }

     public void UpdateHealthBar(float value)
     {
         _healthBar.value = value;
     }
     
     public void UpdateScoreLife(string value)
     {
         scoreLifeText.text = value;
     }
 }
