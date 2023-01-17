using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    public GameObject oyuncu;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = oyuncu.transform.position + offset;
    }
}
