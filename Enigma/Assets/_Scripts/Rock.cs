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


    private void Start() {
        gm = _GameManager.instance;
        audioManager = AudioManager.instance;
        audioManager.PlaySfx(rollingClip);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-rockForce, 0);
    }

    private void Update() {
        if(duration >= 0) {
            duration -= Time.deltaTime;
        }
        else {
            audioManager.PlaySfx(breakClip);
            Destroy(gameObject);
        }

        if (!Player.instance.isAlive) {
            audioManager.StopSfx(rollingClip);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Player") {
            audioManager.StopSfx(rollingClip);
            audioManager.PlaySfx(breakClip);
            Destroy(gameObject);

            // Call Death function in Game Manager
            gm.Death(2);
        }
    }
}
