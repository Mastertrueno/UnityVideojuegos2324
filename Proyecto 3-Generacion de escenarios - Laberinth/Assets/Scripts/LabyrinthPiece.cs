using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPiece : MonoBehaviour
{
    public int x, z, chance;
    public bool n, s, e, w;
    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 100);
        if (num < chance && z < GeneratorLaberynth.gen.zMax - 1)
        {
            n = true;
        }
        num = Random.Range(0, 100);
        if (num < chance && z > 0)
        {
            s = true;
        }
        num = Random.Range(0, 100);
        if (num < chance && x < GeneratorLaberynth.gen.xMax - 1)
        {
            e = true;
        }
        num = Random.Range(0, 100);
        if (num < chance && x > 0)
        {
            w = true;
        }
        GenerateNeightbours();
        if (z < GeneratorLaberynth.gen.zMax - 1 && GeneratorLaberynth.gen.map[x, z + 1] != null)
        {
            n = true;
        }
        if (z > 0 && GeneratorLaberynth.gen.map[x, z - 1] != null)
        {
            s = true;
        }
        if (x < GeneratorLaberynth.gen.xMax - 1 && GeneratorLaberynth.gen.map[x + 1, z] != null)
        {
            e = true;
        }
        if (x > 0 && GeneratorLaberynth.gen.map[x - 1, z] != null)
        {
            w = true;
        }
        Invoke("CheckWalls",5);
    }
    public void GenerateNeightbours()
    {
        if (n)
        {
            GeneratorLaberynth.gen.GenerateNextPiece(x, z + 1);
        }
        if (s)
        {
            GeneratorLaberynth.gen.GenerateNextPiece(x, z - 1);
        }
        if (e)
        {
            GeneratorLaberynth.gen.GenerateNextPiece(x + 1, z);
        }
        if (w)
        {
            GeneratorLaberynth.gen.GenerateNextPiece(x - 1, z);
        }
    }
    public void CheckWalls()
    {
        //Debug.DrawRay(transform.position, transform.right * -1*6,Color.red);
        //Debug.DrawRay(transform.position, transform.right * 6, Color.red, 6);
        //Debug.DrawRay(transform.position, transform.forward * -1 * 6, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 6, Color.red);
        if (e)
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
        if (w)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
        if (s)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        if (n)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
