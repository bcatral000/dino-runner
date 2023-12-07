using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;      //variable for charatcer controller
    private Vector3 direction;                  //direction where player is moving

    public float gravity = 9.81f * 2f;          //gravity physics
    public float jumpForce = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()                     //eventually will be used to disable the player after a game over
    {
        direction = Vector3.zero;               //when player is reenabled direction is set to 0
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;       //direction for gravity

        if (character.isGrounded)                                   //checking is player is grounded
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))                            //plyaer movement
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    //when player collides with obstacles
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        }
    }
}
