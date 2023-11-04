using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMissionStart : MonoBehaviour
{
    public Image image; // Reference to the Image component
    public Image imageHowToPlay;
    public float fadeDuration = 0.5f; // Duration of the fade in seconds
    public GameObject startBlurb;
    public Text startObjective;

    void Start()
    {
        StartCoroutine(SequenceStart());
    }

    IEnumerator FadeImageAlpha(Image im)
    {
        Color startColor = im.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); // Fully transparent

        float startTime = Time.time;
        float endTime = startTime + fadeDuration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / fadeDuration;
            im.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        // Ensure the final color is fully transparent
        im.color = endColor;
        im.gameObject.SetActive(false);

    }
    IEnumerator FadeInSecondImage(Image im)
    {
        im.gameObject.SetActive(true); // Enable the second image

        Color startColor = im.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // Fully opaque

        float startTime = Time.time;
        float endTime = startTime + fadeDuration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / fadeDuration;
            im.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        im.color = endColor; // Ensure the final color is fully opaque
        yield return new WaitForSeconds(2f);

    }
    IEnumerator StartTextBlurb()
    {
        startBlurb.SetActive(true);
        yield return null;
    }

    IEnumerator FirstObjective()
    {
        startObjective.gameObject.SetActive(true);
        yield return null;
    }

    IEnumerator SequenceStart()
    {
        yield return StartCoroutine(FadeImageAlpha(image));
        yield return StartCoroutine(FadeInSecondImage(imageHowToPlay));
        yield return StartCoroutine(FadeImageAlpha(imageHowToPlay));
        yield return StartCoroutine(StartTextBlurb());
        yield return StartCoroutine(FirstObjective());

    }
}
