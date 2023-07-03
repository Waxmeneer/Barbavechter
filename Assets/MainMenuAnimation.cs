using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimation : MonoBehaviour
{

    public Image Logo;
    public Button vechterButton;
    public Button optionsButton;
    public Button quitButton;


    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(FadeInMenu());
    }

    IEnumerator FadeInMenu()
    {
        yield return new WaitForSeconds(0.88f);
        Logo.GetComponent<FadeInOnActive>().ShowUI();
        yield return new WaitForSeconds(2f);
        vechterButton.GetComponent<FadeInOnActive>().ShowUI();
        yield return new WaitForSeconds(0.35f);
        optionsButton.GetComponent<FadeInOnActive>().ShowUI();
        yield return new WaitForSeconds(0.35f);
        quitButton.GetComponent<FadeInOnActive>().ShowUI();

        yield return null;
    }
}
