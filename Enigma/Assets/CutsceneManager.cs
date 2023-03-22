using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] public GameObject[] Cutscenes;
    public GameObject cutsceneBG;
    private int currentCutscene = -1;

    public static CutsceneManager instance { get; private set; }

    private void Start() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(currentCutscene == 0 || currentCutscene == 2 || currentCutscene == 3) {
            if(Input.GetButtonDown("Jump")){
                StartCoroutine(PlayNextCutscene(currentCutscene, currentCutscene + 1));
            }
        }else if(currentCutscene >= 0) {
            if (Input.GetButtonDown("Jump")) {
                StartCoroutine(EndCutscene(currentCutscene));
                currentCutscene = -1;
            }
        }
    }

    public IEnumerator PlayCutscene(int id) {
        Debug.Log("Fading in cutscene BG");
        // Start by fading in a Black Screen
        yield return StartCoroutine(cutsceneBG.GetComponent<CutsceneBG>().FadeInImage());

        Debug.Log("Playing cutscene " + (id+1));
        // Play cutscene sequence
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().PlayCutscene());

        currentCutscene = id;
    }

    public IEnumerator PlayNextCutscene(int old_id, int id) {
        Debug.Log("Fading Out Cutscene " + id);
        // Start by fading out a old cutscene
        yield return StartCoroutine(Cutscenes[old_id].GetComponent<Cutscene>().EndCutscene());

        Debug.Log("Fading In Cutscene " + (id + 1));
        // Play cutscene sequence
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().PlayCutscene());
        currentCutscene = id;
    }

    public IEnumerator EndCutscene(int id) {
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().EndCutscene());

        yield return StartCoroutine(cutsceneBG.GetComponent<CutsceneBG>().FadeOutImage());
    }
}
