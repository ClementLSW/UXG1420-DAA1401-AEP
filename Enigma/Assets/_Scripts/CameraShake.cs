using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private float duration, magnitude, fade;
    private float x,y;

    private void LateUpdate(){
        if (duration > 0){
            //Shake
            x = Random.Range(-1f,1f) * magnitude;
            y = Random.Range(-1f, 1f) * magnitude;

            transform.position += new Vector3(x, y, 0);

            magnitude = Mathf.MoveTowards(magnitude, 0, fade * Time.deltaTime);

            duration -= Time.deltaTime;
        }
    }
    
    public void StartShake (float dur, float mag){
        duration = dur;
        magnitude = mag;
        fade = mag / dur;
    }
}
