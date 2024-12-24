using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //ComponentRef
    [Header("ComponentRef")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animatorRef;

    //Movement
    [Header("MovementParams")]
    private int speed;
    [SerializeField] private int walkSpeed;
    [SerializeField] private int sprintSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance;
    [SerializeField] private GameObject groundCheck;

    //Combat
    [Header("CombatParams")]
    [SerializeField] private SwordHits swordRef;

    //Private Params
    private bool isGrounded;
    private Vector3 velocity;

    private void Update()
    {
        //Get X & Z input
        float xMov = Input.GetAxisRaw("Vertical");
        float zMov = -Input.GetAxisRaw("Horizontal");
        //Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        //Jump
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Move the player
        UnityEngine.Vector3 move = transform.forward * xMov - transform.right * zMov;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        controller.Move(move * speed * Time.deltaTime);
        //Make the player jump
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animatorRef.SetTrigger("Attack");
        if (swordRef.enemiesInRange.Count > 0)
        {
            for (int i = swordRef.enemiesInRange.Count - 1; i >= 0; i--)
            {
                Destroy(swordRef.enemiesInRange[i].gameObject);
                swordRef.enemiesInRange.RemoveAt(i);
            }
        }

    }

}
