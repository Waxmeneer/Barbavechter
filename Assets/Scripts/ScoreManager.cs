using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Lives;
    public int player2Lives;
    public int player3Lives;
    public int player4Lives;

    private void Start()
    {
        PlayerHealth[] players = GameObject.FindObjectsOfType<PlayerHealth>();

        foreach (PlayerHealth player in players)
        {

        }
    }
}
