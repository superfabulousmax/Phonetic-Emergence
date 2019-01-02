using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Color originalCol;
    [SerializeField]
    private Color blinkCol;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalCol = spriteRenderer.color;
    }

    public void BlinkColour(float seconds)
    {
        StartCoroutine(ChangeThenWait(seconds));
    }

    IEnumerator ChangeThenWait(float seconds)
    {
        spriteRenderer.color = blinkCol;
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = originalCol;
    }

    public void WaitBeforeNextBlink(float seconds)
    {
        StartCoroutine(Wait(seconds));
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    
}
