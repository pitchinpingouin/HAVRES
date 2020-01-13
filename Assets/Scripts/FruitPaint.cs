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
            Vector3 contactpt = collision.GetContact(0).point;
            Instantiate(tache, new Vector3(contactpt.x, contactpt.y + 0.11f, contactpt.z), Quaternion.identity);
            
            //tache.transform.position = new Vector3(contactpt.x, contactpt.y + 0.2f, contactpt.z);
            //tache.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //tache.SetActive(true);
        }


    }
}
