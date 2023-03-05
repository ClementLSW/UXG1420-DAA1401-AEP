using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private _GameManager gm;
    [SerializeField] float duration = 10.0f;

    private void Start() {
        gm = FindObjectOfType<_GameManager>();
    }

    private void Update() {
        if(duration >= 0) {
            duration -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Player") {
            Debug.Log("SQUASH");
            gm.LoadAlpha();     // TODO: [ALPHA] Remove this after Alpha and reinstate gm.Death(0)
        }
    }
}
