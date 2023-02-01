using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Camera cam;

    public float sinkDepth;

    void Start(){
        sinkDepth = transform.localScale.y;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "weight"){
            Debug.Log("Activated");
            cam.GetComponent<CameraShake>().StartShake(5f, 0.2f);
        }

        Activate();
    }

    void Update(){

    }

    void Activate(){

    }
}
