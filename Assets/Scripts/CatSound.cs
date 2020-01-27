using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSound : MonoBehaviour
{

    //[SerializeField] private AudioClip catMeowSound;

    [SerializeField] private AudioClip catRonronSound;

    private AudioSource catSource;

    private bool rightTouching;

    private bool leftTouching;

    private float timer;

    private float timerMax;

    public AudioClip hapticsAudioClip;

    private OVRHapticsClip hapticsClip;


    //private OVRHapticsClip clipLight;

    //[SerializeField]
    //OVRInput.Controller controllerMask;


    // Start is called before the first frame update
    void Start()
    {
        catSource = GetComponent<AudioSource>();
        leftTouching = false;
        rightTouching = false;
        timer = 0.0f;
        timerMax = 4f;
        hapticsClip = new OVRHapticsClip(hapticsAudioClip);
        //InitializeOVRHaptics();
        //Vibrate();
    }

    // Update is called once per frame
    void Update()
    {
        /*StartCoroutine(WaitVibration(0));
        StartCoroutine(WaitVibration(1));*/
        
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

    
    public void OnTriggerEnter(Collider collider)
    {
        

        if (collider.CompareTag("LeftHand"))
        {
            //OVRHaptics.LeftChannel.Preempt(hapticsClip);
            catSource.loop = true;
            catSource.clip = catRonronSound;
            catSource.Play();
            //leftTouching = true;
            
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catMeowSound, OVRInput.Controller.LTouch);
            //TriggerVibration(catMeowSound, 0);
            //TriggerVibration2(500, 5, 255, 0);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //OVRHaptics.RightChannel.Preempt(hapticsClip);
            catSource.loop = true;
            catSource.clip = catRonronSound;
            catSource.Play();
            //rightTouching = true;
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration2(500, 5, 255, 1);

            //TriggerVibration(catMeowSound, 1);
        }
    }
    /*
    IEnumerator WaitVibration(int hand)
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        yield return wait;

        if (hand == 0 && leftTouching)
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
        }
        else if (hand == 1 && rightTouching)
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
        }
        
        
    }
    */
    public void OnTriggerStay(Collider collider)
    {
        timer += Time.deltaTime;
        if (collider.CompareTag("LeftHand"))
        { 
            //OVRHaptics.LeftChannel.Preempt(hapticsClip);
            /*catSource.clip = catRonronSound;
            catSource.Play();*/
            if (timer > timerMax)
            {
                OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
                timer = 0.0f;

                // Do Stuff
            }
            
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catRonronSound, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
            //TriggerVibration(catMeowSound, 0);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //OVRHaptics.RightChannel.Preempt(hapticsClip);
            if (timer > timerMax)
            {
                OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
                timer = 0.0f;

                // Do Stuff
            }
            /*catSource.clip = catRonronSound;
            catSource.Play();*/
            
            //OVRInput.SetControllerVibration(0.005f, 0.1f, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);

            //TriggerVibration(catRonronSound, OVRInput.Controller.RTouch);
            //catSource.PlayOneShot(catMeowSound, 1);

            //TriggerVibration(catMeowSound, 1);
        }
    }
    
    public void OnTriggerExit(Collider collider)
    {
        timer = 0.0f;
        if (collider.CompareTag("LeftHand"))
        {
            //leftTouching = false;
            //OVRHaptics.LeftChannel.Clear();
            catSource.loop = false;
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            //catSource.PlayOneShot(catMeowSound, 1);
        }
        else if (collider.CompareTag("RightHand"))
        {
            //rightTouching = false;
            //OVRHaptics.RightChannel.Clear();
            //catSource.Stop();
            catSource.loop = false;
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
