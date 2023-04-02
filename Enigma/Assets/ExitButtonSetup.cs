using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonSetup : MonoBehaviour
{
    private Button btn;
    [SerializeField] AudioClip btnPress;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Setup);
    }

    private void Setup() {
        StartCoroutine(Settings());
    }

    private IEnumerator Settings() {
        float t = 0.5f;
        AudioManager.instance.PlaySfx(btnPress);
        while (t > 0) {
            t -= Time.deltaTime;
            yield return null;
        }
        _GameManager.instance.ExitGame();
    }
}
