using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFade : MonoBehaviour
{
    [Header("Fade Settings")]
    public float startDelay = 1f;
    public float fadeOutTime = 2f;

    [Header("Destroy Settings")]
    public float destroyAfter = 5f;

    private Image blackScreen;
    private float timer;
    private bool fading;

    void Start()
    {
        blackScreen = GetComponent<Image>();

        // Start fully black
        SetAlpha(1f);

        // Destroy object after set time
        Destroy(gameObject, destroyAfter);
    }

    void Update()
    {
        // Wait before starting fade
        if (!fading)
        {
            timer += Time.deltaTime;

            if (timer >= startDelay)
            {
                timer = 0f;
                fading = true;
            }

            return;
        }

        // Fade out
        timer += Time.deltaTime;

        float alpha = 1f - (timer / fadeOutTime);

        SetAlpha(alpha);

        // Clamp at fully transparent
        if (timer >= fadeOutTime)
        {
            SetAlpha(0f);
        }
    }

    void SetAlpha(float alpha)
    {
        Color color = blackScreen.color;
        color.a = Mathf.Clamp01(alpha);
        blackScreen.color = color;
    }
}