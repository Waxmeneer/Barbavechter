using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public int lives;
    //[HideInInspector]
    public float percentage;
    public int player;
    public Transform spawnPoint;
    public AudioClip deathSound;
    public AudioClip takeDamageSound;
    public Sprite portrait;
    public string nameString;

    // Start is called before the first frame update
    void Start()
    {
        LevelUIManager.Instance.SetPortrait(player, portrait, nameString);
        lives = 3;
        percentage = 0;
    }

    public void TakeDamage(float damage)
    {
        percentage += damage;
        LevelUIManager.Instance.UpdatePercentage(percentage, player);

        if (Random.Range(1,4) >= 3)
        {
            SoundManager.Instance.PlaySound(takeDamageSound);
        }
    }

    public void Die()
    {
        LevelUIManager.Instance.UpdateLives(player, lives);
        lives -= 1;
        percentage = 0;
        SoundManager.Instance.PlaySound(deathSound);
        if (lives != 0)
        {
            StartCoroutine(ResetSequence());
        }
        else if (lives == 0)
        {
            GameManager.Instance.PlayerRanOutOfLives(player);
            //gameObject.SetActive(false);
        }
    }

    private IEnumerator ResetSequence()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        LevelUIManager.Instance.UpdatePercentage(percentage, player);
        gameObject.transform.position = (Vector2)spawnPoint.position + new Vector2(100, 100);
        rigidbody.velocity = (Vector2.zero);
        rigidbody.isKinematic = true;

        yield return new WaitForSeconds(2);

        gameObject.transform.position = spawnPoint.position;
        rigidbody.isKinematic = false;
        yield return null;
    }

    public void GetSpawnPoint()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoints").transform.GetChild(player - 1);
    }
}
