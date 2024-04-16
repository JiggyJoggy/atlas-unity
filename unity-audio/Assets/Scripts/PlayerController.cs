using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Vector3 startPos;
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    public Animator tyAnimator;
    public AudioSource grassAudio;
    public AudioSource stoneAudio;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        tyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 movementDirection = cameraForward * verticalInput + Camera.main.transform.right * horizontalInput;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                tyAnimator.SetBool("IsJump", true);
            }
            else
            {
                tyAnimator.SetBool("IsJump", false);
            }
            tyAnimator.SetBool("IsFalling", false);
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        if (characterController.velocity.x != 0)
        {
            tyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            tyAnimator.SetBool("IsRunning", false);
        }

        characterController.Move(velocity * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        if (player.transform.position.y < -50f)
        {
            player.transform.position = startPos;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grass") && characterController.velocity.x != 0)
        {
            Debug.Log("Touching grass ya");
            grassAudio.enabled = true;
        }
        else
        {
            grassAudio.enabled = false;
        }
        
        if (other.CompareTag("Stone") && characterController.velocity.x != 0)
        {
            Debug.Log("Touching stone wo");
            stoneAudio.enabled = true;
        }
        else
        {
            stoneAudio.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other) // TODO: FIX THIS BECAUSE TIMING IS NOT RIGHT NOR WORKING
    {
        if (other.CompareTag("Grass") && tyAnimator.GetBool("IsFalling") == true)
        {
            Debug.Log("YOU FELL LOL GG");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Not touching anything");
        grassAudio.enabled = false;
        stoneAudio.enabled = false;
    }

    private void LateUpdate()
    {
        if (player.transform.position.y < -5f)
        {
            tyAnimator.SetBool("IsFalling", true);
        }
    }
}
