using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFaderRawImage : MonoBehaviour
{
    public RawImage fadeImage;
    public float fadeDuration = 7.0f;


    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // mesma cor, alpha 0

        while (timer < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = endColor;
    }
}