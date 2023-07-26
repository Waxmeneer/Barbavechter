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

    }

    public void UpdateLives(int player, int lives)
    {
        if (player == 1)
        {
            player1UI.playerLives[lives - 1].enabled = false;
        }

        //delete life code here
    }
}
