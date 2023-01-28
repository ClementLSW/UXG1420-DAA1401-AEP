using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 2f, -10);

    [Range(2,10)]
    public float smoothing;
    
    private void FixedUpdate(){
        //transform.position = target.position + offset;
        LerpFollow();
    }

    private void LerpFollow(){
        Vector3 targetPos = Vector3.Lerp(transform.position, target.position + offset, smoothing * Time.fixedDeltaTime);
        transform.position = targetPos;
    }
}