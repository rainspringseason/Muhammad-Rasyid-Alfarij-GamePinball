using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Color colorOn;
    public Color colorOff;

    public float score;

    private Renderer colorRenderer;
    private SwitchState state;

    private void Start()
    {
        colorRenderer = GetComponent<Renderer>();

        SetColor(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Toggle();
            AudioManager.Instance.PlaySwitchSound(other.transform.position);
            EffectManager.Instance.PlaySwitchEffect(other.transform.position);
            ScoreManager.Instance.AddScore(score);
        }
    }

    private void SetColor(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            colorRenderer.material.color = colorOn;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            colorRenderer.material.color = colorOff;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            SetColor(false);
        }
        else
        {
            SetColor(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            colorRenderer.material.color = colorOn;
            yield return new WaitForSeconds(0.5f);
            colorRenderer.material.color = colorOff;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
