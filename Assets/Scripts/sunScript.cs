using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    [SerializeField] private float dayDuration;
    private float angleOffset = -30.0f;
    [SerializeField] private AudioSource dayAudio;
    [SerializeField] private AudioSource nightAudio;
    [SerializeField] private bool dayPlaying;
    [SerializeField] private bool nightPlaying;
    [SerializeField] private float maxIntensity;
    public Transform sunTransform;

    private Light sunLight;

    private float timeOfDay;
    private float angleSun;

    // Start is called before the first frame update
    void Start()
    {
        sunLight = sunTransform.GetComponent<Light>();
        dayAudio.Play();
        nightAudio.Play();
        nightAudio.volume = 0;
        //dayAudio.Play();
        //dayPlaying = true;
        timeOfDay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        angleSun = 360 * timeOfDay / dayDuration;


        //Crescendo de lumière
        
        if(angleSun < 45)
        {
            sunLight.intensity = Mathf.Lerp(0.0f, maxIntensity, angleSun/360 * 4 * 2);
        }

        //Decrescendo de lumière
        if (angleSun > 135)
        {
            sunLight.intensity = Mathf.Lerp(maxIntensity, 0.0f, (angleSun - 135)/360 * 4 * 2);
        }

        sunTransform.localRotation = Quaternion.Euler(angleSun, 0, 0);

        timeOfDay += Time.deltaTime;

        if(timeOfDay > dayDuration)
        {
            timeOfDay -= dayDuration;
        }

        if (angleSun > 180 && !nightPlaying)
        {
            dayPlaying = false;
            nightPlaying = true;
            //nightAudio.Play();
            //dayAudio.Stop();
            StartCoroutine(StartFadeAudio(dayAudio, 10f, 0));
            StartCoroutine(StartFadeAudio(nightAudio, 10f, 1));
        }
        else if (angleSun  + angleOffset < 180 && !dayPlaying)
        {
            
            dayPlaying = true;
            nightPlaying = false;
            //dayAudio.Play();
            //nightAudio.Stop();
            StartCoroutine(StartFadeAudio(dayAudio, 10f, 1));
            StartCoroutine(StartFadeAudio(nightAudio, 10f, 0));
            
        }
    }

    public static IEnumerator StartFadeAudio(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
