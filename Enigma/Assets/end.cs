using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    [SerializeField] _GameManager gm;

    private void Awake() {
        gm = _GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gm.SwitchState(2);
    }
}
