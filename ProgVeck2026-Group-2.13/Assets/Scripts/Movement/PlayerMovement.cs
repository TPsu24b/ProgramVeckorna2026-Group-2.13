using System;
using NUnit.Framework;
using Unity.Burst.Intrinsics;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Ref")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump, crouching, sprinting;
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed, sprintMulti;
    [SerializeField] Vector3 _moveDir;
    [SerializeField] bool jumpPressed, crouchPressed, isSprinting;
    [Header("TouchingGround bool")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheckPoint;
    private Rigidbody _rb;
    [Header("Jumping Settings")] 
    public float jumpPower;

    [Header("Climbing settings")]
    [SerializeField] float height;
    [SerializeField] float climbingSlow;
    [SerializeField] Vector3 boxSize;
    SphereCollider _collider;
    [Header("Animator Controller")]
    [SerializeField] private Animator animator;
    
    void Start()
    {
        try
        {
            _collider = GetComponent<SphereCollider>();
            _rb = GetComponent<Rigidbody>();
            Debug.Log($"{this}: Loaded RB");
        }
        catch(Exception error)
        {
            Debug.Log($"{this}: Failed to load \nReason: {error}");
        }
    }
    Vector3 _lastLookDir = Vector3.forward; // default facing direction
    void Update()
    {
        //read the wasd input, convert it into a vector3 used for velocity later
        Vector3 temp = move.action.ReadValue<Vector3>();
        _moveDir = new Vector3(temp.x * moveSpeed, _rb.linearVelocity.y, temp.z * moveSpeed);
        //bools for cheaks in fixedUpdate
        jumpPressed = jump.action.IsPressed();
        crouchPressed = crouching.action.IsPressed();
        isSprinting = sprinting.action.IsPressed();

    }
    bool lastCrouchState;
    void FixedUpdate()
    {     
        //if moving update your horintial rotation overtime   
        Vector3 horizontal = new Vector3(_moveDir.x, 0f, _moveDir.z);
        if (horizontal.sqrMagnitude > 0.001f)
        {
            animator.SetBool("walking", true);
            _lastLookDir = _moveDir.normalized;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(new Vector3(_lastLookDir.x, 0, _lastLookDir.z)),
                Time.deltaTime * 10f
            );
        }
        else 
            animator.SetBool("walking", false);
        animator.SetBool("touchingGround", isGrounded);
        
        isGrounded = CheakGround();
        //if courching and on ground crouch
        if(lastCrouchState != crouchPressed)
        {
            if(crouchPressed)
            {
                transform.localScale = new Vector3(1,0.5f,1);
                _collider.radius = 0.25f;
                animator.SetBool("crouching", true);
            }
            else
            {
                transform.localScale = new Vector3(1,1,1);
                _collider.radius = 0.5f;
                animator.SetBool("crouching", false);
            }
            lastCrouchState = crouchPressed;
        }
        //if space is pressed and jump cooldown isent active
        if (jumpPressed && isGrounded)
        {
            _moveDir.y = jumpPower;
            animator.Play("Jumping");     
        }
        if(isSprinting)
        {
            _moveDir.x *= sprintMulti;
            _moveDir.z *= sprintMulti;
        }
        //apply new velocity
        _rb.linearVelocity = _moveDir;
    }
    bool isGrounded;
    Collider[] groundHits = new Collider[1];
    public bool CheakGround()
    {
        /*creates a shpere on the gameObject GroundCheakPoint
        also cheaks if it collies with the layer in GroundMask*/
        return Physics.OverlapSphereNonAlloc(
            groundCheckPoint.position,
            0.25f,
            groundHits,
            groundMask
        ) > 0;
    }
    void ToggleMovment(bool state)
    {
        //a toggle for this script, as requested of alec
        this.enabled = state;
    }
    //draws the touchingGround and Climbing bools for ease of understanding and use
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }

}
