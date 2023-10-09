using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public Transform playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Jogar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GUI");
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive).completed += delegate(AsyncOperation operation)
        {
            playerPosition = GameObject.FindWithTag("SpawnPlayer").transform;
            Instantiate(player, playerPosition.position, player.transform.rotation);
        };
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Sair()
    {
        Application.Quit();
        Debug.Log("Sair do jogo");
        DesselecionarButao();
    }
    public void DesselecionarButao()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}