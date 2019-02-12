using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float MoveSpeed = 50.0f;
    [SerializeField]
    private float rotationSpeed = 10;

    private Animator animator;
    private CharacterController characterController;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var horizzontal = Input.GetAxis("Horizontal");
        var vertical    = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", vertical);
        characterController.SimpleMove(transform.forward * MoveSpeed * vertical);
        transform.Rotate(Vector3.up , rotationSpeed * Time.deltaTime * horizzontal);

    }
}
