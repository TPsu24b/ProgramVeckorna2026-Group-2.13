
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Ref")]
    public InputActionReference move;
    [Header("Movement Settings")]
    public float moveSpeed;
    public float upForce;
    public float cloudSlow;
    [Header("TouchingGround bool")]
    public LayerMask groundMask;
    public Transform groundCheckPoint;
    private Rigidbody2D _rb;
    [SerializeField]
    private Vector2 _moveDir;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    } 
    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(_rb.linearVelocity.x,_rb.linearVelocity.y);
        
        velocity = new Vector2(_moveDir.x * moveSpeed, _rb.linearVelocity.y);
        
        _rb.linearVelocity = velocity;

    }
    public bool TouchingGround()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, .5f, groundMask);
    }
}
