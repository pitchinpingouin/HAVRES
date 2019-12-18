using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Arbre;
    [SerializeField]
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
        if(/*havebeentaken && */collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(Arbre, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);

            //Arbre.transform.position = this.transform.position;
            //Arbre.SetActive(true);
        }

      
    }


}
