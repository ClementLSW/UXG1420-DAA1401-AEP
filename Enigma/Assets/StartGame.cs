using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private Button btn;
    [SerializeField] private AudioClip BGM, SFX;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(startGame);
    }

    private void startGame() {
        AudioManager.instance.StopBGM(BGM);
        AudioManager.instance.PlaySfx(SFX);
        StartCoroutine(CutsceneBG.instance.FadeInImage());
        StartCoroutine(loadTut());
        //_GameManager.instance.SwitchState(1);
    }
    private IEnumerator loadTut() {
        float t = 1.0f;
        float i = 0.0f;

        while (i < t) {
            i+= Time.deltaTime;
            yield return null;
        }

        _GameManager.instance.SwitchState(1);
    }
}
