using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPaint : MonoBehaviour
{
    [SerializeField]
    private GameObject tache;
    private bool havebeentaken;
    private int refreshPaint;
   
    // Start is called before the first frame update
    void Start()
    {
        havebeentaken = false;
        refreshPaint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!havebeentaken && (GetComponent<DistanceGrabbable>().isGrabbed || GetComponent<OVRGrabbable>().isGrabbed))
        {
            havebeentaken = true;
        }

        if (refreshPaint < 10)
        {
            refreshPaint += 1;
        }

        int layerMask = 1 << 0;
        RaycastHit hit;
        if (GetComponent<DistanceGrabbable>().isGrabbed || GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (Physics.Raycast(transform.position + new Vector3(0,0,0.35f), transform.TransformDirection(Vector3.forward), out hit, 0.5f,layerMask) && refreshPaint == 10)
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    Vector3 contactpt = hit.point;
                    GameObject stain = Instantiate(tache, new Vector3(contactpt.x, contactpt.y + 0.01f/*-0.15f*//*+ 0.05f*/, contactpt.z), rotation);
                    stain.transform.localScale = tache.transform.localScale * 0.6f;
                    refreshPaint = 0;
                }
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (havebeentaken && collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 contactpt = contact.point;
            Instantiate(tache, new Vector3(contactpt.x, contactpt.y + 0.01f/*-0.15f*//*+ 0.05f*/, contactpt.z), rotation);


           

            //tache.transform.position = new Vector3(contactpt.x, contactpt.y + 0.2f, contactpt.z);
            //tache.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //tache.SetActive(true);
        }


    }


    public bool GetHaveBeenTaken()
    {
        return havebeentaken;
    }
}
