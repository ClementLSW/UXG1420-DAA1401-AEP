using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;
    }
}
