using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float camRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");

        transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * camRotateSpeed);

        transform.LookAt(player.transform.position);
    }
}
