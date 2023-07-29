using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject winnerObject;
    public GameObject loserObject;

    public AudioClip winAudioWolterbink;
    public AudioClip winAudioXander;
    public AudioClip winAudioDaen;
    public AudioClip winAudioWalter;
    public AudioClip winAudioMansaurus;
    public AudioClip winAudioSemmySemtex;
    public Sprite spriteWolterbink;
    public Sprite spriteXander;
    public Sprite spriteDaen;
    public Sprite spriteWalter;
    public Sprite spriteMansaurus;
    public Sprite spriteSemmySemtex;

    private static int _winNumber = 0;
    private Dictionary<int, string> _playerDict = new();
    private AudioClip _winnerAudio;
    private Sprite _winnerSprite;
    private Sprite _loserSprite;
    private int _secNumber;
    private string _name;

    winnerAnnouncer announcer;
    Sprite playerNameToSprite(string playerName)
    {
        Sprite playerSprite = spriteDaen;
        if (playerName == "Wolterbink")
        {
            playerSprite = spriteWolterbink;
        }
        else if (playerName == "Xander")
        {
            playerSprite = spriteXander;
        }
        else if (playerName == "Daen")
        {
            playerSprite = spriteDaen;
        }
        else if (playerName == "Walter")
        {
            playerSprite = spriteWalter;
        }
        else if (playerName == "Mansaurus")
        {
            playerSprite = spriteMansaurus;
        }
        else if (playerName == "SemmySemtex")
        {
            playerSprite = spriteSemmySemtex;
        }
        return playerSprite;
    }
    AudioClip playerNameToWinAudio(string playerName)
    {
        AudioClip winAudio = winAudioDaen;
        if (playerName == "Wolterbink")
        {
            winAudio = winAudioWolterbink;
        }
        else if (playerName == "Xander")
        {
            winAudio = winAudioXander;
        }
        else if (playerName == "Daen")
        {
            winAudio = winAudioDaen;
        }
        else if (playerName == "Walter")
        {
            winAudio = winAudioWalter;
        }
        else if (playerName == "Mansaurus")
        {
            winAudio = winAudioMansaurus;
        }
        else if (playerName == "SemmySemtex")
        {
            winAudio = winAudioSemmySemtex;
        }
        return winAudio;
    }

    // Start is called before the first frame update
    void Start()
    {
        announcer = FindObjectOfType<winnerAnnouncer>();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        if (FighterManager.Instance != null)
        {
            _winNumber = FighterManager.Instance.winningplayer;
            _playerDict = FighterManager.Instance.winnerDict;
        }
        if (_playerDict.Count == 0)
        {
            _playerDict.Add(0, "Walter");
            _playerDict.Add(1, "Daen");
        }

        _name = _playerDict[_winNumber];
        _winnerSprite = playerNameToSprite(_name);
        _winnerAudio = playerNameToWinAudio(_name);
        _secNumber = _winNumber;
        while (_secNumber == _winNumber)
        {
            _secNumber = Random.Range(1, _playerDict.Count);
        }
        _name = _playerDict[_secNumber];
        _loserSprite = playerNameToSprite(_name);
        announcer.characterNameAudio = _winnerAudio;
        winnerObject.GetComponent<SpriteRenderer>().sprite = _winnerSprite;
        loserObject.GetComponent<SpriteRenderer>().sprite = _loserSprite;
    }
}