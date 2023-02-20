using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public enum potType { RED, BLUE, YELLOW };

    [field: SerializeField]
    public potType type;
}
