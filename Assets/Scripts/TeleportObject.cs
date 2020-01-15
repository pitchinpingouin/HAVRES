using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    // Start is called before the first frame update
    private OVRInput.Controller activeController;
    public GameObject LeftHand;
    public GameObject RightHand;
    private float prevFlexLeft;
    private float flexLeft;
    private float prevFlexRight;
    private float flexRight;



    void Start()
    {
        prevFlexLeft = 0;
        flexLeft = 0;
        prevFlexRight = 0;
        flexRight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        prevFlexLeft = flexLeft;
        flexLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        prevFlexRight = flexRight;
        flexRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (flexLeft > 0.3f && flexLeft > prevFlexLeft && collision.gameObject.layer == 10)
        {
            // activeController = OVRInput.GetActiveController();
            //if (activeController == OVRInput.Controller.LTrackedRemote)
            //{
            collision.gameObject.transform.position = new Vector3(LeftHand.transform.position.x, LeftHand.transform.position.y, LeftHand.transform.position.z);
            //}
            /*else
            {
                collision.gameObject.transform.position = new Vector3(RightHand.transform.position.x , RightHand.transform.position.y , RightHand.transform.position.z );
            }*/

        }
        if (flexRight > 0.3f && flexRight > prevFlexRight && collision.gameObject.layer == 10)
        {
            // activeController = OVRInput.GetActiveController();
            //if (activeController == OVRInput.Controller.LTrackedRemote)
            //{
            // collision.gameObject.transform.position = new Vector3(LeftHand.transform.position.x, LeftHand.transform.position.y, LeftHand.transform.position.z);
            //}
            //else
            // {
            collision.gameObject.transform.position = new Vector3(RightHand.transform.position.x, RightHand.transform.position.y, RightHand.transform.position.z);
            // }

        }

    }
}