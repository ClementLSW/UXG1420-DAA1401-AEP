using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Camera cam;

    public float sinkDepth;
    private Vector3 sinkVector, sinkDest;
    private bool sink;

    void Start(){
        sinkDepth = transform.localScale.y;
        sinkVector = new Vector3(0, sinkDepth, 0);
        sinkDest = transform.position - sinkVector;
        Debug.Log(sinkDest);
        sink = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "weight"){
            Debug.Log("Activated");
            cam.GetComponent<CameraShake>().StartShake(1.5f, 0.05f);
            GetComponent<BoxCollider2D>().enabled = false;
            sink = true;

            // Do Stuff Here
        }
    }

    void Update(){
        if (sink){
            if(transform.position.y <= sinkDest.y){
                Debug.Log("Destroy");
                Destroy(this.gameObject);
            }
            else {
                Debug.Log("Move");
                transform.position = Vector3.MoveTowards(transform.position, sinkDest, 0.5f * Time.deltaTime);
            }
        }
    }
}
