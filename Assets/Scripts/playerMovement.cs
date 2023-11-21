using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //inspired by https://www.youtube.com/watch?v=4HpC--2iowE&t=292s
    public GameObject Coin;
    [SerializeField] TextMeshProUGUI texte;
    [SerializeField] CharacterController character;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Transform cam;
    [SerializeField] Animator playerAnimator;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity;
    [SerializeField] float forceJump;
    float turnSmoothVelocity;
    bool isGrounded;
    Vector3 directionJump = Vector3.zero;
    GameObject ObjText;
    TimerComponent timer;

    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("UI").GetComponent<TimerComponent>();

        ObjText = GameObject.FindGameObjectWithTag("IntE");
        texte = ObjText.GetComponent<TextMeshProUGUI>();
        texte.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float halfHeight = character.height * 0.5f;
        var bottomPoint = transform.TransformPoint(character.center - Vector3.up * halfHeight);
        isGrounded = Physics.CheckSphere(bottomPoint, 0.1f, groundMask);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            playerAnimator.SetBool("isIdle", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetInteger("speed", 1);
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (Input.GetButton("Sprint"))
            {
                playerAnimator.SetBool("isIdle", false);
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isRunning", true);
                playerAnimator.SetInteger("speed", 2);
                speed = 10f;
            }
            else
            {
                speed = 6f;
            }
            character.Move(moveDirection * speed * Time.deltaTime);
        }

        if (direction.magnitude <= 0)
        {
            playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetInteger("speed", 0);
        }

        if (isGrounded)
        {
            directionJump.y = 0;

            if (Input.GetButton("Jump"))
            {
                playerAnimator.SetBool("Grounded", false);
                Debug.Log("is Jumping");

                directionJump = transform.up * forceJump;
                directionJump.y = Mathf.Max(-1, directionJump.y);
            }
            else
            {
                playerAnimator.SetBool("Grounded", true);
                // Reset the value of jump.y to prevent the character from falling through the ground.
                directionJump.y = -0.1f;
            }
        }
        else
        {
            directionJump.y += gravity * Time.deltaTime;
        }
        //directionJump.y += gravity * Time.deltaTime;
        character.Move(directionJump * Time.deltaTime);
    }

    public void Interact(bool button)
    {
        if (texte.isActiveAndEnabled)
        {
            if (button)
            {
                playerAnimator.SetBool("Interact", true);
                timer.AddTimePoint();
                texte.enabled = false;
                Destroy(Coin);
                Coin = null;
            }
        }
    }
}
