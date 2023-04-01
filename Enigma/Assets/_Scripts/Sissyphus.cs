using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sissyphus : MonoBehaviour
{
    public Transform rockSpawn;
    public GameObject rockPrefab;
    private bool spawned = false;
    public Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player" && spawned == false) {
            spawned = true;
            Debug.Log("Rock Spawn");
            cam.GetComponent<CameraShake>().StartShake(10.0f, 0.15f);
            Instantiate(rockPrefab, rockSpawn.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
        
    }
}
