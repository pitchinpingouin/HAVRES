using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSound : MonoBehaviour
{

    //[SerializeField] private AudioClip catMeowSound;

    [SerializeField] private AudioClip catRonronSound;

    private AudioSource catSource;

    //private OVRHapticsClip clipLight;

    //[SerializeField]
    //OVRInput.Controller controllerMask;


    // Start is called before the first frame update
    void Start()
    {
        catSource = GetComponent<AudioSource>();
        //InitializeOVRHaptics();
        //Vibrate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void InitializeOVRHaptics()
    {

        int cnt = 500;
        clipLight = new OVRHapticsClip(cnt);
        for (int i = 0; i < cnt; i++)
        {
            clipLight.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)255;
        }

        clipLight = new OVRHapticsClip(clipLight.Samples, clipLight.Samples.Length);
    }
    */
    /*
    public void Vibrate()
    {
        var channel = OVRHaptics.RightChannel;
        if (controllerMask == OVRInput.Controller.LTouch)
            channel = OVRHaptics.LeftChannel;

        channel.Preempt(clipLight);
    }*/

    /*
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("LeftHand"))
        {
            catSource.clip = catRonronSound;
            catSource.Play();
            OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catMeowSound, OVRInput.Controller.LTouch);
            //TriggerVibration(catMeowSound, 0);
            //TriggerVibration2(500, 5, 255, 0);
        }
        else if (collider.CompareTag("RightHand"))
        {
            catSource.clip = catRonronSound;
            catSource.Play();
            OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration2(500, 5, 255, 1);

            //TriggerVibration(catMeowSound, 1);
        }
    }*/
    
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("LeftHand"))
        {
            catSource.clip = catRonronSound;
            catSource.Play();
            OVRInput.SetControllerVibration(0.000001f, 0.1f, OVRInput.Controller.LTouch);
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catRonronSound, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catMeowSound, 0);
        }
        else if (collider.CompareTag("RightHand"))
        {
            catSource.clip = catRonronSound;
            catSource.Play();
            OVRInput.SetControllerVibration(0.000001f, 0.1f, OVRInput.Controller.RTouch);
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);

            //TriggerVibration(catRonronSound, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);

            //TriggerVibration(catMeowSound, 1);
        }
    }
    
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("LeftHand"))
        {
            //OVRHaptics.LeftChannel.Clear();
            catSource.Stop();
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //OVRHaptics.RightChannel.Clear();
            catSource.Stop();
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
    /*
    public void TriggerVibration(AudioClip vibrationAudio, int hand)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);

        if (hand == 0)
        {
            //catSource.PlayOneShot(catMeowSound, 1);
            OVRHaptics.LeftChannel.Queue(clip);
        }
        else if (hand == 1)
        {
            //catSource.PlayOneShot(catMeowSound, 1);
            OVRHaptics.RightChannel.Queue(clip);
        }
    }*/
    /*
    public void TriggerVibration2(int iteration, int frequency, int strength, int hand)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }
        if (hand == 0)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (hand == 1)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }*/


}
