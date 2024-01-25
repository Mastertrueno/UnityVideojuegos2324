using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PieceBuscaminas : MonoBehaviour
{
    public int x, y;
    public bool bomb;
    public Sprite[] sprites;
    public int cont;
    public bool dada = false;

    private void OnMouseDown()
    {
        if (!dada)
        {
            if (bomb)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[9];
                SceneManager.LoadScene("Derrota");
                SceneManager.UnloadSceneAsync("Buscaminas");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[GeneratorBuscaminas.gen.GetBombsAround(x, y)];

                GeneratorBuscaminas.cont++;
            }
            dada = true;
        }
    }
}
