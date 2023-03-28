using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] public GameObject[] Cutscenes;
    public GameObject cutsceneBG;
    private int currentCutscene = -1;
    private bool skippable = false;

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
        if((currentCutscene == 0 || currentCutscene == 2 || currentCutscene == 3) && skippable) {
            if(Input.GetButtonDown("Jump")){
                StartCoroutine(PlayNextCutscene(currentCutscene, currentCutscene + 1));
            }
        }else if(currentCutscene >= 0 && skippable) {
            if (Input.GetButtonDown("Jump")) {
                StartCoroutine(EndCutscene(currentCutscene));
                Player.instance.isControllable = true;
                currentCutscene = -1;
            }
        }
    }

    public IEnumerator PlayCutscene(int id) {
        currentCutscene = id;
        skippable = false;
        Debug.Log("Playing cutscene " + (id+1));
        // Play cutscene sequence
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().PlayCutscene());
        skippable = true;
    }

    public IEnumerator PlayNextCutscene(int old_id, int id) {
        currentCutscene = id;
        skippable = false;
        Debug.Log("Fading Out Cutscene " + id);
        // Start by fading out a old cutscene
        yield return StartCoroutine(Cutscenes[old_id].GetComponent<Cutscene>().EndCutscene());

        Debug.Log("Fading In Cutscene " + (id + 1));
        // Play cutscene sequence
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().PlayCutscene());
        skippable = true;
    }

    public IEnumerator EndCutscene(int id) {
        yield return StartCoroutine(Cutscenes[id].GetComponent<Cutscene>().EndCutscene());

        yield return StartCoroutine(CutsceneBG.instance.FadeOutImage());
    }
}
