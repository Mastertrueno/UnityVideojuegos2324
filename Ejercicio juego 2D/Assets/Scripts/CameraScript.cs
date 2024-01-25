using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;

    // Update is called once per frame
    void Update()
    {
        if (John != null)
        {
            Vector3 position = transform.position;
            position.x = John.transform.position.x;
            if (John.transform.position.y>=-0.32 && John.transform.position.y <= 0.24)
            {
                position.y = John.transform.position.y;
            }
            
            transform.position = position;
        }
    }
}
