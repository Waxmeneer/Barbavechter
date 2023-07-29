using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    Light lightSource;
    public float minIntensity = 80.0f;
    public float maxIntensity = 100.0f;
    public float minInterval = 3.0f;
    public float maxInterval = 7.0f;
    public float pDouble = 0.3f;
    private float _lastUpdate;
    private float _interval;
    private float _onTime = 0.06f;
    private int _state = 0;
    void Start()
    {
        lightSource = GetComponent<Light>();
        lightSource.intensity = 0.0f;
        _lastUpdate = Time.time;
        _interval = minInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _lastUpdate+_interval && _state == 0)
        {
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
            _state = 1;
        }
        if (Time.time > _lastUpdate+_interval+_onTime && _state == 1)
        {
            lightSource.intensity = 0.0f;
            _lastUpdate = Time.time;
            if (Random.value < pDouble)
            {
                _interval = Random.Range(minInterval/20, maxInterval/40);
            }
            else
            {
                gameObject.transform.position = new Vector3(Random.Range(-500, 500), Random.Range(100, 300), Random.Range(400, 650));
                _interval = Random.Range(minInterval, maxInterval);
            }
            _state = 0;
        }        
    }
}
