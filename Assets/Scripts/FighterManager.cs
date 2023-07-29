using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FighterManager : MonoBehaviour
{
    //[HideInInspector]
    public GameObject fighterOne;
    //[HideInInspector]
    public GameObject fighterTwo;
    public GameObject fighterThree;
    public GameObject fighterFour;
    public MenuManagerScript mainMenuManager;
    //public List<GameObject> fighters;
    public int winningplayer;

    public Dictionary<int, string> winnerDict = new Dictionary<int, string>();

    // Singleton instance reference.
    private static FighterManager instance;

    // Property to access the singleton instance.
    public static FighterManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // If an instance already exists, destroy this new instance.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Assign this instance as the singleton instance.
        instance = this;

        // Prevent this singleton from being destroyed when loading a new scene.
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1) // Fighting scene
        {
            List<GameObject> fighters = new List<GameObject>
            {
                fighterOne,
                fighterTwo,
                fighterThree,
                fighterFour
            };
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartFight(fighters);
        }
        else if (scene.buildIndex == 0) // Main menu scene
        {
            // Reset the fighter selection when returning to the main menu.
            fighterOne = null;
            fighterTwo = null;
            fighterThree = null;
            fighterFour = null;
            mainMenuManager = GameObject.FindFirstObjectByType<MenuManagerScript>();
        }
    }

    public void ChooseFighter(GameObject fighter, int player)
    {
        if (player == 1)
        {
            fighterOne = fighter;
            fighterOne.GetComponent<PlayerHealth>().player = 1;
        }
        else if (player == 2)
        {
            fighterTwo = fighter;
            fighterTwo.GetComponent<PlayerHealth>().player = 2;
        }
        else if (player == 3)
        {
            fighterThree = fighter;
            fighterThree.GetComponent<PlayerHealth>().player = 3;
        }
        else if (player == 4)
        {
            fighterFour = fighter;
            fighterFour.GetComponent<PlayerHealth>().player = 4;
        }
        mainMenuManager.currentPlayer += 1;
    }
}
