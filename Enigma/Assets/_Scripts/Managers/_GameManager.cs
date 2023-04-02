using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour {

    // ========== STATIC VARIABLES ========== //
    public static _GameManager instance { get; set; }
    public static _GameManager GetInstance() {
        return instance;
    }
    public static bool isPaused { get; private set; }
    public static bool isCutscene { get; set; }
    public static bool cutscenePlayed { get; set; }

    // ========== SERIALIZED MEMBER VARIABLES ========== //
    [Header("Level Indicator Variables\n")]
    [SerializeField] public Image m_levelIndicator;
    [SerializeField] public Sprite[] m_levelIdicatorSprite;

    [Header("Victory Screen Variables\n")]
    [SerializeField] public Image m_victoryImage;
    [SerializeField] public TMP_Text m_victoryText;
    [SerializeField] public Sprite[] m_victorySprites;

    // ========== PUBLIC MEMBER VARIABLES ========== //
    [Header("Game Manager Variables\n")]
    public GameObject player;
    public GameObject deathMenu;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject victoryMenu;
    public GameObject credits;
    
    public void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            Screen.SetResolution(1920, 1080, false);
            instance = this;
            isPaused = false;
            isCutscene = false;
            cutscenePlayed = false;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void togglePause() {
        if(isCutscene == false) {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
            Debug.Log(isPaused);
        }
        
    }

    public void Respawn() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName =="Level 1") {
            SwitchState(2);
        }else if(currentSceneName == "Level 2") {
            SwitchState(3);
        }else if( currentSceneName == "Level 3") {
            SwitchState(4);
        }else if(currentSceneName == "Secret") {
            SwitchState(5);
        }
        else {
            SwitchState(0);
        }
    }

    public void SwitchState(int state) {
        if (Player.instance != null) Player.instance.GetComponent<Grab>().DestroyHeldItem();
        switch (state) {
            case 0:
                SceneManager.LoadScene("Main Menu");
                break;
            case 1:
                SceneManager.LoadScene("Tutorial");
                break;
            case 2:
                SceneManager.LoadScene("Level 1");
                break;
            case 3:
                SceneManager.LoadScene("Level 2");
                break;
            case 4:
                SceneManager.LoadScene("Level 3");
                break;
            case 5:
                SceneManager.LoadScene("Secret");
                break;
            case 6:
                SceneManager.LoadScene("End");
                break;
            case 7:
                SceneManager.LoadScene("Alpha");
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);
        if (deathMenu.activeSelf) {
            deathMenu.SetActive(false);
        }
        //player = GameObject.FindWithTag("Player");
        if (Player.instance != null) {
            Player.instance.isAlive = true;
        }

        if (scene.name == "Tutorial") {
            Player.instance.isControllable = false;
            StartCoroutine(CutsceneManager.instance.PlayCutscene(0));
            m_levelIndicator.sprite = m_levelIdicatorSprite[0];
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[0]);
        }
        else if (scene.name == "Level 1") {
            if (cutscenePlayed == false) {
                Player.instance.isControllable = false;
                StartCoroutine(CutsceneManager.instance.PlayCutscene(2));
                cutscenePlayed = true;
            }
            else {
                StartCoroutine(CutsceneBG.instance.FadeOutImage());
            }
            m_levelIndicator.sprite = m_levelIdicatorSprite[1];
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[0]);
        }
        else if(scene.name == "Level 2") {
            StartCoroutine(CutsceneBG.instance.FadeOutImage());
            m_levelIndicator.sprite = m_levelIdicatorSprite[2];
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[0]);
        }
        else if (scene.name == "Level 3") {
            StartCoroutine(CutsceneBG.instance.FadeOutImage());
            m_levelIndicator.sprite = m_levelIdicatorSprite[3];
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[0]);
        }
        else if (scene.name != "Main Menu") {
            Debug.Log("BG Fade");
            StartCoroutine(CutsceneBG.instance.FadeOutImage());
            cutscenePlayed = false;
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[0]);
        }
        else {
            if(Player.instance != null) Destroy(Player.instance.gameObject);
            if(CutsceneBG.instance.bg.alpha > 0) {
                StartCoroutine(CutsceneBG.instance.FadeOutImage());
            }
            AudioManager.instance.PlayBGM(AudioManager.instance.bgmList[1]);
        }
    }

    public void Death(int deathType) {
        /*  Governs the game state behaviour on Player Death
         *  Params: deathType operation code
         *  0   -   Player fell on spikes
         *  1   -   Player fell from height
         *  2   -   Player crushed by boulder
         *  3   -   Player crushed by falling spikes
         */

        // Set player alive status to dead;
        Player.instance.isAlive = false;

        // Prepare death Menu
        deathMenu.SetActive(true);
        deathMenu.GetComponent<DeathManager>().renderDeathSprite(deathType);

        // Destroy whatever player is holding
        Player.instance.GetComponent<Grab>().DestroyHeldItem();
    }

    public void Victory(bool idol) {
        if (idol == true) {
            m_victoryImage.sprite = m_victorySprites[1];
            m_victoryText.text = "Finally, It's mine!";
        }
        else {
            m_victoryImage.sprite = m_victorySprites[0];
            m_victoryText.text = "I made it out!";
        }

        // Turn on Victory Screen
        victoryMenu.SetActive(true);
    }

    public void ToggleCredits() {
        credits.SetActive(!credits.activeInHierarchy);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
