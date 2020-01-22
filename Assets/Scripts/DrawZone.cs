using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZone : MonoBehaviour
{
    public GameObject canvaParam;
    public bool canDrawZone;
    public GameObject DrawMark1;
    public GameObject DrawMark2;
    public Transform Player;

    private RaycastHit hit; //C'est lui que je veux

    public Transform centerTransform;
    private float state;


    void Start()
    {
        canDrawZone = true;
        state = 0;
    }

    private void ResetZone()
    {
        centerTransform.gameObject.SetActive(false);
        DrawMark1.SetActive(false);
        DrawMark2.SetActive(false);
    }

    private void zoneAppears()
    {
        centerTransform.position = DrawMark2.transform.position + 0.5f * (DrawMark1.transform.position - DrawMark2.transform.position);
        centerTransform.localScale = ((DrawMark1.transform.position - DrawMark2.transform.position) + Vector3.up * 10.0f);
        centerTransform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        //TODO:
        ///hit = hit point du laser tiré dns distance grabber, ou le transform du point de collision svp
        //TODO:
            
            
        if (canDrawZone)
        {

            if (state == 0)
            {
                ResetZone();
            }

            if(state == 1)
            {
                //DrawMark2.transform.position = hit.point + 0.1f * Vector3.up;
            }

            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                {
                    
                    if (state == 0)
                    {
                        state = 1;
                        //DrawMark1.transform.position = hit.point + 0.1f * Vector3.up;
                        //DrawMark2.transform.position = hit.point + 0.1f * Vector3.up;
                        //DrawMark1.SetActive(true);
                        //DrawMark2.SetActive(true);
                    }
                    else
                    {
                        state = 0;
                    }
                }
            }

            if (OVRInput.GetUp(OVRInput.Button.Two))
            {
                if (state > 0)
                {
                    zoneAppears();
                }
            }
        }
    }
}
