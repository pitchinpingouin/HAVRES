using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    [SerializeField] private float dayDuration;
    [SerializeField] private AudioSource dayAudio;
    [SerializeField] private AudioSource nightAudio;
    [SerializeField] private bool dayPlaying;
    [SerializeField] private bool nightPlaying;
    public Transform sunTransform;

    private float timeOfDay;
    private float angleSun;

    // Start is called before the first frame update
    void Start()
    {
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
            StartCoroutine(StartFade(dayAudio, 10f, 0));
            StartCoroutine(StartFade(nightAudio, 10f, 1));
        }
        else if (angleSun < 150 && !dayPlaying)
        {
            
            dayPlaying = true;
            nightPlaying = false;
            //dayAudio.Play();
            //nightAudio.Stop();
            StartCoroutine(StartFade(dayAudio, 10f, 1));
            StartCoroutine(StartFade(nightAudio, 10f, 0));
            
        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
