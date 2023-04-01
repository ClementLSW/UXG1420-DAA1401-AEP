using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    private void Start() {
        player = Player.instance.gameObject;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<SpriteRenderer>().flipX = false;
        player.transform.position = transform.position;
        player.GetComponent<PlayerMovement>().ResetAnimator();
    }
}
