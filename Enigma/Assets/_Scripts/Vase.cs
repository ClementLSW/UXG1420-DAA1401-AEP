using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public bool startFill, filled = false;
    public float cap = 5.0f;
    public float secToFill = 5.0f;
    [SerializeField] private GameObject mask;



    private void Update() {
        if (startFill && secToFill >0) {
            secToFill -= Time.deltaTime;
            Debug.Log(secToFill + "," + cap);
            mask.transform.position += new Vector3(0, Time.deltaTime * 2 / 5.0f , 0);
        }

        if(secToFill <= 0) {
            filled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "water") {
            startFill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "water") {
            startFill = false;
        }
    }
}
