
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Ref")]
    public InputActionReference move;
    public InputActionReference jump;
    [Header("Movement Settings")]
    public float moveSpeed;
    public float jumpPower;
    [Header("TouchingGround bool")]
    public LayerMask groundMask;
    public Transform groundCheckPoint;
    private Rigidbody _rb;
    [SerializeField]
    private Vector3 _moveDir;
    [SerializeField]
    bool isJumping = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 temp = move.action.ReadValue<Vector3>();
        _moveDir = new Vector3(temp.x * moveSpeed, _rb.linearVelocity.y, temp.z * moveSpeed);
        if (jump.action.IsPressed() && TouchingGround())
            isJumping = true;
        else
            isJumping = false;
    }
    void FixedUpdate()
    {     
        Vector3 velocity = new Vector3(_moveDir.x, _moveDir.y, _moveDir.z);
        if (isJumping)
            velocity.y = jumpPower;
        _rb.linearVelocity = velocity;

    }
    public bool TouchingGround()
    {
        return Physics.OverlapSphere(
            groundCheckPoint.position,
            0.5f,
            groundMask
        ).Length > 0;
    }

}
