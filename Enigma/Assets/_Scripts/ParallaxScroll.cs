using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{

    private float scrollSpeed = 0.2f;
    private float tileSizeX;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        tileSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //float xParallax = Input.GetAxis("Horizontal") * scrollSpeed;

        //transform.position = new Vector3(transform.position.x - xParallax, camera.transform.position.y, transform.position.z);

        //if (transform.position.x < -tileSizeX) {
        //    transform.position += Vector3.right * tileSizeX * 2;
        //}else if(transform.position.x > tileSizeX) {
        //    transform.position += Vector3.left * tileSizeX * 2;
        //}

        transform.position += Vector3.right * -Input.GetAxis("Horizontal") * scrollSpeed * Time.deltaTime;        // Handles X-Axis with Parallex
        transform.position += Vector3.up * (camera.transform.position.y - transform.position.y);                    // Handles Y-Axis without Parallex
        
        if(transform.position.x - camera.transform.position.x < -tileSizeX) {
            Debug.Log(gameObject.name + " Tile to the Right");
            transform.position += Vector3.right * tileSizeX * 2;
        }else if(transform.position.x - camera.transform.position.x > tileSizeX) {
            Debug.Log(gameObject.name +  " Tile to the Left");
            transform.position += Vector3.left * tileSizeX * 2;
        }
    }
}
