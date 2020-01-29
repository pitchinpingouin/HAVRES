using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class CatFollowBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private bool havebeentaken;
    [SerializeField] private AudioClip catMeowSound;
    private AudioSource catSource;
    private DistanceGrabbable dg;
    private OVRGrabbable ovrdg;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        havebeentaken = false;
        catSource = GetComponent<AudioSource>();
        dg = ball.GetComponent<DistanceGrabbable>();
        ovrdg= ball.GetComponent<OVRGrabbable>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!havebeentaken && (dg.isGrabbed|| ovrdg.isGrabbed) ) //mettre distance grabbable
        {
            transform.LookAt(ball.transform);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            catSource.PlayOneShot(catMeowSound, 1);
            havebeentaken = true;
        }
        float dist = Vector3.Distance(transform.position, ball.transform.position);
        
        if (havebeentaken && !dg.isGrabbed && !ovrdg.isGrabbed ) //mettre distance grabbable
        {
            if (dist > 1f)
            {
                transform.LookAt(ball.transform);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
                anim.Play("walk");
                //Vector3 ballPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.y);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z), .03f);
                //transform.position = new Vector3(transform.position.x, 0, transform.position.y);
            }
            else
            {
                havebeentaken = false;
                anim.Play("idle");
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }


        
    }
    private void OnTriggerEnter(Collider other)
    {
        havebeentaken = false;//permet d'arrêter le chat s'il rencontre un obstacle 
        anim.Play("idle"); 
    }
}
