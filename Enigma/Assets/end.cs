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
        int sceneID = 0;
        if (collision.gameObject.tag == "Player")
        {
            
            if (secret) {
                sceneID = 5;
            }

            if (currentSceneName == "Tutorial") {sceneID = 2;}
            else if (currentSceneName == "Level 1") { sceneID = 3; }
            else if (currentSceneName == "Level 2") { sceneID = 4; }
            else if (currentSceneName == "Level 3") { sceneID = 6; }
            else if (currentSceneName == "Alpha") { sceneID = 1; }
            else { Debug.Log("ERROR: end.cs"); }
            StartCoroutine(CutsceneBG.instance.FadeInImage());
            StartCoroutine(loadScene(sceneID));

            
        }
    }
    private IEnumerator loadScene(int sceneID) {
        Debug.Log("StartLoadScene");
        float t = 1.0f;
        float i = 0.0f;

        while (i < t) {
            i += Time.deltaTime;
            yield return null;
        }

        gm.SwitchState(sceneID);

    }
}
