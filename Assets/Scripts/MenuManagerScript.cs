using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject charSelectScreen;
    public GameObject charSelect1;
    public GameObject charSelect2;
    public GameObject stageSelect;
    public GameObject options;
    public AudioClip hardlyKnowHer;
    public TMP_Text whichPlayer;
    [HideInInspector]
    public int currentPlayer;

    Dictionary<Button, GameObject> selectbuttons = new Dictionary<Button, GameObject>();
    public Button semmieSelect;
    public Button mansaurusSelect;
    public Button menxSelect;
    public Button xanderSelect;
    public Button daenSelect;
    public Button walterSelect;

    public GameObject semmie;
    public GameObject mansaurus;
    public GameObject menx;
    public GameObject xander;
    public GameObject daen;
    public GameObject walter;

    // Start is called before the first frame update
    void Start()
    {
        selectbuttons.Add(semmieSelect, semmie);
        selectbuttons.Add(mansaurusSelect, mansaurus);
        selectbuttons.Add(menxSelect, menx);
        selectbuttons.Add(xanderSelect, xander);
        selectbuttons.Add(daenSelect, daen);
        selectbuttons.Add(walterSelect, walter);

        foreach(KeyValuePair<Button, GameObject> pair in selectbuttons)
        {
            pair.Key.onClick.RemoveAllListeners();
            pair.Key.onClick.AddListener(delegate { FighterManager.Instance.ChooseFighter(pair.Value, currentPlayer); });
        }

        currentPlayer = 1;
        whichPlayer.text = "Speler 1, kies je vechter!";
    }

    public void GoToMainMenu()
    {
       mainMenu.SetActive(true);
       charSelectScreen.SetActive(false);
    }

    public void GoToCharSelect()
    {
        charSelectScreen.SetActive(true);
        charSelect1.SetActive(true);
        mainMenu.SetActive(false);
        SoundManager.Instance.PlaySound(hardlyKnowHer);
    }

    public void GoToOptions()
    {
        //Go to Options menu code here
    }

    public void QuitGame()
    {
        //Quitgamecode here
    }

    public void GoToStageSelect()
    {
        charSelectScreen.SetActive(false);
        stageSelect.SetActive(true);
    }

    public void GoToBattle(int scene)
    {
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(scene);
    }

    public void SwitchCharacterMenu()
    {
        if (charSelect1.activeSelf)
        {
            charSelect1.SetActive(false);
            charSelect2.SetActive(true);
        }
        else
        {
            charSelect1.SetActive(true);
            charSelect2.SetActive(false);
        }
    }

    public void ChooseCharacter()
    {
        if (currentPlayer == 1)
        {
            //currentPlayer = 2;
            whichPlayer.text = "Speler 2, kies je vechter!";
            whichPlayer.color = Color.blue;
        }
        else if (currentPlayer == 2){
            GoToStageSelect();
        }
        
    }
}
