using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    
    Color pressedColor = Color.green;
    Color oldColor;
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        oldColor = mesh.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ButtonStayTrigger>().isTrigger == true)
        {
            mesh.material.color = pressedColor;
        }
        else
        {
            mesh.material.color = oldColor;
        }
    }
}
