using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I am super depressed;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private Transform grabPos;

    //private BoxCollider2D bc;
    [SerializeField] private GameObject selectedObj, puzzleInteractable;
    [SerializeField] private GameObject heldItem;
    private GameObject target;
    [SerializeField] private bool isHoldingItem;

    void Awake() {
        isHoldingItem = false;
    }

    void Update() {
         if (!isHoldingItem){
             if (Input.GetKeyDown(KeyCode.E) && selectedObj){       // Empty hand
                heldItem = selectedObj;
                Destroy(heldItem.GetComponent<Rigidbody2D>());
                heldItem.transform.position = grabPos.position;
                if (heldItem.GetComponentInParent<IAnchor>() != null) {
                    heldItem.GetComponentInParent<IAnchor>().occupied = false;
                }
                
                heldItem.transform.SetParent(grabPos);
                isHoldingItem = true;
             }
        }else {                                                     // Held item
            if (Input.GetKeyDown(KeyCode.E) && target){
                //Transform targetPos = target.GetComponentInChildren(typeof(Transform)) as Transform;
                if (target.GetComponent<PressurePlate>()) {
                    target.GetComponent<PressurePlate>().TrySink(heldItem);
                    heldItem = null;
                    isHoldingItem = false;
                } else if (target.GetComponent<IAnchor>() != null && !target.GetComponent<IAnchor>().occupied) {
                    IAnchor ins = target.GetComponent<IAnchor>();
                    Transform ap = ins.attachPos;
                    heldItem.transform.position = ap.position;
                    heldItem.transform.SetParent(ap);
                    ins.occupied = true;
                    heldItem = null;
                    isHoldingItem = false;
                    //Transform ap = target.GetComponent<Shelf>().attachPos;
                    //heldItem.transform.position = ap.position;
                    //heldItem.transform.SetParent(ap);
                }
            }
            else if(Input.GetKeyDown(KeyCode.E) && heldItem.GetComponent<Torch>()) {
                heldItem.AddComponent<Rigidbody2D>();
                heldItem.AddComponent<BoxCollider2D>();
                heldItem.transform.SetParent(null);
                heldItem = null;
                isHoldingItem = false;
            }      
        }

         if(Input.GetKeyDown(KeyCode.E) && puzzleInteractable) {
            if (puzzleInteractable.GetComponent<InteractiveObject>()) puzzleInteractable.GetComponent<InteractiveObject>().SendSignal();
            if (puzzleInteractable.GetComponent<Lights>()) puzzleInteractable.GetComponent<Lights>().SendSignal();
        }
    }

    // Once the proximity collider is triggered, the closest valid game object is selected
    void OnTriggerEnter2D(Collider2D col) {
        switch (col.gameObject.layer) {
            case 3:
                selectedObj = col.gameObject;
                break;
            case 6:
                Debug.Log("Targetfound");
                target = col.gameObject;
                break;
            case 7:
                Debug.Log("Interactable found");
                puzzleInteractable = col.gameObject;
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
            case 7:
                if(puzzleInteractable = col.gameObject) {
                    puzzleInteractable = null;
                }
                break;
        }
    }

    public void DestroyHeldItem() {
        // Make sure objects cannot be carried from one scene to the other
        Destroy(heldItem);
        isHoldingItem = false;
    }
}
