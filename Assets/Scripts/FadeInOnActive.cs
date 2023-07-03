using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnActive : MonoBehaviour
{
    [SerializeField] private CanvasGroup uiGroup;

    private bool fadeIn;
    [SerializeField] private float fadeSpeed;

    private void OnEnable()
    {
        uiGroup.alpha = 0;
        uiGroup = GetComponent<CanvasGroup>();
        //ShowUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (uiGroup.alpha < 1)
            {
                uiGroup.alpha += fadeSpeed * Time.deltaTime;
                if (uiGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
}
