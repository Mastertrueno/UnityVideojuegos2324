using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject m3dpiece;
    public int width,height,large;
    public int seed;
    public float detail;
    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(10000,90000);
        generatemap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void generatemap()
    {
        for (int x = 0; x < width; x++) {
            for (int z = 0; z< large; z++)
            {
                height = (int)(Mathf.PerlinNoise(((x / 2) + seed) / detail, ((z / 2) + seed) / detail) * detail);
                for (int y = 0; y < height; y++)
                {
                    Instantiate(m3dpiece, new Vector3(x,y,z),Quaternion.identity);
                }
            }
        }
    }
}
