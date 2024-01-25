using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public int puntuacion = 0;
    public int puntuaciontotal = 0;
    public int valortiempo = 100;
    public static int tiempo = 0;
    public TMP_Text Puntuacion;
    public float restante;
    private void Awake()
    {
        restante = 7;
    }
    // Start is called before the first frame update
    void Start()
    {

        puntuacion = 4000;
        puntuaciontotal = puntuacion + tiempo * valortiempo;
        Puntuacion.text =Convert.ToString(puntuaciontotal);
    }
    private void Update()
    {
        restante -= Time.deltaTime;
        if (restante < 1)
        {
            Menu.CargarFinJuegoV();
        }
    }

    //public static void CargarFinJuego()
    //{
    //    Debug.Log("Cambio a la escena Menu");
    //    SceneManager.LoadScene("Menu");
    //    SceneManager.UnloadSceneAsync("Game Over");

    //}
}
