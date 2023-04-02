using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private _GameManager gm;
    private void Start() {
        gm = _GameManager.instance;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Player") {
            gm.Death(3);
        }
        else {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<FallingSpike>());
        }
    }
}
