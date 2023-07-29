using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UI;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    private float _TShake = 11.0f;
    private float _degShake = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = quaternion.EulerXYZ(0, 0, _degShake/360*math.cos(Time.time/_TShake*2*math.PI));
    }
}
