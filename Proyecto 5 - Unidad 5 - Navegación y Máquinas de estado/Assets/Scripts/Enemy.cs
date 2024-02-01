using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Vector3 min, max, destination;
    public bool playerDetected = false;
    public float playerDistanceDetection;
    Transform player;
    public float visionAngle = 45;
    public float playerAttackDistance;
    // Start is called before the first frame update
    public void RandomDestination()
    {
        destination = new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.y, max.y));
        GetComponent<NavMeshAgent>().SetDestination(destination);
        GetComponent<Animator>().SetFloat("velocity", 2);
    }
    IEnumerator Patrol()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, destination) < 1.5f)
            {
                GetComponent<Animator>().SetFloat("velocity", 0);
                yield return new WaitForSeconds(Random.Range(1f, 3f));
                RandomDestination();
            }
            yield return new WaitForEndOfFrame();
        }
    }
    //IEnumerator Alert()//Por proximidad
    //{
    //    while (true)
    //    {
    //        if (Vector3.Distance(transform.position, player.position) < playerDistanceDetection)
    //        {
    //            StopCoroutine("Patrol");
    //            GetComponent<NavMeshAgent>().SetDestination(player.position);
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }
    //}
    IEnumerator Alert()//Por vision
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.position) < playerDistanceDetection)
            {
                Vector3 vectorplayer = player.position - transform.position;
                if (Vector3.Angle(vectorplayer.normalized, transform.forward) < visionAngle)
                {
                    StopCoroutine("Patrol");
                    StartCoroutine("Attack");
                    //GetComponent<NavMeshAgent>().SetDestination(player.position);
                    break;
                }
                            }
            //else
            //{
            //    StartCoroutine("Patrol");
            //}
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Attack()
    {
        StopCoroutine("Alert");
        while (true)
        {
            if (Vector3.Distance(transform.position, player.position) < playerDistanceDetection)
            {
                StartCoroutine("Patrol");
                StartCoroutine("Alert");
                StopCoroutine("Attack");
            }
            if (Vector3.Distance(transform.position, player.position) < playerAttackDistance)
            {
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                GetComponent<NavMeshAgent>().velocity=Vector3.zero;
                GetComponent<Animator>().SetBool("attack", true);
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(player.position);
                GetComponent<Animator>().SetBool("attack", false);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    private void Start()//por proximidad
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RandomDestination();
        StartCoroutine("Patrol");
        StartCoroutine("Alert");
    }
    private void OnTriggerEnter(Collider other)//forma 1
    {
        playerDetected = true;
        StopCoroutine("Patrol");
        transform.LookAt(other.transform);
        GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
        print("Personaje detectado");
    }
    private void OnTriggerExit(Collider other)//forma 1
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = false;
            print("Personaje fuera de detección");
        }
    }
}
