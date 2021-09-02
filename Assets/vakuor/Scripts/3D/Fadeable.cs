using System.Collections;
using UnityEngine;

public class Fadeable : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private Renderer[] rendersToFade;

    private Coroutine coroutine;

    public void Fade(bool fadeIn)
    {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(FadeRoutine(fadeIn));
    }

    private IEnumerator FadeRoutine(bool fadeIn)
    {
        Color start = Color.white;
        Color end = Color.white;

        if (fadeIn)
        {
            start.a = 0f;
            end.a = 1f;
        }
        else
        {
            start.a = 1f;
            end.a = 0f;
        }

        for (float t = 0f; t < fadeTime; t += Time.deltaTime)
        {
            SetRenderersLerp(start, end,t/fadeTime);
            yield return null;
        }

        SetRenderersLerp(start, end,1f);
    }

    private void SetRenderersLerp(Color start, Color end, float value)
    {
        foreach (var renderer in rendersToFade)
        {
            renderer.material.color = Color.Lerp(start, end, value);
        }
    }
}