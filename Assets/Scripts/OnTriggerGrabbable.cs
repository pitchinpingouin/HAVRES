using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGrabbable : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();
    private List<Vector3> massDragAngulardrag = new List<Vector3>();

    public GameObject meshCombinerEmpty;
    private MeshCombiner meshCombinerScript;

    private void OnEnable()
    {
        //Reset the list of collided objects
        if(colliders.Count > 0)
        {
            colliders.Clear();
            massDragAngulardrag.Clear();
        }

    }

    private void OnTriggerEnter(Collider colliderEncountered)
    {
        //If other is grabbable
        if (colliderEncountered.gameObject.layer == 10)
        {
            Rigidbody rgbd = colliderEncountered.GetComponent<Rigidbody>();
            //Add it to the list if it 's not already in
            if (!colliders.Contains(colliderEncountered))
            {
                colliders.Add(colliderEncountered);
                massDragAngulardrag.Add(new Vector3(rgbd.mass, rgbd.drag, rgbd.angularDrag));
            }
            
            //Remove Gravity to the object
            rgbd.useGravity = false;
            rgbd.isKinematic = true;


            rgbd.angularDrag = 9999999f;
            rgbd.drag = 99999999f;

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
                Rigidbody rgdb = colliderExiting.GetComponent<Rigidbody>();
                int index = colliders.IndexOf(colliderExiting);

                //Reset the parameters of the rgbd
                rgdb.mass = massDragAngulardrag[index].x;
                rgdb.drag = massDragAngulardrag[index].y;
                rgdb.angularDrag = massDragAngulardrag[index].z;

                rgdb.useGravity = true;
                rgdb.isKinematic = false;

                //Remove object from lists
                massDragAngulardrag.RemoveAt(index);
                colliders.Remove(colliderExiting);
            }
        }
    }

    private void OnDisable()
    {
        if(colliders.Count > 0)
        {
            GameObject empty = Instantiate(meshCombinerEmpty);
            empty.transform.position = transform.position;
            meshCombinerScript = empty.GetComponent<MeshCombiner>();

            //Set up the mesh combiner
            ///TODO
            ///
            
            //Mettre les objets en enfant de l'empty
            for(int i = 0; i < colliders.Count; i++)
            {
                colliders[i].transform.parent = empty.transform;
            }

            //Combine meshes and add mass
            meshCombinerScript.CombineMeshes(false);
            CalculateTotalMassAndAddRgbd(empty);
            
            //Empty the two lists, and reassign the new rigidbody parameters like gravity
            ///TODO
            ///

            //Sinon, ca sera vidé au Enable donc osef
        }
    }

    private void CalculateTotalMassAndAddRgbd(GameObject emptyGameObject)
    {
        float totalMass = 0.0f;
        //On additionne toutes les masses dans un seul float
        for (int i = 0; i < massDragAngulardrag.Count - 1; i++)
        {
            totalMass += massDragAngulardrag[i].x;
        }

        //Add Rigidbody to the emptyGameObject
        emptyGameObject.AddComponent<Rigidbody>();
        emptyGameObject.GetComponent<Rigidbody>().mass = totalMass;
        
        return;
    }
}
