using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] Biem;
    private int _nParticles = 0;
    private ParticleSystem _parentParticleSystem;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        _parentParticleSystem = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_parentParticleSystem.particleCount > _nParticles)
        {
            audioData.Play(0);
        }
        _nParticles = _parentParticleSystem.particleCount;
    }
}
