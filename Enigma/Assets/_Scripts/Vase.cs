using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public enum vaseType { RED, BLUE, YELLOW };

    [field: SerializeField]
    public vaseType type;
}
