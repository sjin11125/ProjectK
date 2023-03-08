using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_in_out : MonoBehaviour {

    public float FadeTime = 2f;
    Image fadeimg;
    float end;
    float start;
    float time = 0f;
    bool isPlaying = false;

    void Awake()
    {
        fadeimg = GetComponent<Image>();
        InstartFadeAnim();
    }
    public void OutStartFadeAnim()
    {
        if (isPlaying==true)
        {
            return;
        }
        start = 1f;
        end = 0f;
        StartCoroutine("Fadeoutplay");
    }

    public void InstartFadeAnim()
    {
        if (isPlaying==true)
        {
            return;
        }
        start = 0f;
        end = 1f;
        StartCoroutine("Fadeinplay");
    }

    IEnumerator Fadeoutplay()
    {
        isPlaying = true;

        Color fadecolor = fadeimg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor.a>0f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeimg.color = fadecolor;
            yield return null;
        }
        isPlaying = false;
    }

    IEnumerator Fadeinplay()
    {
        isPlaying = true;

        Color fadecolor = fadeimg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor.a < 255f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeimg.color = fadecolor;
            yield return null;
        }
        isPlaying = false;
    }
 
}
