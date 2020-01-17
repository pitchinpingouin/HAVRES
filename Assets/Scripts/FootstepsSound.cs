using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    private float stepLength;

    private float lastCheck;

    float Timer = 0.0f;
    [SerializeField] private AudioClip footstepsSound;

    private AudioSource footstepSource;

    [SerializeField] private CharacterController OVR;
    // Start is called before the first frame update
    void Start()
    {
        stepLength = .3f;
        lastCheck = 0.0f;

        OVR = GetComponent<CharacterController>();
        footstepSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (Mathf.Abs(primaryAxis.y) > 0.2f)
        {
            stepLength = 1.1f - Mathf.Abs(primaryAxis.y) * 2 / 3;
        }
        else if (Mathf.Abs(primaryAxis.x) > 0.2f)
        {
            stepLength = 1.1f - Mathf.Abs(primaryAxis.x) * 2 / 3;
        }
        else
        {
            stepLength = Mathf.Infinity;
        }

        if (Time.time - lastCheck > stepLength)

        {

            lastCheck = Time.time;

            footstepSource.PlayOneShot(footstepsSound);

        }

        /*Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (Mathf.Abs(primaryAxis.x) > 0.3f || Mathf.Abs(primaryAxis.y) > 0.3f)
        {
            if (Timer > 0.6f)
            {
                footstepSource.PlayOneShot(footstepsSound);
                Timer = 0.0f;
            }
            Timer += Time.deltaTime;
        }*/

        /*
        if (OVR.isGrounded == true && OVR.velocity.magnitude > 2.0f)
        {
            if (Timer > 0.3f)
            {
                //AkSoundEngine.PostEvent("Footsteps", gameObject);
                footstepSource.PlayOneShot(footstepsSound);
                Timer = 0.0f;
            }

            Timer += Time.deltaTime;
        }*/
    }
}
