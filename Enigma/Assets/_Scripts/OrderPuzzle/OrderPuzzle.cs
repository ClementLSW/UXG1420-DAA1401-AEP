using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPuzzle : MonoBehaviour {
    public GameObject[] interactives;
    public int[] sequence;
    private int currentIndex = 0;

    private AudioManager am;
    [SerializeField] AudioClip gears, creak, thump;

    [SerializeField] GameObject Door;
    Camera cam;
    private void Start() {
        cam = Camera.main;
    }

    private void Awake() {
        am = AudioManager.instance;
    }

    public void CheckInput(int i) {
        if (interactives[i].GetComponent<InteractiveObject>().IsCorrectObject(sequence[currentIndex])) {
            // TODO: [BETA] Play audio for correct choice. like gears grinding
            interactives[i].GetComponent<InteractiveObject>().press();
            am.PlaySfx(gears);
            currentIndex++;

            // Check if the sequence is complete
            if (currentIndex == sequence.Length) {
                am.PlaySfx(creak);
                PuzzleComplete();
            }
        }
        else {
            currentIndex = 0;
            NotifyPlayerOfMistake();
        }
    }

    private void PuzzleComplete() {
        // Trigger an event that completes the puzzle
        Door.GetComponent<Door>().Open();
    }

    private void NotifyPlayerOfMistake() {
        // Notify the player that they made a mistake
        cam.GetComponent<CameraShake>().StartShake(1.0f, 0.1f);
        // TODO: [BETA] Play audio for wrong choice, like a thump.
        am.PlaySfx(thump);
        foreach (GameObject io in interactives) {
            io.GetComponent<InteractiveObject>().reset();
        }
    }
}
