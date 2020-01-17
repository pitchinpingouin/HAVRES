using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMeow : MonoBehaviour
{

    [SerializeField] private AudioClip catMeowSound;

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
        if (collider.CompareTag("Hand"))
        {
            catSource.PlayOneShot(catMeowSound, 1);
        }
    }
}
