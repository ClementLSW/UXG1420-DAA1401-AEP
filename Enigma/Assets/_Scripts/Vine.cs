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
    private AudioManager am;
    [SerializeField] private AudioClip burnClip, openClip;
    [SerializeField] GameObject trapdoor;
    [SerializeField] Sprite burning, burnt;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        am = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lit){
            if (startToLight) {
                secsTillLit -= Time.deltaTime;
                am.PlaySfx(burnClip);
            }
            if (secsTillLit <= 0) {
                lit = true;
                startToLight = false;
                sr.sprite = burning;
            }
        }
        else {
            if(secsTillBurnt > 0) {
                secsTillBurnt -= Time.deltaTime;
            }
            else {
                am.StopSfx(burnClip);
                am.PlaySfx(openClip);
                trapdoor.GetComponent<TrapDoor>().Open();
                sr.sprite = burnt;
                Destroy(GetComponent<Vine>());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!lit) {
            if(collision.GetComponent<Torch>() && collision.GetComponent<Torch>().lit) {
                startToLight = true;
                am.PlaySfx(burnClip);
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
