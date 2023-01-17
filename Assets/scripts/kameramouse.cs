using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameramouse : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;
    private Vector3 offset;
   // private Rigidbody rb;
    void Start()
    {
        offset = transform.position - player.transform.position;
       // rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    void FixedUpdate()
    {

        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(rotateHorizontal, 0.0f, rotateVertical);

        transform.RotateAround(player.transform.position, -Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        transform.Rotate(transform.right * rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity)

       // rb.AddForce(rotation * sensitivity);
    }
}
