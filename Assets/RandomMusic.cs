using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(PickRandomHitSound());
    }

    private AudioClip PickRandomHitSound()
    {
        AudioClip clip = audioClips[Random.Range(0, audioClips.Count)];
        return clip;
    }
}
