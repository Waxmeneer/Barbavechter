using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    public bool loop;

    // Start is called before the first frame update
    void Start()
    {
        if (loop)
        {
            SoundManager.Instance.PlayMusic(_clip);
        }
        else
        {
            SoundManager.Instance.PlaySound(_clip);
        }
    }
}
