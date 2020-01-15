﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject canvaParam;
    public bool canTeleport;
    public GameObject TeleportMark;
    public Transform Player;
    public float RayLengtht = 50f;
    Vector3 markerPosition;

    // Start is called before the first frame update
    void Start()
    {
        canTeleport = true;
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

        if (canTeleport)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (OVRInput.Get(OVRInput.Button.One))
            {
                if (Physics.Raycast(ray, out hit, RayLengtht))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        if (!TeleportMark.activeSelf)
                        {
                            TeleportMark.SetActive(true);
                        }
                        TeleportMark.transform.position = hit.point;
                        TeleportMark.transform.position = new Vector3(TeleportMark.transform.position.x, TeleportMark.transform.position.y + 0.1f, TeleportMark.transform.position.z);
                    }
                    else
                    {
                        TeleportMark.SetActive(false);
                    }
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.One))
            {
                if (TeleportMark.activeSelf)
                {
                    markerPosition = TeleportMark.transform.position;
                    Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
                }
            }
            else
            {
                TeleportMark.SetActive(false);
            }
        } 
    }
}
