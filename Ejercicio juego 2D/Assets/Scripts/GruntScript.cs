using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    private float LastShoot;
    public GameObject Bulletprefab;
    private int Health=3;
    private void Update()
    {
        if (John == null)
        {
            return;
        }
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        float distance =Mathf.Abs( John.transform.position.x - transform.position.x);
        if (distance<1.0f && Time.time > LastShoot + 0.25f && John.GetComponent<Johnmovement>().Health>0)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        //Debug.Log("Shoot");
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position + direction * 0.1f;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);
        }
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    public void Hit(int daño)
    {
        Health = Health - daño;
        if (Health < 1)
        {
            Object.Destroy(gameObject);

        }
    }
}
