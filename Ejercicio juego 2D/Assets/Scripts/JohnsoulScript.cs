using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnsoulScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector3 Direction;
    public AudioClip Sound;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Direction = Vector3.up;
        Rigidbody2D.velocity = Direction * Speed;
    }
}
