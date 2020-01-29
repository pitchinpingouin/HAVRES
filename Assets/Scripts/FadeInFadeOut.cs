using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    float alpha;
    Material mat;

    // Start is called before the first frame update
    void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn(255,1));
    }

    public IEnumerator FadeIn(float maxAlpha, float speed)
    {
        while(mat.color.a < maxAlpha)
        {
            Color color = mat.color;
            color.a += speed * Time.deltaTime;
            if (color.a > maxAlpha)
            {
                color.a = maxAlpha;
            }

            mat.color = color;
            
            yield return null;
        }
    }

    public IEnumerator FadeOut(float minAlpha, float speed)
    {
        while (mat.color.a > minAlpha)
        {
            Color color = mat.color;
            color.a -= speed *  Time.deltaTime;
            if (color.a < minAlpha)
            {
                color.a = minAlpha;
            }

            mat.color = color;

            yield return null;
        }
    }
}
