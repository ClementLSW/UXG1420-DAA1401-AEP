using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    [SerializeField]
    private AudioManager audioManager;
    private _GameManager gm;
    
    [SerializeField]
    private AudioClip jumpClip;

    public bool isAlive { get; set; }
    public bool key { get; set; }

    void Awake() {
        audioManager = AudioManager.instance;
        gm = _GameManager.instance;
        this.key = false;

        if (player == null) {
            player = this;
        }
        else if (player != this)
            Destroy(gameObject);
        isAlive = true;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayJump() {
        audioManager.PlayPlayerSfx(jumpClip);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "death block") {
            gm.Death(0);
            //gm.LoadAlpha();
        }
    }
}
