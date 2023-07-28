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
    public MenuManagerScript mainMenuManager;
    private List<GameObject> fighterPrefabs;
    //public List<GameObject> fighters;
    public int winningplayer;

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
                fighterTwo
            };
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartFight(fighters);
        }
        else if (scene.buildIndex == 0) // Main menu scene
        {
            // Reset the fighter selection when returning to the main menu.
            fighterOne = null;
            fighterTwo = null;
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
        mainMenuManager.currentPlayer += 1;
    }

    /*public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");         //Find Spawnpoints
                                                                                                //Spawn players
            for (int i = 0;  i < fighterPrefabs.Count; i++)
            {
                GameObject newplayer = Instantiate(fighterPrefabs[i], spawnpoints[i].transform.position, Quaternion.identity);
                newplayer.GetComponent<PlayerHealth>().spawnPoint = spawnpoints[i].transform;
                fighters.Add(newplayer);
            }
        }

        //When entering Menu, clear fighter list for new fight
        if (scene.buildIndex == 0)
        {        
            //print("loaded main menu");
            if (fighterPrefabs.Count > 0)
            {
                fighterPrefabs.Clear();
                fighterPrefabs.RemoveAll(s => s == null);
            }     
            
            //print("Cleared fighters");
            foreach (GameObject fighter in fighters)
            {
                Destroy(fighter);
                fighters.RemoveAll(s => s == null);
            }
        }
    }*/

    /*public void ChooseFighter(GameObject fighter)
    {
        if (mainMenuManager.GetComponent<MenuManagerScript>().currentPlayer == 1)
        {
            fighterOne = fighter;
            fighterOne.GetComponent<PlayerHealth>().player = 1;
            fighterPrefabs.Add(fighterOne);
        }
        else if (mainMenuManager.GetComponent<MenuManagerScript>().currentPlayer == 2)
        {
            fighterTwo = fighter;
            fighterTwo.GetComponent<PlayerHealth>().player = 2;
            fighterPrefabs.Add(fighterTwo);
        }
    }*/

    /*public void PlayerRanOutOfLives(int player)
    {
        //print("Checking for win");
        GameObject winner = new GameObject();
        bool victory = false;
        int checker = 0;
        int highestLives = 0;

        foreach(GameObject fighter in fighters)
        {
            print(fighter);
            print(fighter.GetComponent<PlayerHealth>().lives);
            int fighterLives = fighter.GetComponent<PlayerHealth>().lives;
            if (fighterLives > highestLives)
            {
                highestLives = fighterLives;
                winner = fighter;
            }

            if (fighter.GetComponent<PlayerHealth>().lives == 0)
            {
                checker += 1;
                //print("FighterDown");
            }
            if (checker == fighters.Count - 1)
            {
                //print("winner");
                victory = true;
            }
        }
        if (victory)
        {
            if (winner != null)
            {
                winningPlayer = winner.GetComponent<PlayerHealth>().player;
            }
            StartCoroutine(WinningSequence());
        }
    }*/
}
