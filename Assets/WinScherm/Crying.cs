using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Crying : MonoBehaviour
{
    private float _TShake = 5.0f;
    private float _degShake = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation *= quaternion.EulerXYZ(0, 0, _degShake / 360 * math.cos(Time.time / _TShake * 2 * math.PI));
    }
}
