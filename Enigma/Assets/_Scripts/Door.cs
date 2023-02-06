using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName: "Open")]
    public void Open()
    {
        _animator.SetTrigger(name:"Open");
    }
    // Start is called before the first frame update
}
