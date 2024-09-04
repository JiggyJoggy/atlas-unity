using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BowlingBallInteractions : MonoBehaviour
{

    public GameObject PlayerController;
    public GameObject BowlingBall;
    public Rigidbody RB;
    public float Speed;
    public bool BallMove = false;


    public int Score = 0;
    public string TextNumber = "0";
    public TextMeshProUGUI textGameObject;

    public GameObject BallHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlleyFloor"))
        {
            PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = false;

            BallMove = true;
        }
        else if (other.CompareTag("Boost"))
        {
            RB.AddForce(0,0,Speed * 50);
        }
        else if (other.CompareTag("Saw"))
        {
            BowlingBall.transform.position = BallHolder.transform.position;
        }
        else if (other.CompareTag("pins"))
        {
            Destroy(other.gameObject);
            if (int.TryParse(textGameObject.text, out int currentScore))
            {
                currentScore++;
                Score = currentScore;
                textGameObject.text = Score.ToString();
            }
            else
            {
                Debug.LogError("Failed to parse score from text");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AlleyFloor"))
        {
            PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = true;
            BallMove = false;
        }
    }

    public void Move()
    {
        if (BallMove == true)
        {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            BowlingBall.transform.position += Movement * Speed * Time.deltaTime;
        }
    }
}
