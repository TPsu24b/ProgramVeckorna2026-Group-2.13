using System;
using NUnit.Framework;
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
    
    void Update()
    {
        //read the wasd input, convert it into a vector3 used for velocity later
        Vector3 temp = move.action.ReadValue<Vector3>();
        _moveDir = new Vector3(temp.x * moveSpeed, _rb.linearVelocity.y, temp.z * moveSpeed);
        
        jumpPressed = jump.action.IsPressed();
        crouchPressed = crouching.action.IsPressed();
        isSprinting = sprinting.action.IsPressed();
    }
    bool lastCrouchState;
    void FixedUpdate()
    {     
            
        isGrounded = CheakGround();
        isClimbing = CheakClimbing();
        //if courching and on ground crouch
        if(lastCrouchState != crouchPressed)
        {
            if(crouchPressed)
            {
                transform.localScale = new Vector3(1,0.5f,1);
                _collider.radius = 0.25f;
            }
            else
            {
                transform.localScale = new Vector3(1,1,1);
                _collider.radius = 0.5f;
            }
            lastCrouchState = crouchPressed;
        }
        //if space is pressed and jump cooldown isent active
        if (jumpPressed)
        {
            //jump
            if(isGrounded ||isClimbing)
            {
                _moveDir.y = jumpPower;
            }
        }
        if(isSprinting)
        {
            _moveDir.x *= sprintMulti;
            _moveDir.z *= sprintMulti;
        }
        /*if climbing change the velocity.y by the slow 0>x>1
        because climbing can only happen when jumping it is bassicaly jumpPower*climbingSlow*/
        if(isClimbing)
        {
            _moveDir.y *= climbingSlow;
        }
        //apply new velocity
        _rb.linearVelocity = _moveDir;
    }
    bool isGrounded;
    bool isClimbing;
    Collider[] groundHits = new Collider[1];
    Collider[] climbHits = new Collider[1];
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
    public bool CheakClimbing()
    {
        /*creats a box inside of the player with a custom height
        the size of the box is a vector3 with the var boxSize
        cheacks for collisions on the layermask groundMask*/
        return Physics.OverlapBoxNonAlloc(
            transform.position + Vector3.up * height,           
            boxSize,
            climbHits,
            transform.rotation,
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z), boxSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }

}
