using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject TeleportMark;
    public Transform Player;
    public float RayLengtht = 50f;
    Vector3 markerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (OVRInput.Get(OVRInput.Button.One)){
            if (Physics.Raycast(ray, out hit, RayLengtht))
            {
                if (hit.collider.tag == "Ground")
                {
                    if (!TeleportMark.activeSelf)
                    {
                        TeleportMark.SetActive(true);
                    }
                    TeleportMark.transform.position = hit.point;
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
