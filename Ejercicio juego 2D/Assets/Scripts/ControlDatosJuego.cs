using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDatosJuego : MonoBehaviour
{
    private bool ganar=false;
    public GameObject John;
   // public bool Ganar { get => ganar; set => ganar = value; }
    private void Awake()
    {
       // int numInstancias = FindObjectsByType<ControlDatosJuego>().Length;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (John.transform.position.x >= 68.3)
        {
            ganar = true;
        }
        if (ganar)
        {
            SceneManager.LoadScene("Creditos");
            SceneManager.UnloadSceneAsync("Juego");
        }
    }
}
