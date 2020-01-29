using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHands : MonoBehaviour
{
    public GameObject rHand;
    public GameObject lHand;
    public GameObject oldRHand;
    public GameObject oldLHand;

    private bool old;

    private void Start()
    {
        old = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Switch();
        }
    }

    public void Switch()
    {
        if (old)
        {
            rHand.SetActive(true);
            lHand.SetActive(true);
            oldRHand.SetActive(false);
            oldLHand.SetActive(false);
        }
        else
        {
            rHand.SetActive(false);
            lHand.SetActive(false);
            oldRHand.SetActive(true);
            oldLHand.SetActive(true);
        }
        old = !old;
    }
}
