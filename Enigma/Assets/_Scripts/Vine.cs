using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public bool lit;
    private float secsTillLit = 2.0f;
    private float secsTillBurnt = 3.0f;
    private bool startToLight = false;
    private SpriteRenderer sr;

    [SerializeField] GameObject trapdoor;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lit){
            if (startToLight) {
                secsTillLit -= Time.deltaTime;
            }
            if (secsTillLit <= 0) {
                lit = true;
                startToLight = false;
                sr.color = Color.red;   // TODO: [ALPHA] Change it to actually animating it after Alpha
            }
        }
        else {
            if(secsTillBurnt > 0) {
                secsTillBurnt -= Time.deltaTime;
            }
            else {
                trapdoor.GetComponent<TrapDoor>().Open();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!lit) {
            if(collision.GetComponent<Torch>() && collision.GetComponent<Torch>().lit) {
                startToLight = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(!lit && secsTillLit > 0) {
            startToLight = false;
            secsTillLit = 2.0f;
        }
    }
}
