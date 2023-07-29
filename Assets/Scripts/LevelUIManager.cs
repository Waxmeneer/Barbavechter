using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class LevelUIManager : MonoBehaviour
{
    public PlayerUI player1UI;
    public PlayerUI player2UI;
    public PlayerUI player3UI;
    public PlayerUI player4UI;

    public static LevelUIManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetPortrait(int player, Sprite portrait, string playerName)
    {
        if (player == 1)
        {
            player1UI.SetPortrait(portrait);
            player1UI.playerName.text = playerName;
        }
        if (player == 2)
        {
            player2UI.SetPortrait(portrait);
            player2UI.playerName.text = playerName;
        }
        if (player == 3)
        {
            player3UI.SetPortrait(portrait);
            player3UI.playerName.text = playerName;
        }
        if (player == 4)
        {
            player4UI.SetPortrait(portrait);
            player4UI.playerName.text = playerName;
        }
    }

    public void UpdatePercentage(float damage, int player)
    {
        if (player == 1)
        {
            player1UI.percentage.text = damage.ToString() + "%";
            player1UI.animator.SetTrigger("GotHit");
        }
        else if (player == 2)
        {
            player2UI.percentage.text = damage.ToString() + "%";
            player2UI.animator.SetTrigger("GotHit");
        }
        else if (player == 3)
        {
            player3UI.percentage.text = damage.ToString() + "%";
            player3UI.animator.SetTrigger("GotHit");
        }
        else if (player == 4)
        {
            player4UI.percentage.text = damage.ToString() + "%";
            player4UI.animator.SetTrigger("GotHit");
        }

    }

    public void UpdateLives(int player, int lives)
    {
        if (player == 1 && lives != 0)
        {
            player1UI.playerLives[lives - 1].enabled = false;
        }
        if (player == 2 && lives != 0)
        {
            player2UI.playerLives[lives - 1].enabled = false;
        }
        if (player == 3 && lives != 0)
        {
            player3UI.playerLives[lives - 1].enabled = false;
        }
        if (player == 4 && lives != 0)
        {
            player4UI.playerLives[lives - 1].enabled = false;
        }

        //delete life code here
    }
}
