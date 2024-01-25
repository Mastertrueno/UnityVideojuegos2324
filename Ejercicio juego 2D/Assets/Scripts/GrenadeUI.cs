using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeUI : MonoBehaviour
{
    public Sprite grenade3;
    public Sprite grenade2;
    public Sprite grenade1;
    public GameObject John;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = grenade3;
    }

    // Update is called once per frame
    private void Update()
    {
        if (John.GetComponent<Johnmovement>().granadas == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = grenade3;
        }
        if (John.GetComponent<Johnmovement>().granadas == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = grenade2;
        }
        if (John.GetComponent<Johnmovement>().granadas == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = grenade1;
        }
        if (John.GetComponent<Johnmovement>().granadas == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
