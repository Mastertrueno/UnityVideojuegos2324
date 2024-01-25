using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorBuscaminas : MonoBehaviour
{
    public static GeneratorBuscaminas gen;
    public GameObject piece;
    public GameObject[][] map;

    public int width, height, bombsnumber, numpieces;
    public static int cont = 0;

    private void Start()
    {
        numpieces = width*height-bombsnumber;
        gen = this;
        // bombsnumber = 5;
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<PieceBuscaminas>().x = i;
                map[i][j].GetComponent<PieceBuscaminas>().y = j;
            }
        }
        for (int i = 0; i < bombsnumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<PieceBuscaminas>().bomb)
            {
                map[x][y].GetComponent<PieceBuscaminas>().bomb = true;
            }
            else
            {
                i--;
            }
        }
        //for (int i = 0; i < bombsnumber; i++)
        //{
        //    map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        //}
        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);
    }
    public int GetBombsAround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (y > 0 && map[x][y - 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<PieceBuscaminas>().bomb)
            cont++;
        return cont;
    }
    private void Update()
    {
        if (numpieces == cont)
        {
            SceneManager.LoadScene("Victoria");
            SceneManager.UnloadSceneAsync("Buscaminas");
        }
    }
}
