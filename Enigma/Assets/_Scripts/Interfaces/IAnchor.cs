using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnchor
{
    Transform attachPos { get; }
    bool occupied { get; set; }

    bool isValidObj(GameObject go);
}
