using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int objectId;
    public OrderPuzzle op;

    private void Start() {
        op = gameObject.GetComponentInParent<OrderPuzzle>();
    }
    

    public void SendSignal() {
        op.CheckInput(objectId);
    }

    public bool IsCorrectObject(int expectedId) {
        if (objectId == expectedId) {
            return true;
        }
        else {
            return false;
        }
    }
}
