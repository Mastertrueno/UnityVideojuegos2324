using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrenadeScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private float d = 0.0f;
    private Vector2 Direction;
    public AudioClip Sound;
    public GameObject explosion;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.AddForce(Vector2.up * 50);
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    //private void FixedUpdate()
    //{
    //    //Rigidbody2D.velocity = Direction * Speed;
    //    Rigidbody2D.AddForce(Vector2.up * 15);
    //}
    private void FixedUpdate()
    {

        if (Direction.Equals(Vector3.right))
        {
            d = 1.0f;
        }
        if (Direction.Equals(Vector3.left))
        {
            d = -1.0f;
        }
        
        Rigidbody2D.velocity = new Vector2(d*Speed, Rigidbody2D.velocity.y);
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
        Tilemap suelo = collision.GetComponent<Tilemap>();

        if (grunt != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            grunt.Hit(100);
            d = 0.0f;
        }
        if (suelo != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            d = 0.0f;
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        DestroyGrenade();
    }
}
