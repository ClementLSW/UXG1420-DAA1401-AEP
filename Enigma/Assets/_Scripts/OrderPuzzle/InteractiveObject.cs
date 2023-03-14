using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int objectId;
    public OrderPuzzle op;
    private SpriteRenderer sr;
    [SerializeField] private Sprite unpressed, pressed;

    private void Start() {
        op = gameObject.GetComponentInParent<OrderPuzzle>();
    }

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
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

    public void press() {
        sr.sprite = pressed;
    }

    public void reset() {
        sr.sprite = unpressed;
    }
}
