using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.TextCore.Text;
using TMPro;
using System;

public class MoveComponent : MonoBehaviour
{
    public GameObject Coin;
    [SerializeField] TextMeshProUGUI texte;
    [SerializeField] float speed = 4;
    [SerializeField] float forceJump = 5;
    [SerializeField] float gravity;
    [SerializeField] Animator playerAnimator;
    Vector3 jump = new Vector3(0, 0, 0);
    CharacterController character;
    GameObject ObjText;
    TimerComponent timer;

    //Sets all the components at the start
    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("UI").GetComponent<TimerComponent>();

        ObjText = GameObject.FindGameObjectWithTag("IntE");
        texte = ObjText.GetComponent<TextMeshProUGUI>();
        texte.enabled = false;

        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Calls all the functions each frame
    void Update()
    {
        Moving();

        Intéragir(Input.GetButton("E"));
    }

    //Player can move using the old player input and can also jump
    void Moving()
    {
        //Vector3 direction = cameraChar.transform.forward * Input.GetAxis("Vertical") + cameraChar.transform.right * Input.GetAxis("Horizontal");
        Vector3 direction = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        if (direction.magnitude > 0)
        {
            playerAnimator.SetBool("isIdle", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isWalking", true);

            direction = new Vector3(direction.x, 0, direction.z);
            direction = direction.normalized;

            direction = (Input.GetAxis("Sprint") * 0.5f + 1) * direction;
            if (Input.GetButton("Sprint"))
            {
                playerAnimator.SetBool("isIdle", false);
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isRunning", true);
            }
        }

        if (direction.magnitude <= 0)
        {
            playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
        }

        if (!character.isGrounded)
        {
            jump.y -= Time.deltaTime * gravity;
        }
        else
        {
            playerAnimator.SetBool("Grounded", true);
            jump.y = 0;

            if (Input.GetButton("Jump"))
            {
                playerAnimator.SetBool("Grounded", false);


                jump = transform.up * forceJump;
                jump.y = Mathf.Max(-1, jump.y);
            }
            else
            {
                // Reset the value of jump.y to prevent the character from falling through the ground.
                jump.y = -0.1f;
            }
        }
        character.Move((direction * speed + jump) * Time.deltaTime);

    }

    //The player can interact with coins on the ground in the main game which will add time (time = score) and will also destroy the coin
    //whilst showing a text when near the coin.
    public void Intéragir(bool agire)
    {
        if (texte.isActiveAndEnabled)
        {
            if (agire)
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