using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime;

    private void Start()
    {
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCor());
    }

    IEnumerator FadeInCor()
    {
        fadeImage.DOFade(0f, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        fadeImage.gameObject.SetActive(false);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCor());
    }

    IEnumerator FadeOutCor()
    {
        fadeImage.gameObject.SetActive(true);

        fadeImage.DOFade(1f, fadeTime);
        yield return null;        
    }
}
