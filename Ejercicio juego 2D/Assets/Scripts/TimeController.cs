using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
   // public int min, seg;
    public TMP_Text tiempo;
    public static float restante;
    public static bool enMarcha;
    private void Awake()
    {
        restante = 0;
        enMarcha = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante += Time.deltaTime;
  
                //enMarcha = false;
   
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
    //public static void CargarGameOver()
    //{
    //    Debug.Log("Cambio a la escena Menu");
    //    SceneManager.LoadScene("Game Over");
    //    SceneManager.UnloadSceneAsync("Juego");

    //}
}
