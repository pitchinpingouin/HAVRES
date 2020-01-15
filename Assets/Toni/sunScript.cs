using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    [SerializeField] private float dayDuration;
    
    public Transform sunTransform;

    private float timeOfDay;
    public float angleSun;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
