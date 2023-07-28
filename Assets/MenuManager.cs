using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public int winNumber = 0;
    public string player1;
    public string player2;
    public string player3;
    public string player4;
    winnerAnnouncer announcer;
    public GameObject winnerObject;
    public GameObject loserObject;
    private AudioClip _winnerAudio;
    private Sprite _winnerSprite;
    private Sprite _loserSprite;
    
    
    // Start is called before the first frame update
    void Start()
    {
        announcer = FindObjectOfType<winnerAnnouncer>();
        switch (winNumber)
        {
            case 0:
                _winnerAudio = null;
                _winnerSprite = null;
                _loserSprite = null;
                break;
            case 1:
                _winnerAudio = null;
                _winnerSprite = null;
                _loserSprite = null;
                break;
            case 2:
                _winnerAudio = null;
                _winnerSprite = null;
                _loserSprite = null;
                break;
            case 3:
                _winnerAudio = null;
                _winnerSprite = null;
                _loserSprite = null;
                break;
        }
    }

    void Update()
    {

    }
}
