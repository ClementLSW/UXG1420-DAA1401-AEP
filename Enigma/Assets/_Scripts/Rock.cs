using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private _GameManager gm;
    private AudioManager audioManager;
    private float rockForce = 15.0f;
    [SerializeField] float duration = 20.0f;
    [SerializeField] private AudioClip rollingClip;
    [SerializeField] private AudioClip breakClip;
    AudioSource l_src = null, l_src_r;


    private void Start() {
        gm = _GameManager.instance;
        audioManager = AudioManager.instance;
        l_src_r = audioManager.PlaySfx(rollingClip);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-rockForce, 0);
    }

    private void Update() {
        
        if(duration >= 0) {
            duration -= Time.deltaTime;
        }
        else {
            l_src = audioManager.PlaySfx(breakClip);
            Destroy(gameObject);
        }

        if (!Player.instance.isAlive) {
            audioManager.StopSfx(l_src);
            l_src = null;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Player") {
            audioManager.StopSfx(l_src_r);
            l_src_r = null;
            audioManager.PlaySfx(breakClip);
            Destroy(gameObject);

            // Call Death function in Game Manager
            gm.Death(2);
        }
    }
}
