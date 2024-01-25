using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceLaberynth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.DrawRay(transform.position, transform.right * -1 * 6, Color.red);
        //Debug.DrawRay(transform.position, transform.right * 6, Color.red, 6);
        //Debug.DrawRay(transform.position, transform.forward * -1 * 6, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 6, Color.red);
        Invoke("CheckWalls",5);
    }
    public void CheckWalls()
    {
        //Debug.DrawRay(transform.position, transform.right * -1*6,Color.red);
        //Debug.DrawRay(transform.position, transform.right * 6, Color.red, 6);
        //Debug.DrawRay(transform.position, transform.forward * -1 * 6, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 6, Color.red);
        if (Physics.Raycast(transform.position,transform.right,6))
        {
            Destroy(transform.GetChild(3).gameObject);
        }
        if (Physics.Raycast(transform.position, transform.right*-1, 6))
        {
            Destroy(transform.GetChild(2).gameObject);
        }
        if (Physics.Raycast(transform.position, transform.forward * -1, 6))
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        if (Physics.Raycast(transform.position, transform.forward, 6))
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.right * -1 * 3, Color.red);
        //Debug.DrawRay(transform.position, transform.right * 3, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * -1 * 3, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
    }
}
