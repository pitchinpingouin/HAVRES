using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject canvaParam;
    // Start is called before the first frame update
    void Start()
    {
        canvaParam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (canvaParam.activeSelf)
            {
                canvaParam.SetActive(false);
            }
            else
            {
                canvaParam.SetActive(true);
            }

        }
    }
}
