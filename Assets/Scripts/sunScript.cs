using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    [SerializeField] private float dayDuration;

    public Transform sunTransform { get; private set; }
    private Light sunLight;

    [SerializeField] private float sunFullyRisedAngle;

    [SerializeField] private float maxIntensity;
    public float timeOfDay { get; private set; }
    public float angleSun { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = 0.0f;
        sunTransform = transform;
        sunLight = sunTransform.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (angleSun < sunFullyRisedAngle)
        {
            sunLight.intensity = Mathf.Lerp(0.0f, maxIntensity, angleSun / sunFullyRisedAngle);
        }

        if (angleSun > (180 - sunFullyRisedAngle))
        {
            sunLight.intensity = Mathf.Lerp(maxIntensity, 0.0f, (angleSun - (180 - sunFullyRisedAngle)) / sunFullyRisedAngle);
        }

        angleSun = 360 * timeOfDay / dayDuration;
        sunTransform.localRotation = Quaternion.Euler(angleSun, 0, 0);

        timeOfDay += Time.deltaTime;

        if (timeOfDay > dayDuration)
        {
            timeOfDay -= dayDuration;
        }
    }
}
