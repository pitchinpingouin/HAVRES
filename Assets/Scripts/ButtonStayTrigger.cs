using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStayTrigger : MonoBehaviour
{
    
    public bool isTrigger;
    private Vector3 posOffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            player.GetComponent<Teleporter>().canTeleport = true;
        }
        else
        {
            player.GetComponent<Teleporter>().canTeleport = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        isTrigger = !isTrigger;
        
    }
    private void OnTriggerStay(Collider other)
    {
        //isTrigger = !isTrigger;
        
    }
    private void OnTriggerExit(Collider other)
    {
        isTrigger = isTrigger;
    }
}
