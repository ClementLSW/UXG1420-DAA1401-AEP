using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public float fadeTime = 2f; // The duration of the fade in seconds
    public float delayTime = 1f; // The delay before the next panel starts to fade

    [SerializeField]private CanvasGroup[] panels; // An array of all the panels
    private int currentPanelIndex = 0; // The index of the current panel being faded in

    public IEnumerator PlayCutscene() {
        // Get all the panels and set their alpha value to 0
        //panels = GetComponentsInChildren<CanvasGroup>();
        foreach (CanvasGroup panel in panels) {
            panel.alpha = 0f;
        }

        // Start the fading coroutine
        yield return StartCoroutine(FadeInPanels());
    }

    public IEnumerator EndCutscene() {
        panels = GetComponentsInChildren<CanvasGroup>();
        foreach (CanvasGroup panel in panels) {
            panel.alpha = 1f;
        }
        yield return StartCoroutine(FadeOutPanels());
    }

    private IEnumerator FadeInPanels() {
        // Loop through each panel and fade it in
        foreach (CanvasGroup panel in panels) {
            // Wait for the delay time before fading in the next panel
            yield return new WaitForSeconds(delayTime);

            // Fade in the panel over the fade time
            float t = 0f;
            while (t < fadeTime) {
                panel.alpha = Mathf.Lerp(0f, 1f, t / fadeTime);
                t += Time.deltaTime;
                yield return null;
            }

            // Set the panel's alpha to 1
            panel.alpha = 1f;

            // Increment the current panel index
            //currentPanelIndex++;
        }
    }

    private IEnumerator FadeOutPanels() {
        // Loop through each panel and fade it in
        
        //    // Wait for the delay time before fading in the next panel
        //    yield return new WaitForSeconds(delayTime);

            // Fade in the panel over the fade time
        float t = 0f;
        while (t < fadeTime) {
            foreach (CanvasGroup panel in panels) {
                panel.alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
                t += Time.deltaTime;
            }
            yield return null;
        }

        // Set the panel's alpha to 1
        foreach (CanvasGroup panel in panels) {
            panel.alpha = 0f;
        }
            // Increment the current panel index
            //currentPanelIndex++;
    }
}
