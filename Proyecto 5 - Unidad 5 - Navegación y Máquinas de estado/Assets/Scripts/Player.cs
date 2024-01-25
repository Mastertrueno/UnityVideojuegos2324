using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //public Transform routeFather;
    //int indexChildren;
    //Vector3 destination;
    // Start is called before the first frame update
    //void Start()
    //{
    //    destination = routeFather.GetChild(indexChildren).position;
    //    GetComponent<NavMeshAgent>().SetDestination(destination);
    //}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))//v1
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
        //if (Vector3.Distance(transform.position, destination) < 2.5f)
        //{
        //    indexChildren++;
        //    if (indexChildren >= routeFather.childCount)
        //    {
        //        indexChildren = 0;
        //    }
        //    destination = routeFather.GetChild(indexChildren).position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);


        //}
        //if (Vector3.Distance(transform.position, destination) < 2.5f)//v2
        //{
        //    indexChildren++;
        //    if (indexChildren >= routeFather.childCount)
        //    {
        //        indexChildren = 0;
        //    }
        //    destination = routeFather.GetChild(indexChildren).position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);


        //}
        
    }
}
