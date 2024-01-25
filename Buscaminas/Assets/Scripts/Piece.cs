using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int x, y;
    public bool bomb;
    public Sprite[] sprites;

    private void OnMouseDown()
    {
        if (bomb)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[9];
            SceneManager.LoadScene("Menu"); 
            SceneManager.UnloadSceneAsync("Buscaminas");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Generator.gen.GetBombsAround(x, y)];

        }
    }
}
