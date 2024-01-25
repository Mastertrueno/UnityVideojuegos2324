using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void CargarJuego()
    {
        Debug.Log("Cambio a la escena Juego");
        SceneManager.LoadScene("Juego");
        SceneManager.UnloadSceneAsync("Menu");
    }
    public static void CargarFinJuego()
    {
        Debug.Log("Cambio a la escena Menu");
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("Game Over");
    }
    public static void CargarFinJuegoV()
    {
        Debug.Log("Cambio a la escena Menu");
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("Victoria");
    }
    public static void CargarVictoria()
    {
        Debug.Log("Cambio a la escena Victoria");
        SceneManager.LoadScene("Victoria");
        //SceneManager.UnloadSceneAsync("Menu");
    }
}
