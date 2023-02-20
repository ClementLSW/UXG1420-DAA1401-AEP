using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    [SerializeField]
    private AudioManager audioManager;
    
    [SerializeField]
    private AudioClip jumpClip; 

    void Awake() {
        if (player == null) {
            player = this;
        }
        else if (player != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayJump() {
        audioManager.PlaySfx(jumpClip);
    }
}
