using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
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
        if (jump.action.IsPressed())
        {
            if(TouchingGround())
            {
                isJumping = true;
                Debug.Log($"{this}: Jumping");
            }
            else if(Climbing())
            {
                Debug.Log($"{this}: Climbing");
                isJumping = true;
            }
            else
                isJumping = false;
        }
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
            0.25f,
            groundMask
        ).Length > 0;
    }
    [SerializeField]
    float height, touchingRadius;
    public bool Climbing()
    {
        return Physics.OverlapCapsule(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z),
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - height, gameObject.transform.position.z),
            touchingRadius,
            groundMask
        ).Length > 0;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z), touchingRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }

}
