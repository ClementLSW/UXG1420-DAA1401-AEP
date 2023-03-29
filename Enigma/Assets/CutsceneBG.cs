using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneBG : MonoBehaviour
{
    public static CutsceneBG instance { get; private set; }

    public float fadeTime = 1f;
    [SerializeField] private CanvasGroup bg;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        bg.alpha = 0f;
    }

    public IEnumerator FadeInImage() {
        // Fade in the image over the fade time
        Debug.Log("Fading BG");
        float t = 0f;
        while (t < fadeTime) {
            bg.alpha = Mathf.Lerp(0f, 1f, t / fadeTime);
            t += Time.deltaTime;
            yield return null;
        }
        Debug.Log("FadeInFinished");
        // Set the alpha value of the image to 1
        bg.alpha = 1f;
    }

    public IEnumerator FadeOutImage() {
        // Fade in the image over the fade time
        float t = 0f;
        while (t < fadeTime) {
            bg.alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
            t += Time.deltaTime;
            yield return null;
        }

        // Set the alpha value of the image to 1
        bg.alpha = 0f;
        Debug.Log("FadeOutFinished");
    }
}
