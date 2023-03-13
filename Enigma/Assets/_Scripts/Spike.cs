using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private _GameManager gm;
    private AudioManager am;
    public GameObject rubble;

    [SerializeField] private AudioClip breakClip;
    [SerializeField] private Transform rubbleSpawn;
    void Awake() {
        am = AudioManager.instance;
        gm = _GameManager.instance;
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            gm.Death(0);
            
        }else if(col.gameObject.tag == "Ground"){
            am.PlaySfx(breakClip);
            Instantiate(rubble, rubbleSpawn.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
