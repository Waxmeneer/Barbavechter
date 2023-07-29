using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerAnnouncer : MonoBehaviour
{
    public float delayTime = 2.5f;
    public float delayTime2 = 5.0f;
    public AudioClip winAnnouncerAudio;
    public AudioClip characterNameAudio;
    public AudioClip winScoreAudio;
    AudioSource audioData;

    private float _startTime;
    private int state = 0;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (_startTime + 0.01f) && state == 0)
        {
            audioData.clip = winAnnouncerAudio;
            audioData.Play();
            state = 1;
        }
        if (Time.time > (_startTime + delayTime) && state == 1)
        {
            audioData.clip = characterNameAudio;
            audioData.Play(0);
            state = 2;
        }
        if (Time.time > (_startTime + delayTime2) && state == 2)
        {
            audioData.clip = winScoreAudio;
            audioData.volume = 0.4f;
            audioData.Play(0);
            state = 3;
        }
    }
}
