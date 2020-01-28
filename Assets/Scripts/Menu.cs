using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuZone;
    public Transform OVRPlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        menuZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (menuZone.activeSelf)
            {
                menuZone.SetActive(false);
            }
            else
            {
                menuZone.transform.position = OVRPlayerTransform.position;
                menuZone.transform.rotation = OVRPlayerTransform.rotation;
                menuZone.SetActive(true);
            }

        }
    }
}
