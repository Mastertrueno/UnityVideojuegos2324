using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaScript : MonoBehaviour
{
    public Sprite vidaVerde;
    public Sprite vidaVerde2;
    public Sprite vidaRoja;
    public Sprite vidaNaranja;
    public GameObject John;
    public int contvidas = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (John.GetComponent<Johnmovement>().Health==4)
        {
           gameObject.GetComponent<SpriteRenderer>().sprite= vidaVerde;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (John.GetComponent<Johnmovement>().Health == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = vidaVerde;
        }
        if (John.GetComponent<Johnmovement>().Health == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = vidaVerde2;
        }
        if (John.GetComponent<Johnmovement>().Health == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = vidaNaranja;
        }
        if (John.GetComponent<Johnmovement>().Health == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = vidaRoja;
        }
        if (John.GetComponent<Johnmovement>().Health == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
