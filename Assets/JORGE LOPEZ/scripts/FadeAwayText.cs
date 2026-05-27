using TMPro;
using UnityEngine;

public class FadeAwayText : MonoBehaviour
{
    [Header("Start Delay")]
    public float startDelay = 2f;

    [Header("Fade Times")]
    public float fadeInTime = 1f;
    public float visibleTime = 1f;
    public float fadeOutTime = 1f;

    private TextMeshProUGUI fadeText;

    private float timer = 0f;

    private enum FadeState
    {
        WaitingToStart,
        FadingIn,
        Waiting,
        FadingOut,
        Finished
    }

    private FadeState currentState;

    void Start()
    {
        fadeText = GetComponent<TextMeshProUGUI>();

        // Start invisible
        SetAlpha(0f);

        currentState = FadeState.WaitingToStart;
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentState)
        {
            case FadeState.WaitingToStart:

                if (timer >= startDelay)
                {
                    timer = 0f;
                    currentState = FadeState.FadingIn;
                }

                break;

            case FadeState.FadingIn:

                float fadeInAlpha = timer / fadeInTime;
                SetAlpha(fadeInAlpha);

                if (timer >= fadeInTime)
                {
                    SetAlpha(1f);
                    timer = 0f;
                    currentState = FadeState.Waiting;
                }

                break;

            case FadeState.Waiting:

                if (timer >= visibleTime)
                {
                    timer = 0f;
                    currentState = FadeState.FadingOut;
                }

                break;

            case FadeState.FadingOut:

                float fadeOutAlpha = 1f - (timer / fadeOutTime);
                SetAlpha(fadeOutAlpha);

                if (timer >= fadeOutTime)
                {
                    SetAlpha(0f);
                    currentState = FadeState.Finished;
                }

                break;

            case FadeState.Finished:
                break;
        }
    }

    void SetAlpha(float alpha)
    {
        Color color = fadeText.color;
        color.a = Mathf.Clamp01(alpha);
        fadeText.color = color;
    }
}