using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Arbre;
    private bool havebeentaken;
  

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
        if(havebeentaken && collision.gameObject.CompareTag("Ground"))
        {
            //this.gameObject.SetActive(false);
            Vector3 contactpt = collision.GetContact(0).point;
            Instantiate(Arbre, new Vector3(contactpt.x, contactpt.y, contactpt.z), Quaternion.identity);
            Destroy(gameObject);
            //Arbre.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, this.transform.position.z);
            //Arbre.SetActive(true);
        }

      
    }


}
