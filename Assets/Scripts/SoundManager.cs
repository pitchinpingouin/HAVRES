using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource dayAudio;
    [SerializeField] private AudioSource nightAudio;
    private bool dayPlaying;
    private bool nightPlaying;
    [SerializeField] private GameObject sceneManager;
    private float angleSun;

    // Start is called before the first frame update
    void Start()
    {
        dayAudio.Play();
        nightAudio.Play();
        nightAudio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        angleSun = sceneManager.GetComponent<sunScript>().angleSun;
        if (angleSun > 180 && !nightPlaying)
        {
            dayPlaying = false;
            nightPlaying = true;
            //nightAudio.Play();
            //dayAudio.Stop();
            StartCoroutine(StartFade(dayAudio, 5f, 0));
            StartCoroutine(StartFade(nightAudio, 5f, 1));
        }
        else if (angleSun < 150 && !dayPlaying)
        {

            dayPlaying = true;
            nightPlaying = false;
            //dayAudio.Play();
            //nightAudio.Stop();
            StartCoroutine(StartFade(dayAudio, 5f, 1));
            StartCoroutine(StartFade(nightAudio, 5f, 0));

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
