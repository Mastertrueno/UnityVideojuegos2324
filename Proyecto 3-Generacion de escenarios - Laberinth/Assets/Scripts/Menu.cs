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

    // Carga la escena juego
    public static void CargarBuscaminas()
    {
        Debug.Log("Cambio a la escena buscaminas");
        SceneManager.LoadScene("Buscaminas");
        SceneManager.UnloadSceneAsync("Menu");

    }

    public static void CargarMinecraft()
    {
        Debug.Log("Cambio a la escena minecraft");
        SceneManager.LoadScene("Minecraft3D");
        SceneManager.UnloadSceneAsync("Menu");

    }
    public static void CargarLaberinto()
    {
        Debug.Log("Cambio a la escena laberinto");
        SceneManager.LoadScene("Laberinto");
        SceneManager.UnloadSceneAsync("Menu");
    }
    // Cierra el juego
    public void SalirJuego()
    {
        Debug.Log("Cerramos la aplicacion");
        Application.Quit();
    }

}
