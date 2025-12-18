using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEditor;
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
    [Header("TouchingGround bool")]
    public LayerMask groundMask;
    public Transform groundCheckPoint;
    private Rigidbody _rb;
    [SerializeField]
    private Vector3 _moveDir;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    [Header("Jumping Settings")]
    public float jumpPower;
    [SerializeField]
    float jumpCooldown = 0.2f;
    float timer;
    [SerializeField]
    bool isJumping = false;
    [SerializeField]
    bool canJump = true;
    void Update()
    {
        Vector3 temp = move.action.ReadValue<Vector3>();
        _moveDir = new Vector3(temp.x * moveSpeed, _rb.linearVelocity.y, temp.z * moveSpeed);

        if (!canJump)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                canJump = true;
            }
        }
        if (jump.action.IsPressed() && canJump)
        {
            if(TouchingGround())
            {
                Debug.Log($"{this}: Jumping");
                isJumping = true;
            }
            else if(Climbing())
            {
                Debug.Log($"{this}: Climbing");
                isJumping = true;
            }
            else
            {
                isJumping = false;
                JumpCoolDown();
            }
        }
        else if(jump.action.WasReleasedThisFrame())
        {
            JumpCoolDown();
        }
        else
            isJumping = false;
        
    }
    void JumpCoolDown()
    {
        canJump = false;
        timer = jumpCooldown;
    }
    void FixedUpdate()
    {     
        Vector3 velocity = new Vector3(_moveDir.x, _moveDir.y, _moveDir.z);
        if (isJumping)
            velocity.y = jumpPower;
        if(Climbing())
        {
            velocity.y *= climbingSlow;
            Debug.Log($"{this}: slow climb");
        }
        _rb.linearVelocity = velocity;

    }
    public bool TouchingGround()
    {
        return Physics.OverlapSphere(
            groundCheckPoint.position,
            0.25f,
            groundMask
        ).Length > 0;
    }
    [Header("Climbing settings")]
    [SerializeField]
    float height, climbingSlow;
    [SerializeField]
    Vector3 boxSize;
    public bool Climbing()
    {
        return Physics.OverlapBox(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z),
            boxSize,
            transform.rotation,
            groundMask
        ).Length > 0;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z), boxSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }

}
