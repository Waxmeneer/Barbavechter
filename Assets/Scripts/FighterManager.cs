using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FighterManager : MonoBehaviour
{
    //[HideInInspector]
    public GameObject fighterOne;
    //[HideInInspector]
    public GameObject fighterTwo;
    public GameObject mainMenuManager;
    private List<GameObject> fighters;

    private void Awake()
    {
        fighters = new List<GameObject>();
        DontDestroyOnLoad(this.gameObject);
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
        if (scene.buildIndex == 1)
        {
            GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");         //Find Spawnpoints
                                                                                                //Spawn players
            for (int i = 0;  i < fighters.Count; i++)
            {
                Instantiate(fighters[i], spawnpoints[i].transform.position, Quaternion.identity);
            }

        }

        //When entering Menu, clear fighter list for new fight
        if (scene.buildIndex == 0)
        {
            if (fighters.Count > 0)
            {
                fighters.Clear();
            }
        }
    }

    public void ChooseFighter(GameObject fighter)
    {
        if (mainMenuManager.GetComponent<MenuManagerScript>().currentPlayer == 1)
        {
            fighterOne = fighter;
            fighters.Add(fighter);
        }
        else if (mainMenuManager.GetComponent<MenuManagerScript>().currentPlayer == 2)
        {
            fighterTwo = fighter;
            fighters.Add(fighter);
        }
    }
}
