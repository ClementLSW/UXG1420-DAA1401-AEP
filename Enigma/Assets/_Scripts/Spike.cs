using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class Spike : MonoBehaviour
{
    private _GameManager gm;
    private AudioManager audioManager;
    public GameObject rubble;

    [SerializeField]
    private AudioClip clip;

    void Start()
    {
        audioManager = AudioManager.instance;
    }
        void Awake() {
        gm = GameObject.FindWithTag("GM").GetComponent<_GameManager>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            audioManager.PlaySfx(clip);
            //gm.Death(0);
            gm.LoadAlpha();     // TODO: [ALPHA] Remove this after Alpha and reinstate gm.Death(0)
        }else if(col.gameObject.tag == "Ground"){
            Destroy(col.gameObject.GetComponent<Rigidbody2D>());
            Instantiate(rubble, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
