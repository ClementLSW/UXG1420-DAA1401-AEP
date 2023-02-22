using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sissyphus : MonoBehaviour
{
    public Transform rockSpawn;
    public GameObject rockPrefab;
    public Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Rock Spawn");
        Instantiate(rockPrefab, rockSpawn.position, Quaternion.identity);
        cam.GetComponent<CameraShake>().StartShake(10.0f, 0.15f);
        Destroy(gameObject);
    }
}
