using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, IAnchor
{
    private Camera cam;

    public float sinkDepth;
    private Vector3 sinkVector, sinkDest;
    public bool sink;
    private GameObject item;
    private bool occupied;

    [SerializeField] private Transform attachPos;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject fall;
    public enum plateType { RED, BLUE, YELLOW };
    [SerializeField] public plateType type;

    Transform IAnchor.attachPos => attachPos;
    bool IAnchor.occupied { get => occupied; set => occupied = value; }

    void Start(){
        sinkDepth = GetComponent<SpriteRenderer>().bounds.size.y;
        sinkVector = new Vector3(0, sinkDepth, 0);
        sinkDest = transform.position - sinkVector;
        Debug.Log(sinkDest);
        sink = false;

        cam = Camera.main;
    }

    public void Activate() {

    }

    public void TrySink(GameObject gameObject) {
        Debug.Log("TrySink");

        switch (type) {
            case plateType.RED:
                if(gameObject.GetComponent<Vase>().type == Vase.vaseType.RED) {
                    if (door){
                        door.GetComponent<Door>().Open();
                        cam.GetComponent<CameraShake>().StartShake(1.5f, 0.05f);
                        GetComponent<BoxCollider2D>().enabled = false;
                        sink = true;
                        gameObject.layer = 0;
                        gameObject.transform.SetParent(this.transform);
                        item = gameObject;
                        return;
                    }
                }
                break;
            case plateType.BLUE:
                if(gameObject.GetComponent<Vase>().type == Vase.vaseType.BLUE) {
                    if (fall) {
                        fall.AddComponent(typeof(Rigidbody2D));
                        cam.GetComponent<CameraShake>().StartShake(1.5f, 0.05f);
                        GetComponent<BoxCollider2D>().enabled = false;
                        sink = true;
                        gameObject.layer = 0;
                        gameObject.transform.SetParent(this.transform);
                        item = gameObject;
                        return;
                    }
                }
                break;
            case plateType.YELLOW:
                break;
        }

        gameObject.transform.position = attachPos.position;
        gameObject.transform.SetParent(this.transform);
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
