using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private GameObject keySprite;
    [SerializeField] private GameObject dynamiteSprite;
    public static HudManager instance { get; set; }
    public static HudManager GetInstance() {
        return instance;
    }

    public void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void showKeyHUD() {
        keySprite.SetActive(true);
    }

    public void hideKeyHUD() {
        keySprite.SetActive(false);
    }

    public void showDynamiteHUD() {
        dynamiteSprite.SetActive(true);
    }

    public void hideDynamiteHUD() {
        dynamiteSprite.SetActive(false);
    }
}
