using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Johnmovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float JumpForce;
    public float Speed;
    private bool onGound;
    private Animator Animator;
    public GameObject Bulletprefab, Johnsoul,Grenadeprefab;
    private float LastShoot;
    private float LastGrenade;
    public int Health = 4;
    public AudioClip HitSound;
    public AudioClip JumpSound;
    public AudioClip deathmusic;
    private int contdead = 0;
    public Canvas Canvas;
    private HUDScript hud;
    private float retraso;
    public int granadas=3;
    //ICommand jumpCommand=new JumpCommand(john);

    void Start()
    {
        hud = Canvas.GetComponent<HUDScript>();
        hud.setVidastxt(Health);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Animator.SetBool("Dead", false);
    }
    // Update is called once per frame
    void Update()
    {
        hud.setVidastxt(Health);
        if (Health > 0)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            if (Horizontal < 0.0f)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            else if (Horizontal > 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            Animator.SetBool("Running", Horizontal != 0.0f);
            if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
            {
                onGound = true;
            }
            else
            {
                onGound = false;
            }
            Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            if (Input.GetKeyDown(KeyCode.W) && onGound)
            {
                //Jump();
                //JumpCommand.Execute() ;
            }
            if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.G) && Time.time > LastGrenade + 0.75f && granadas>0)
            {
                granadas--;
                Grenade();
                LastGrenade = Time.time;
            }
        }
        else
        {
            Animator.SetBool("Running", false);
            Horizontal = 0.0f;
            retraso += Time.deltaTime;
            if (retraso > 3)
            {
                SceneManager.LoadScene("GameOver");
                SceneManager.UnloadSceneAsync("Juego");
            }
        }
        if (gameObject.transform.position.y < -1.3)
        {
            Health = 0;
            if (contdead < 1)
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(deathmusic);
                contdead++;
            }
        }
        
    }
    public static void Jump(Rigidbody2D Rigidbody2D, int JumpForce, AudioClip JumpSound)
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    public static void Shoot()
    {
        //Vector3 direction;
        //if (transform.localScale.x == 1.0f)
        //{
        //    direction = Vector3.right;
        //}
        //else
        //{
        //    direction = Vector3.left;
        //}
        //GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        //if (bullet != null )
        //{
        //    bullet.transform.position = transform.position + direction * 0.1f;
        //    bullet.transform.rotation = Quaternion.identity;
        //    bullet.SetActive(true);
        //}
        //bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    //private void Jump()
    //{
    //    Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
    //    Rigidbody2D.AddForce(Vector2.up * JumpForce);
    //}

    //private void Shoot()
    //{
    //    Vector3 direction;
    //    if (transform.localScale.x == 1.0f)
    //    {
    //        direction = Vector3.right;
    //    }
    //    else
    //    {
    //        direction = Vector3.left;
    //    }
    //    GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
    //    if (bullet != null)
    //    {
    //        bullet.transform.position = transform.position + direction * 0.1f;
    //        bullet.transform.rotation = Quaternion.identity;
    //        bullet.SetActive(true);
    //    }
    //    bullet.GetComponent<BulletScript>().SetDirection(direction);
    //}
    private void Grenade()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        GameObject grenade = Instantiate(Grenadeprefab, transform.position + direction * 0.2f, Quaternion.identity);
        grenade.GetComponent<GrenadeScript>().SetDirection(direction);
    }
    public void Hit()
    {
        if (Health > 0)
        {
            Health = Health - 1;
        }

        Camera.main.GetComponent<AudioSource>().PlayOneShot(HitSound);
        if (Health < 1)
        {
            Animator.SetBool("Dead", true);
            //Object.Destroy(gameObject);
            //gameObject.SetActive(false);

            //Object.Destroy(gameObject.GetComponent<Collider2D>());
            if (contdead < 1)
            {
                Instantiate(Johnsoul, transform.position, Quaternion.identity);
                contdead++;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(deathmusic);
            }

        }
    }
}
