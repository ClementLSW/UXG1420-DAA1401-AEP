using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamitePickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Player.instance.hasDynamite = true;
            Destroy(gameObject);
        }
    }
}