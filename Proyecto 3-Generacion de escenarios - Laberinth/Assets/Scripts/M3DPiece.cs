using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3DPiece : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (Physics.Raycast(transform.position,transform.up))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
