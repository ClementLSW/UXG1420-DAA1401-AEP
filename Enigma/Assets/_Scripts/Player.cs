using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class Player : MonoBehaviour
{

    public static Player player;

    [SerializeField]
    private AudioManager audioManager;
    
    [SerializeField]
    private AudioClip jumpClip; 

    void Awake() {
        audioManager = AudioManager.instance;
        if (player == null) {
            player = this;
        }
        else if (player != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJump() {
        audioManager.PlaySfx(jumpClip);
    }
}
