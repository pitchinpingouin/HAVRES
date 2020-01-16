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
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (state == 0)
            {
                ResetZone();
            }

            if (Physics.Raycast(ray, out hit, RayLengtht))
            {
                if (hit.collider.tag == "Ground")
                {
                    if (state == 1)
                    {
                        DrawMark1.transform.position = hit.point + Vector3.up * 0.1f;
                    }

                    if (state == 3)
                    {
                        DrawMark2.transform.position = hit.point + Vector3.up * 0.1f;
                    }

                    if (OVRInput.GetDown(OVRInput.Button.Two))
                    {
                        {
                            if (state == 2)
                            {
                                DrawMark2.SetActive(true);
                            }

                            if (state == 0)
                            {
                                DrawMark1.SetActive(true);
                            }

                            state++;
                        }
                    }

                    if (OVRInput.GetUp(OVRInput.Button.Two))
                    {
                        if (state > 4)
                        {
                            state = 0;
                        }
                        else
                        {
                            state++;
                            if (state == 4)
                            {
                                //Sélectionne les items dans la zone
                                centerTransform.position = DrawMark2.transform.position + 0.5f * (DrawMark1.transform.position - DrawMark2.transform.position);
                                centerTransform.localScale = ((DrawMark1.transform.position - DrawMark2.transform.position) + Vector3.up * 10.0f);
                                centerTransform.gameObject.SetActive(true);
                            }
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
