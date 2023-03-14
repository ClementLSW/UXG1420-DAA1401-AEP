using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private bool startOpen = false;
    private float timeTillOpen = 2.0f;

    public void Open()
    {
        startOpen = true;
    }

    public void Update() {
        if(startOpen && timeTillOpen > 0.0f) {
            door.transform.Translate(Vector3.up * Time.deltaTime);
        }else if(timeTillOpen <= 0.0f) {
            startOpen = false;
            Destroy(this.GetComponent<Door>());
        }
    }


}
