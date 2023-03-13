using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;
using static _GameManager;

public class Player : MonoBehaviour
{

    public static Player player;

    [SerializeField]
    private AudioManager audioManager;
    private _GameManager gm;
    
    [SerializeField]
    private AudioClip jumpClip;

    void Awake() {
        audioManager = AudioManager.instance;
        gm = _GameManager.instance;

        if (player == null) {
            player = this;
        }
        else if (player != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayJump() {
        audioManager.PlayPlayerSfx(jumpClip);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "death block") {
            gm.Death(0);
        }
    }
}
