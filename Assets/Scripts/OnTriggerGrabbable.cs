using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGrabbable : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();

    private void OnEnable()
    {
        //Reset the list of collided objects
        if(colliders.Count > 0)
        {
            colliders.Clear();
        }
        

    }

    private void OnTriggerEnter(Collider colliderEncountered)
    {
        //If other is grabbable
        if (colliderEncountered.gameObject.layer == 10)
        {
            //Add it to the list if it 's not already in
            if (!colliders.Contains(colliderEncountered))
            {
                colliders.Add(colliderEncountered);
            }
            Rigidbody rgdb = colliderEncountered.GetComponent<Rigidbody>();
            //Remove Gravity to the object
            rgdb.useGravity = false;
            rgdb.isKinematic = true;



            //Remove collider of the object
            ///rgdb.detectCollisions = false;
        }

    }

    private void OnTriggerExit(Collider colliderExiting)
    {
        //If other is grabbable
        if (colliderExiting.gameObject.layer == 10)
        {
            //Add it to the list if it 's not already in
            if (colliders.Contains(colliderExiting))
            {
                colliders.Remove(colliderExiting);
            
                Rigidbody rgdb = colliderExiting.GetComponent<Rigidbody>();

                //Remove Gravity to the object
                rgdb.useGravity = true;
                rgdb.isKinematic = false;


                //Remove detection of collisions
                ///rgdb.detectCollisions = true;
            }
        }
    }

    private void OnDisable()
    {
        if(colliders.Count > 0)
        {
            //Combine Meshes
        }
    }
}
