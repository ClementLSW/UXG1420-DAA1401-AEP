using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Camera cam;

    public float sinkDepth;
    private Vector3 sinkVector, sinkDest;
    public bool sink;
    private GameObject item;

    [SerializeField]
    private Transform attachPos;

    [SerializeField]
    private GameObject door;

    void Start(){
        sinkDepth = transform.localScale.y;
        sinkVector = new Vector3(0, sinkDepth, 0);
        sinkDest = transform.position - sinkVector;
        Debug.Log(sinkDest);
        sink = false;
    }

    public void TrySink(GameObject gameObject) {
        Debug.Log("TrySink");
        if(gameObject.tag == "weight" && gameObject.GetComponent<Vase>().type == 0) {
            Debug.Log("Activated");
            // Raise Door
            door.GetComponent<Door>().Open();

            cam.GetComponent<CameraShake>().StartShake(1.5f, 0.05f);
            GetComponent<BoxCollider2D>().enabled = false;
            sink = true;
            gameObject.layer = 0;
            gameObject.transform.SetParent(this.transform);
            item = gameObject;
        }
        else {
            gameObject.transform.position = attachPos.position;
        }

        
    }

    void Update(){


        if (sink){
            if(transform.position.y <= sinkDest.y){
                //Debug.Log("Destroy");
                item.GetComponent<BoxCollider2D>().enabled = false;
                item.transform.SetParent(null);
                Destroy(this.gameObject);
            }
            else {
                //Debug.Log("Move");
                transform.position = Vector3.MoveTowards(transform.position, sinkDest, 0.5f * Time.deltaTime);
                item.transform.position = attachPos.position;
            }
        }
    }
}
