using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLaberynth : MonoBehaviour
{
    public int zMax, xMax;
    public GameObject piece;
    public GameObject[,] map;
    public int limit;
    public static GeneratorLaberynth gen;

    // Start is called before the first frame update
    void Start()
    {
        gen = this;
        map = new GameObject[xMax, zMax];
        //StartCoroutine(GenMapBasic());
        //StartCoroutine(GenMapMedium(0, 0));
        GenerateFirstFloor();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GenMapBasic()
    {
        for (int x = 0; x < xMax; x++)
        {
            for (int z = 0; z < zMax; z++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    Instantiate(piece, new Vector3(x * 5, 0, z * 5), Quaternion.identity);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    public IEnumerator GenMapMedium(int x, int z)
    {
        limit--;
        Transform newpiece = Instantiate(piece, new Vector3(x, 0, z), Quaternion.identity).transform;
        yield return new WaitForEndOfFrame();

        if (limit > 0)
        {
            int num = Random.Range(0, 100);
            if (num < 25 && !Physics.Raycast(newpiece.position, newpiece.forward, 3))
            {
                StartCoroutine(GenMapMedium(x, z + 5));
            }
            else if (num < 50 && !Physics.Raycast(newpiece.position, newpiece.forward * -1, 3))
            {
                StartCoroutine(GenMapMedium(x, z - 5));
            }
            else if (num < 75 && !Physics.Raycast(newpiece.position, newpiece.right, 3))
            {
                StartCoroutine(GenMapMedium(x + 5, z));
            }
            else if (num <= 100 && !Physics.Raycast(newpiece.position, newpiece.right * -1, 3))
            {
                StartCoroutine(GenMapMedium(x - 5, z));
            }
        }
    }
    public void GenerateFirstFloor()
    {
        LabyrinthPiece NewPiece = Instantiate(piece, new Vector3((xMax / 2) * 5, 0, (zMax / 2) * 5), Quaternion.identity).GetComponent<LabyrinthPiece>();
        NewPiece.n = true; NewPiece.s = true; NewPiece.e = true; NewPiece.w = true;
        NewPiece.x = xMax / 2; 
        NewPiece.z = zMax / 2;
        map[xMax / 2, zMax / 2] = NewPiece.gameObject;
    }
    public void GenerateNextPiece(int x, int z)
    {
        if (map[x, z] == null)
        {
            LabyrinthPiece NewPiece = Instantiate(piece, new Vector3(x * 5, 0, z * 5), Quaternion.identity).GetComponent<LabyrinthPiece>();
            NewPiece.x = x; NewPiece.z = z;
            map[x, z] = NewPiece.gameObject;
        }
    }

}
