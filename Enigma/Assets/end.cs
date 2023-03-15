using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    [SerializeField] _GameManager gm;
    [SerializeField] bool secret = false;

    private void Awake() {
        gm = _GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        if (collision.gameObject.tag == "Player")
        {
            if (secret) {
                gm.SwitchState(5);
            }

            if (currentSceneName == "Tutorial")
                gm.SwitchState(2);
            else if (currentSceneName == "Level 1")
                gm.SwitchState(3);
            else if (currentSceneName == "Level 2")
                gm.SwitchState(4);
            else if (currentSceneName == "Level 3")
                gm.SwitchState(6);
            else if (currentSceneName == "Alpha")
                gm.SwitchState(1);
            else
                Debug.Log("ERROR: end.cs");
        }
    }
}
