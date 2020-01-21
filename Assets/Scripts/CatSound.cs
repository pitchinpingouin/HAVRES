using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSound : MonoBehaviour
{

    [SerializeField] private AudioClip catMeowSound;

    //[SerializeField] private AudioClip catRonronSound;

    private AudioSource catSource;

    // Start is called before the first frame update
    void Start()
    {
        catSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("LeftHand"))
        {
            //catSource.clip = catRonronSound;
            //catSource.Play();
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.LTouch);
            catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catMeowSound, OVRInput.Controller.LTouch);
            TriggerVibration(catMeowSound, 0);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //catSource.clip = catRonronSound;
            //catSource.Play();
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.RTouch);
            catSource.PlayOneShot(catMeowSound, 1);

            TriggerVibration(catMeowSound, 1);
        }
    }
    /*
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("LeftHand"))
        {

            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catRonronSound, OVRInput.Controller.LTouch);
            catSource.PlayOneShot(catMeowSound, 1);
            TriggerVibration(catMeowSound, OVRInput.Controller.LTouch);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);

            //TriggerVibration(catRonronSound, OVRInput.Controller.RTouch);
            catSource.PlayOneShot(catMeowSound, 1);

            TriggerVibration(catMeowSound, OVRInput.Controller.RTouch);
        }
    }*/
    /*
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("LeftHand"))
        {
            //catSource.Stop();
            //OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //catSource.Stop();
            //OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }*/

    public void TriggerVibration(AudioClip vibrationAudio, int hand)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);

        if (hand == 0)
        {
            //catSource.PlayOneShot(catMeowSound, 1);
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (hand == 1)
        {
            //catSource.PlayOneShot(catMeowSound, 1);
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
    

}
