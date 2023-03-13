using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class Rock : MonoBehaviour
{
    private _GameManager gm;
    private AudioManager audioManager;
    [SerializeField] float duration = 10.0f;
    [SerializeField] private AudioClip rollingClip;
    [SerializeField] private AudioClip breakClip;


    private void Start() {
        gm = FindObjectOfType<_GameManager>();
        audioManager = AudioManager.instance;
        audioManager.PlaySfx(rollingClip);
    }

    private void Update() {
        if(duration >= 0) {
            duration -= Time.deltaTime;
        }
        else {
            audioManager.PlaySfx(breakClip);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Player") {
            Debug.Log("SQUASH");
            gm.Death(2);
            //gm.LoadAlpha();     // TODO: [ALPHA] Remove this after Alpha and reinstate gm.Death(0)
        }
    }
}
