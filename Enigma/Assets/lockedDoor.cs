using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : MonoBehaviour
{
    private Door door;

    private void Start() {
        door = GetComponentInParent<Door>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            if (collision.gameObject.GetComponent<Player>().key) {
                door.Open();
                collision.gameObject.GetComponent<Player>().key = false;
            }
        }
    }
}