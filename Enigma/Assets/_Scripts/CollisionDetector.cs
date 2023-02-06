using System;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;

    [SerializeField]
    private UnityEvent collisionEntered;

    [SerializeField]
    private UnityEvent collisionExit;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(colliderScript))
        {
            collisionEntered?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(colliderScript))
        {
            collisionExit?.Invoke();
        }
    }
}
