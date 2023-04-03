using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    private SpriteRenderer sr;
    private LightPuzzle lp;

    [SerializeField] private Sprite lit;
    [SerializeField] private Sprite unlit;
    [SerializeField] private Lights prev, next;
    [SerializeField] private bool isLit;
    public bool Lit { get { return isLit; } }


    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        lp = GetComponentInParent<LightPuzzle>();

        if (isLit) sr.sprite = lit;
        else sr.sprite = unlit;

        //if (isLit) sr.color = Color.yellow;
        //else sr.color = Color.white;
    }

    public void SendSignal() {
        toggle();
        if(prev) prev.toggle();
        if(next) next.toggle();
        lp.Validate();
    }

    private void toggle() {
        isLit = !isLit;

        if (isLit) {
            sr.sprite = lit;
            //sr.color = Color.yellow;
            lp.Increment();
        }
        else {
            sr.sprite = unlit;
            //sr.color = Color.white;
            lp.Decrement();
        }

    }
}
