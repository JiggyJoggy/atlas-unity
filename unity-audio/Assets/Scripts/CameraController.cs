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

        //if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        //{
            transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * camRotateSpeed);
            transform.LookAt(player.transform.position);
       // }

        //if (Input.GetKey(KeyCode.A))
       // {
       //     player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
       // }
       // if (Input.GetKey(KeyCode.D))
       // {
       //     player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
       // }
       // if (Input.GetKey(KeyCode.W))
       // {
       //     player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       // }
       // if (Input.GetKey(KeyCode.S))
        //{
        //    player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
       // }
    }
}
