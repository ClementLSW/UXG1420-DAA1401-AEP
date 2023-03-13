using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour, IAnchor
{
    [SerializeField] public Transform attachPos;
    [SerializeField] public bool occupied;

    Transform IAnchor.attachPos { get => attachPos; }
    bool IAnchor.occupied { get => occupied; set => occupied = value; }

    public bool isValidObj(GameObject go) {
        return go.GetComponent<Pot>();
    }
}
