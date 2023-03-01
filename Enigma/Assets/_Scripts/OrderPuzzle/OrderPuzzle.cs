using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class OrderPuzzle : MonoBehaviour {
    public GameObject[] interactives;
    public int[] sequence;
    private int currentIndex = 0;

    AudioManager am = AudioManager.instance;
    [SerializeField] AudioClip gears, thump;

    [SerializeField] GameObject Door;
    Camera cam;
    private void Start() {
        cam = Camera.main;
    }

    public void CheckInput(int i) {
        if (interactives[i].GetComponent<InteractiveObject>().IsCorrectObject(sequence[currentIndex])) {
            // TODO: [BETA] Play audio for correct choice. like gears grinding
            //am.PlaySfx(gears);
            currentIndex++;

            // Check if the sequence is complete
            if (currentIndex == sequence.Length) {
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
        //am.PlaySfx(thump);
    }
}
