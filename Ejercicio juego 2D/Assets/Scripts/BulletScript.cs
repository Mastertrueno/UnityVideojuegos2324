using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direction;
    public AudioClip Sound;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Object.Destroy(gameObject);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Johnmovement john = collision.collider.GetComponent<Johnmovement>();
    //    GruntScript grunt = collision.collider.GetComponent<GruntScript>();
    //    if (john != null)
    //    {
    //        john.Hit();
    //    }
    //    if (grunt != null)
    //    {
    //        grunt.Hit();
    //    }
    //    DestroyBullet();
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Johnmovement john = collision.GetComponent<Johnmovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        if (john != null)
        {
            john.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit(1);
        }
        DestroyBullet();
    }
}
