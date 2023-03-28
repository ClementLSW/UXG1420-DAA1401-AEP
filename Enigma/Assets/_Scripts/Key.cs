using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player") {
            // SceneManager.LoadScene("Level1");
            Debug.Log("KeyCollected");
            col.gameObject.GetComponent<Player>().key = true;
            HudManager.instance.showKeyHUD();
            Destroy(gameObject);
        }
    }
}
