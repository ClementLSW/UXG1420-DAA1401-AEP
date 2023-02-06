using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private Transform grabPos;

    [SerializeField]
    private Transform rayPos;

    private GameObject grabbedObject;
    private int rayDist;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(rayPos, Vector2.right, rayDist);

        if (Input.GetButtonDown("E") && !grabbedObject) {
            //Pickup Stuff
        }else if (Input.GetButtonDown("E")) {
            //Put Down Stuff
        }
    }
}
