using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    private Animator animControl;
    [SerializeField] private GameObject drop;

    private void Awake() {
        animControl = GetComponent<Animator>();
    }

    public void Burn() {
        Debug.Log("TD_Burn");
        animControl.SetTrigger("Burn");
    }

    public void Open() {
        Debug.Log("TD_Open");
        animControl.SetTrigger("Open");
        if (drop) {
            drop.AddComponent<Rigidbody2D>();
            drop.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }
}
