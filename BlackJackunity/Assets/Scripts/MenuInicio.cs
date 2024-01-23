using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
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
    public static void CargarJugadores()
    {
        Debug.Log("Cambio a la escena Juego");
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("MenuInicio");

    }

    // Cierra el juego
    public void SalirJuego()
    {
        Debug.Log("Cerramos la aplicacion");
        Application.Quit();
    }

}
