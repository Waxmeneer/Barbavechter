using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Crying : MonoBehaviour
{
    public float TShake = 5.0f;
    public float degShake = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation *= quaternion.EulerXYZ(0, 0, degShake / 360.0f * math.cos(Time.time / TShake * 2 * math.PI));
    }
}
