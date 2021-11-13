using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [Header("About Blink")]
    public int count;
    public float delay;

    public IEnumerator BlinkSprite()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        Color nextColor = sr.color;
        float a = 1f;

        for (int i = 0; i < count; i++)
        {
            a = i % 2 != 0 ? 0.5f : 1f;
            nextColor.a = a;
            sr.color = nextColor;
            yield return new WaitForSeconds(delay);
        }
        a = 1f;
        nextColor.a = a;
        sr.color = nextColor;
    }
}
