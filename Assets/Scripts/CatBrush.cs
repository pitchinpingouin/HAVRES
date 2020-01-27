using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBrush : MonoBehaviour
{
    private Color col;

    private float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<MeshRenderer>().material.color;
        fadeSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*col = GetComponent<MeshRenderer>().material.color;
        col.a -= Time.deltaTime; //* fadeSpeed;
        this.GetComponent<MeshRenderer>().material.color = col;*/
        if (col.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    /*public void OnCollisionStay(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        if (collision.gameObject.CompareTag("CatBrush"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
    }*/

    public void OnTriggerStay(Collider collision)
    {
        //collision.GetComponent<MeshRenderer>().material.color = Color.green;
        if (collision.CompareTag("CatBrush"))
        {
            col = this.GetComponent<MeshRenderer>().material.color;
            col.a -= Time.deltaTime * fadeSpeed;
            this.GetComponent<MeshRenderer>().material.color = col;
            //collision.GetComponent<MeshRenderer>().material.color = Color.red;
        }

    }
}
