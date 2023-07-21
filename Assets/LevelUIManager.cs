using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelUIManager : MonoBehaviour
{
    public TMP_Text player1Percentage;
    public TMP_Text player2Percentage;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePercentage(float damage, int player)
    {
        if (player == 1)
        {
            player1Percentage.text = damage.ToString() + "%";
            player1Percentage.GetComponent<Animator>().SetTrigger("GotHit");
        }
        else if (player == 2)
        {
            player2Percentage.text = damage.ToString() + "%";
        }

    }
}
