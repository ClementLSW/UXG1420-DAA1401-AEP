using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private _GameManager gm;
    private AudioManager am;
    private Button btn;
    [SerializeField] private AudioClip BGM, SFX;

    private void Awake() {
        gm = _GameManager.GetInstance();
        am = AudioManager.GetInstance();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(startGame);
    }

    private void startGame() {
        AudioManager.instance.StopBGM(BGM);
        AudioManager.instance.PlaySfx(SFX);
        _GameManager.instance.SwitchState(7);
    }
}
