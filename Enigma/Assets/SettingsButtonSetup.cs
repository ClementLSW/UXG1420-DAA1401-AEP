using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonSetup : MonoBehaviour
{
    private Button btn;
    [SerializeField] AudioClip btnPress;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Settings);
    }

    private void Settings() {
        _GameManager.instance.togglePause();
        AudioManager.instance.PlaySfx(btnPress);
    }
}
