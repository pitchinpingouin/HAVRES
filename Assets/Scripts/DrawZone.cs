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
    public float RayLengtht = 50f;
    public Transform centerTransform;
    private float state;


    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
        if (canDrawZone)
        {

            if (state == 0)
            {
                ResetZone();
            }

            if(state == 1)
            {
                //DrawMark2.transform.position = point d'impact du laser;
            }

            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                {
                    
                    if (state == 0)
                    {
                        state = 1;
                        //DrawMark1.transform.position = point d'impact du laser;
                        DrawMark1.SetActive(true);
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
                    centerTransform.position = DrawMark2.transform.position + 0.5f * (DrawMark1.transform.position - DrawMark2.transform.position);
                    centerTransform.localScale = ((DrawMark1.transform.position - DrawMark2.transform.position) + Vector3.up * 10.0f);
                    centerTransform.gameObject.SetActive(true);
                }
            }
        }
    }
}
