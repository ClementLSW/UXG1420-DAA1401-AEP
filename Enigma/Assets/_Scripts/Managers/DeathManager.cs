using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite[] deathSprites;
    [SerializeField] private TMP_Text deathText;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void renderDeathSprite(int op) {
        img.sprite = deathSprites[op];

        switch (op) {
            case 0:
                deathText.text = "You fell onto some spikes";
                break;
            case 1:
                deathText.text = "You fell to your death";
                break;
            case 2:
                deathText.text = "You got crushed by a boulder";
                break;
            default:
                deathText.text = "You died!";
                break;
        }
    }
}
