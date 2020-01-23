using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public GameObject resource;
    private BoxCollider trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
        Generate();
    }

    private void OnTriggerExit(Collider other)
    {
        Generate();

        Rigidbody rgbd = other.GetComponent<Rigidbody>();
        rgbd.isKinematic = false;
        rgbd.useGravity = true;
    }

    private void Generate()
    {
        GameObject instance = Instantiate(resource, transform.position + trigger.center, Quaternion.identity);
        instance.GetComponent<Rigidbody>().isKinematic = true;
    }
}
