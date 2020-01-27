using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class lets you generate ressources on demand while playing
 * Preconditions :
 *  - attached to a GameObject in the scene 
 *  (preferably something evocating a source from which you can get the ressources from, like a mine for stones, a river for fish...)
 *  - the GameObject it is attached to must have a Collider attached, and the Collider should be a trigger
 *  - the list of possible prefabs it can instantiate must be set up
 * Postconditions :
 *  - a prefab is instantiated in the center of the Collider
 *  - while the resource stays in the Collider, it is unaffected by physics
 *  - when the player grabs the resource and makes it exit the Collider, a new resource is instantiated, and the previous resource is now affected again by physics
 */
public class ResourceGenerator : MonoBehaviour
{
    public List<GameObject> resources;
    private Collider trigger;
    private GameObject instance;
    
    void Start()
    {
        if (resources.Count == 0) Debug.LogError("No resource set in resource generator ! Check all resource generators in scene");
        Random.InitState((int) System.DateTimeOffset.Now.ToUnixTimeSeconds()); // we use time since Epoch as a seed for the RNG
        trigger = GetComponent<BoxCollider>();
        Generate(); // we need at least one item to be grabbable in order to detect when the player grabs it
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ladies and gentlemen");
        if (other.gameObject == instance)
        {
            Debug.Log("we got 'im");
            
            // Re-enable physics
            Rigidbody rgbd = instance.GetComponent<Rigidbody>();
            rgbd.isKinematic = false;
            rgbd.useGravity = true;

            instance = null;

            Generate();
        }
    }

    private void Generate()
    {
        int index = (resources.Count > 1) ? (int)(Random.value * (resources.Count - 1)) : 0; // if there is only one resource variant, no need to ask Random
        if (instance != null) return;
        /* TODO : use a factory instead of instantiating every time */
        instance = Instantiate(resources[index], trigger.bounds.center, Quaternion.identity);
        // Disable physics
        Rigidbody rgbd = instance.GetComponent<Rigidbody>();
        rgbd.isKinematic = true;
        rgbd.useGravity = false;
    }
}
