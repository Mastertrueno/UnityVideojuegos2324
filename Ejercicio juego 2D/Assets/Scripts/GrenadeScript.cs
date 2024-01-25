using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrenadeScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direction;
    public AudioClip Sound;
    public Sprite explosion;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        

    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed* new Vector2(0.01f, Rigidbody2D.velocity.y);
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyGrenade()
    {
        Object.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Johnmovement john = collision.GetComponent<Johnmovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        Tile suelo=collision.GetComponent<Tile>();
       
        if (grunt != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=explosion;
            grunt.Hit(100);
        }
        if (suelo!=null){
            gameObject.GetComponent<SpriteRenderer>().sprite = explosion;

        }

        DestroyGrenade();
    }
}
