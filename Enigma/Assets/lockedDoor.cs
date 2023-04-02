using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : MonoBehaviour
{
    private Door door;
    public AudioClip doorOpen;

    private void Start() {
        door = GetComponentInParent<Door>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            if (collision.gameObject.GetComponent<Player>().key) {
                AudioManager.instance.PlaySfx(doorOpen);
                door.Open();
                collision.gameObject.GetComponent<Player>().key = false;
                HudManager.instance.hideKeyHUD();
            }
        }
    }
}
