using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private Transform grabPos;

    private BoxCollider2D bc;
    private GameObject selectedObj;
    private GameObject heldItem;
    private GameObject target;
    private bool isHoldingItem;

    void Awake() {
        isHoldingItem = false;
    }

    void Update() {
         if (!isHoldingItem){
             if (Input.GetKeyDown(KeyCode.E) && selectedObj){       // Empty hand
                heldItem = selectedObj;
                heldItem.transform.position = grabPos.position;
                heldItem.transform.SetParent(grabPos);
                isHoldingItem = true;
             }
        }else {                                                     // Held item
            if (Input.GetKeyDown(KeyCode.E) && target){
                Transform targetPos = target.GetComponentInChildren(typeof(Transform)) as Transform;
                if (target.GetComponent<PressurePlate>()) {
                    target.GetComponent<PressurePlate>().TrySink(heldItem);
                } else if (target.GetComponent<Shelf>()) {
                    Transform ap = target.GetComponent<Shelf>().attachPos;
                     heldItem.transform.position = ap.position;
                    heldItem.transform.SetParent(ap);
                }
                //heldItem.transform.position = targetPos.position;
                //heldItem.transform.SetParent(targetPos);
                heldItem = null;
                isHoldingItem = false;
            }         
        }
    }

    // Once the proximity collider is triggered, the closest valid game object is selected
    void OnTriggerEnter2D(Collider2D col) {
        switch (col.gameObject.layer) {
            case 3:
                selectedObj = col.gameObject;
                break;
            case 6:
                target = col.gameObject;
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
        switch (col.gameObject.layer) {
            case 3:
                if (selectedObj = col.gameObject) {
                    selectedObj = null;
                }
                break;
            case 6:
                if (target = col.gameObject) {
                    target = null;
                }
                break;
        }
    }
}
