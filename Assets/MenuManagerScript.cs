using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject charSelectScreen;
    public GameObject charSelect1;
    public GameObject charSelect2;
    public GameObject options;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void GoToOptions()
    {
        //Go to Options menu code here
    }

    public void QuitGame()
    {
        //Quitgamecode here
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
}
