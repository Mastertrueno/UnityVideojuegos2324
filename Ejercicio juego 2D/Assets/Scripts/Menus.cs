using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    private float retraso = 0;
    private bool jugar = false;
    public AudioClip selec;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            jugar = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(selec);

        }
        if (jugar)
        {
            retraso += Time.deltaTime;
        }
        if (retraso >= 1.5)
        {
            if (SceneManager.GetActiveScene().name.Equals("Creditos") || SceneManager.GetActiveScene().name.Equals("GameOver"))
            {
                SceneManager.LoadScene("Menu");
                SceneManager.UnloadSceneAsync("Creditos");
                SceneManager.UnloadSceneAsync("GameOver");
            }
            else
            {
                SceneManager.LoadScene("Juego");
                SceneManager.UnloadSceneAsync("Menu");
                
            }
        }
    }
}
