using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowBall : MonoBehaviour
{
        [SerializeField] private GameObject ball;
        private bool havebeentaken;
    // Start is called before the first frame update
    void Start()
    {
        havebeentaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!havebeentaken && ball.GetComponent<OVRGrabbable>().isGrabbed)
        {
            havebeentaken = true;
        }
        float dist = Vector3.Distance(transform.position, ball.transform.position);
        
        if (havebeentaken && !ball.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (dist > 1.5f)
            {
                GetComponent<Animator>().Play("walk");
                //Vector3 ballPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.y);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z), .03f);
                //transform.position = new Vector3(transform.position.x, 0, transform.position.y);
            }
            else
            {
                GetComponent<Animator>().Play("idle");
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        
        
        transform.LookAt(ball.transform);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
