using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> fighters = new List<GameObject>();

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete other.

        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void StartFight(List<GameObject> selectedFighters)
    {
        // Called when the fight begins.
        fighters.Clear(); // Ensure the list is empty before populating it.
        foreach (GameObject selectedFighter in selectedFighters)
        {
            // Instantiate the selected fighters and add them to the fighters list.
            GameObject newFighter = Instantiate(selectedFighter, Vector3.zero, Quaternion.identity);
            fighters.Add(newFighter);
            // Set up any necessary components for the fighter.
            newFighter.GetComponent<PlayerHealth>().GetSpawnPoint();
        }
    }

    public void PlayerRanOutOfLives(int player)
    {
        // Called when a player runs out of lives.
        GameObject defeatedPlayer = fighters.Find(fighter => fighter.GetComponent<PlayerHealth>().player == player);
        if (defeatedPlayer != null)
        {
            defeatedPlayer.SetActive(false); // Deactivate the defeated player.
        }

        // Check for victory condition after all players have finished their turn.
        CheckForVictory();
    }

    public void CheckForVictory()
    {
        //print("Checking for win");
        GameObject winner = new GameObject();
        bool victory = false;
        int checker = 0;
        int highestLives = 0;

        foreach(GameObject fighter in fighters)
        {
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
                FighterManager.Instance.winningplayer = winner.GetComponent<PlayerHealth>().player;
            }
            StartCoroutine(WinningSequence());
        }
    }

    private IEnumerator WinningSequence()
    {
        Time.timeScale = 0.1f;
        //Playsomeanimations
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1f;
        //LoadnewScene
        SceneManager.LoadScene(0);

        yield return null;
    }

    // Rest of the GameManager or GameController code...
}