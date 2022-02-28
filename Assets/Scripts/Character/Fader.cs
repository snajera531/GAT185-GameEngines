using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Material material;
    float alpha;

    public bool IsDone { get; set; }

    void Start()
    {
        material = GetComponent<Renderer>().material;
        alpha = 0;

        StartCoroutine(FadeInRoutine());
    }

    void Update()
    {
        //FadeIn();
    }

    public void FadeIn()
    {
        IsDone = false;
        alpha += Time.deltaTime;
        alpha = Mathf.Min(alpha, 1);

        Color color = material.color;
        color.a = alpha;
        material.color = color;
        IsDone = true;
    }
    
    public void FadeOut()
    {
        IsDone = false;
        alpha += Time.deltaTime;
        alpha = Mathf.Min(alpha, 1);

        Color color = material.color;
        color.a = alpha;
        material.color = color;
        IsDone = true;
    }

    IEnumerator FadeInRoutine()
    {
        IsDone = false;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            alpha = Mathf.Min(alpha, 1);

            Color color = material.color;
            color.a = alpha;
            material.color = color;

            yield return null;
        }
        IsDone = true;
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
