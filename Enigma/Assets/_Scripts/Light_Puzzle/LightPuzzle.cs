using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private int lightsOn;
    private Lights[] lights;

    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentsInChildren<Lights>();
        foreach(Lights light in lights) {
            if (light.Lit) lightsOn++;
        }
    }

    public void Increment() {
        lightsOn++;
        if (lightsOn >= 5) {
            door.Open();
            foreach(Lights light in lights) {
                Destroy(light.GetComponent<BoxCollider2D>());
            }
        }
    }

    public void Decrement() {
        lightsOn--;
    }

}
