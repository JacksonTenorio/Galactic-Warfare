using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{ 
    public void MenuPrincipal()
    {
        GameManager.Instance.MenuPrincipal();
    }
    public void Jogar()
    {
        GameManager.Instance.Jogar();
    }
    public void Creditos()
    {
        GameManager.Instance.Creditos();
    }
    public void Sair()
    {
        GameManager.Instance.Sair();
    }
}
