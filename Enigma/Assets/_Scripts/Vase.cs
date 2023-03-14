using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class Vase : MonoBehaviour
{
    public bool startFill, filled = false;
    public float cap = 5.0f;
    public float secToFill = 5.0f;
    private AudioManager audioManager;
    private SpriteRenderer sr;
    [SerializeField] private Sprite vase_filled;
    //[SerializeField] private GameObject mask;
    [SerializeField] private AudioClip fillClip;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        audioManager = AudioManager.instance;
    }

    private void Update() {
        if (startFill && secToFill >0) {
            secToFill -= Time.deltaTime;
            Debug.Log(secToFill + "," + cap);
            //mask.transform.position += new Vector3(0, Time.deltaTime * 2 / 5.0f , 0);
        }

        if(secToFill <= 0) {
            sr.sprite = vase_filled;
            audioManager.StopSfx(fillClip);
            filled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "water") {
            audioManager.PlaySfx(fillClip);
            startFill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "water") {
            audioManager.StopSfx(fillClip);
            startFill = false;
        }
    }
}
