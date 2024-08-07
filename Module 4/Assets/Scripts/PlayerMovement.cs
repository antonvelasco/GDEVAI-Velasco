using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Header ("Movement")]
    public float speed;

    [Header("Camera")]
    public GameObject cameraLook;
    public float mouseSense;
    float xRotation;

    [Header("Physics")]
    [SerializeField]
    Transform groundCheck;
    float groundDistance = 0.4f;
    [SerializeField]
    LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float gravity = -9.81f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        //camera movement
        //fps feels
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraLook.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        gameObject.transform.Rotate(Vector3.up * mouseX);

        //movement
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }
}
