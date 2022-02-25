using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Material material;
    float alpha;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        alpha = 0;

        StartCoroutine(FadeInRoutine());
        StartCoroutine(Timer(2));
        StartCoroutine(UpdateAI(5));
    }

    void Update()
    {
        //FadeIn();
    }

    void FadeIn()
    {
        alpha += Time.deltaTime;
        alpha = Mathf.Min(alpha, 1);

        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }

    IEnumerator FadeInRoutine()
    {
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            alpha = Mathf.Min(alpha, 1);

            Color color = material.color;
            color.a = alpha;
            material.color = color;

            yield return null;
        }
    }

    IEnumerator Timer(float time)
    {
        print("hello");
        yield return new WaitForSeconds(time);
        print("world");
        yield return new WaitForSeconds(time);
        print("goodbye");
        yield return new WaitForSeconds(time);
    }

    IEnumerator UpdateAI(float time)
    {
        for (;;)
        {
            print("thinking...");
            yield return new WaitForSeconds(time);
        }
    }
}
