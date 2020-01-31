using System.Collections;
using System.Collections.Generic;
using OculusSampleFramework;
using UnityEngine;

public class DrawZone : MonoBehaviour
{
   // public GameObject canvaParam;
    private bool canDrawZone;
    public GameObject DrawMark1;
    public GameObject DrawMark2;
   // public Transform Player;

//    private DistanceGrabber distanceGrabberScript;

    public Transform drawZoneTransform;
    private float state;

    [SerializeField] private float RayLength = 50f;

    void Start()
    {
        canDrawZone = true;
        state = 0;
    }

    private void ResetZone()
    {
        drawZoneTransform.gameObject.SetActive(false);
        DrawMark1.SetActive(false);
        DrawMark2.SetActive(false);
    }

    private void zoneAppears()
    {
        drawZoneTransform.position = DrawMark2.transform.position + 0.5f * (DrawMark1.transform.position - DrawMark2.transform.position);
        drawZoneTransform.localScale = ((DrawMark1.transform.position - DrawMark2.transform.position) + Vector3.up * 10.0f);
        drawZoneTransform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrawZone)
        {
            if (state == 0)
            {
                ResetZone();
            }

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayLength))
            {
                if (hit.collider.tag == "Ground")
                {
                     if (state == 1)
                     {
                         DrawMark2.transform.position = hit.point + 0.1f * Vector3.up;
                     }
                    
                     if (OVRInput.GetDown(OVRInput.Button.Two))
                     {
                        if (state == 0)
                        {
                            
                            state = 1;
                            
                            DrawMark1.transform.position = hit.point + 0.1f * Vector3.up;
                            DrawMark2.transform.position = hit.point + 0.1f * Vector3.up;
                            DrawMark1.SetActive(true);
                            DrawMark2.SetActive(true);
                            
                        }
                        else
                        {
                            state = 0;
                        }
                     }
                     
                     if (OVRInput.GetUp(OVRInput.Button.Two))
                     {
                         if (state > 0)
                         {
                             zoneAppears();
                             state = 2;
                         }
                     }
                     
                }
                else
                {
                    if (OVRInput.GetDown(OVRInput.Button.Two))
                    {
                        state = 0;
                    }
                }
            }
            
        }
    }
}
