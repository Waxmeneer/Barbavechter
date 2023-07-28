using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpInterval = 3.0f;
    public float jumpVelocity = 5.0f;
    public float gravity = -10f;

    private Vector3 _startPosition;
    private int state = 0;
    private float _jumpTime = 0.4f;
    private float _timeInAnimation;
    private Vector3 _jumpVector;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        _startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _timeInAnimation = Time.time % jumpInterval;
        if ( state == 0 )
        {
            if ( _timeInAnimation <= _jumpTime )
            {
                audioData.Play();
                state = 1;
            }
        }
        else if ( state == 1 )
        {
            _jumpVector = new Vector3(0, gravity * Mathf.Pow(_timeInAnimation, 2) + jumpVelocity * _timeInAnimation, 0);
            gameObject.transform.position = _startPosition + _jumpVector;
            if (gameObject.transform.position.y <= _startPosition.y)
            {
                state = 0;
                gameObject.transform.position = _startPosition;
            }
        }
        else
        {
            state = 0;
        }
    }
}
