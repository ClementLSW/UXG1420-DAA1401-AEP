using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    public bool lit;
    private float secsTillLit = 2.0f;
    private bool startToLight = false;
    public Sprite sprite;
    private SpriteRenderer sr;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lit && startToLight) {
            secsTillLit -= Time.deltaTime;
        }

        if(secsTillLit <= 0) {
            lit = true;
            startToLight = false;
            sr.sprite = sprite;
        }


    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!lit) {
            if(col.GetComponent<Torch>() && col.GetComponent<Torch>().lit) {
                        startToLight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(!lit && secsTillLit > 0) {
            startToLight = false;
            secsTillLit = 2.0f;
        }
    }
}
