using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public LayerMask groundLayer;
    public float groundRayDistance = 1.1f;


    private CharacterController controller;
    private Vector3 motion;

    void Start()
    { 
        // Scope
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        // Normalizing movement
        Vector3 normalized = new Vector3(inputH, 0f, inputV);
        normalized.Normalize();

        Move(normalized.x, normalized.z);

        // Applies motion to CharacterController
        controller.Move(motion * Time.deltaTime);
    }

    // Move the Player Character in the direction we give it (horizontal / vertical)
    public void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Convert local direction to world space
        direction = transform.TransformDirection(direction);

        motion.x = direction.x * speed;
        motion.z = direction.z * speed;
    }
}