using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGrabbable : MonoBehaviour
{
    Collider[] objectsCollided;

    private void OnEnable()
    {
        objectsCollided = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            objectsCollided[objectsCollided.Length] = other;
            other.transform.position += Vector3.up;
        }
        
    }

    private void Update()
    {
        if(objectsCollided != null)
        {
            //Combine Meshes
        }
    }
}
