using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGFade : MonoBehaviour
{
    public ProgressBar progressBar;
    private Color visible, invisible;
    private float fadeInElapsedTime = 0f, fadeOutElapsedTime = 0f;
    public float fadeDuration = 3f;
    private Coroutine fadeInCo, fadeOutCo;
    private bool isFadingIn = false, isFadingOut = false, isVisible = false;

    void Update()
    {
        if (progressBar.GetProgress() >= (progressBar.GetMaxProgress() / 2))
        {
            CheckFadeIn();
        }
        else
        {
            CheckFadeOut();
        }
    }

    public void CheckFadeIn()
    {
        if (!isFadingIn && !isVisible)
        {
            fadeInCo = StartCoroutine(FadeIn());
            isFadingIn = true;
        }
    }

    public void CheckFadeOut()
    {
        if (!isFadingOut && isVisible)
        {
            fadeOutCo = StartCoroutine(FadeOut());
            isFadingOut = true;
        }
    }

    public IEnumerator FadeOut()
    {
        Image y = GetComponent<Image>();
        visible = new Color(y.color.r, y.color.g, y.color.b, 1f);
        invisible = new Color(y.color.r, y.color.g, y.color.b, 0f);
        //y.color = visible; //set visible
        fadeOutElapsedTime = 0f;
        while (fadeOutElapsedTime < fadeDuration)
        {
            fadeOutElapsedTime += Time.deltaTime;
            float percentageCompleted = fadeOutElapsedTime / fadeDuration;
            y.color = Color.Lerp(visible, invisible, percentageCompleted);
            if (fadeInElapsedTime >= fadeDuration)
            {
                isVisible = false;
                isFadingOut = false;
            }
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        Image y = GetComponent<Image>();
        visible = new Color(y.color.r, y.color.g, y.color.b, 1f);
        invisible = new Color(y.color.r, y.color.g, y.color.b, 0f);
        //y.color = invisible; //set invisible
        fadeInElapsedTime = 0f;
        while (fadeInElapsedTime < fadeDuration)
        {
            fadeInElapsedTime += Time.deltaTime;
            float percentageCompleted = fadeInElapsedTime / fadeDuration;
            y.color = Color.Lerp(invisible, visible, percentageCompleted);
            if (fadeInElapsedTime >= fadeDuration)
            {
                isVisible = true;
                isFadingIn = false;
            }
            yield return null;
        }
    }
}
