using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dondurucu : MonoBehaviour
{
    float speed = 5.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 15, 0) *speed* Time.deltaTime);
        
    }
}
