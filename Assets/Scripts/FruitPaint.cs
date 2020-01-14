using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPaint : MonoBehaviour
{
    [SerializeField]
    private GameObject tache;
    private bool havebeentaken;
    // Start is called before the first frame update
    void Start()
    {
        havebeentaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!havebeentaken && GetComponent<OVRGrabbable>().isGrabbed)
        {
            havebeentaken = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (havebeentaken && collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 contactpt = contact.point;
            Instantiate(tache, new Vector3(contactpt.x, contactpt.y+0.01f/*+ 0.05f*/, contactpt.z), rotation);


           

            //tache.transform.position = new Vector3(contactpt.x, contactpt.y + 0.2f, contactpt.z);
            //tache.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //tache.SetActive(true);
        }


    }
}
