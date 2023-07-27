using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerAnnouncer : MonoBehaviour
{
    public float delayTime = 3.0f;
    public float delayTime2 = 5.0f;
    public AudioClip winAnnouncerAudio;
    public AudioClip characterNameAudio;
    public AudioClip winMusicAudio;
    AudioSource audioData;

    private float _startTime;
    private int state = 0;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        _startTime = Time.time;
        audioData.clip = winAnnouncerAudio;
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (_startTime + delayTime) && state == 0)
        {
            audioData.clip = characterNameAudio;
            audioData.Play(0);
            state = 1;
        }
        if (Time.time > (_startTime + delayTime2) && state == 1)
        {
            audioData.clip = winMusicAudio;
            audioData.Play(0);
            state = 2;
        }
    }
}
