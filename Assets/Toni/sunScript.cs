using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    [SerializeField] private float dayDuration;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip dayAudio;
    [SerializeField] private AudioClip nightAudio;
    [SerializeField] private bool dayPlaying;
    [SerializeField] private bool nightPlaying;
    public Transform sunTransform;

    private float timeOfDay;
    private float angleSun;

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = dayAudio;
        audio.Play();
        dayPlaying = true;
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
            audio.clip = nightAudio;
            audio.Play();
        }
        else if (angleSun < 150 && !dayPlaying)
        {
            
            dayPlaying = true;
            nightPlaying = false;
            audio.clip = dayAudio;
            audio.Play();
        }
    }
}
