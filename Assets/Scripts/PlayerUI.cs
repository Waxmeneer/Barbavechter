using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Image playerFace;
    public TMP_Text playerName;
    public List<Image> playerLives = new List<Image>();
    public TMP_Text percentage;
    public Animator animator;
    public int player;

    public void SetPortrait(Sprite portrait)
    {
        playerFace.sprite = portrait;
    }
}
