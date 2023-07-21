using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public int lives;
    //[HideInInspector]
    public float percentage;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        percentage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        //loselife code
    }

    public void TakeDamage(float damage)
    {
        percentage += damage;
        LevelUIManager.Instance.UpdatePercentage(percentage, player);
    }
}
