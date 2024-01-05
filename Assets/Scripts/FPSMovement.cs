using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [SerializeField]  private CharacterController controller;
    [SerializeField]  private float speed = 2f;
    [SerializeField]  private float gravity = -9.81f;
    [SerializeField]  private Transform groundCheck;
    [SerializeField] private float GroundDist = 0.4f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float jumpHeight = 3f;

    bool Grounded;

    Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        Grounded = Physics.CheckSphere(groundCheck.position,GroundDist, Ground);

        if(Grounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        } 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        if(Input.GetButtonDown("Jump") && Grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
