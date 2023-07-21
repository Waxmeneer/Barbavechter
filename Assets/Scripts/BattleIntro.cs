using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleIntro : MonoBehaviour
{
    public GameObject ready;
    public GameObject go;

    private void Start()
    {
        ready.SetActive(false);
        go.SetActive(false);

        StartCoroutine(AnimateBattleIntro());
    }

    private IEnumerator AnimateBattleIntro()
    {
        ready.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        go.SetActive(true);
        yield return new WaitForSeconds(1f);
        ready.SetActive(false);
        go.SetActive(false);
        yield return null;
    }
}
