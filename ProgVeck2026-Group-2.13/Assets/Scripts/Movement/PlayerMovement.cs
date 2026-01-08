using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Ref")]
    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference crouching;
    [Header("Movement Settings")]
    public float moveSpeed;
    [SerializeField]
    private Vector3 _moveDir;
    [Header("TouchingGround bool")]
    public LayerMask groundMask;
    public Transform groundCheckPoint;
    private Rigidbody _rb;
    [Header("Jumping Settings")]
    public float jumpPower;
    [SerializeField]
    float jumpCooldown = 0.2f;
    float timer;
    [SerializeField]
    bool isJumping = false;
    [SerializeField]
    bool jumpTimerActive = true;

    [Header("Climbing settings")]
    [SerializeField]
    float height, climbingSlow;
    [SerializeField]
    Vector3 boxSize;
    void Start()
    {
        try
        {
            _rb = GetComponent<Rigidbody>();
            Debug.Log($"{this}: Loaded RB");
        }
        catch(Exception error)
        {
            Debug.Log($"{this}: Failed to load RB\nReason: {error}");
        }
    }
    void Update()
    {
        //read the wasd input, convert it into a vector3 used for velocity later
        Vector3 temp = move.action.ReadValue<Vector3>();
        _moveDir = new Vector3(temp.x * moveSpeed, _rb.linearVelocity.y, temp.z * moveSpeed);
        //if cooldown is active reduce time remaining
        if (!jumpTimerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                jumpTimerActive = true;
            }
        }
    }
    //activate jump cooldown
    void JumpCoolDown()
    {
        jumpTimerActive = false;
        timer = jumpCooldown;
    }
    void FixedUpdate()
    {     
            
        isGrounded = CheakGround();
        isClimbing = CheakClimbing();
        //if courching and on ground crouch
        if(crouching.action.IsPressed() && isGrounded)
        {
            #if UNITY_EDITOR
            Debug.Log($"{this}: Crouching");
            #endif
        }
        //if space is pressed and jump cooldown isent active
        else if (jump.action.IsPressed() && jumpTimerActive)
        {
            //jump
            if(isGrounded)
            {
                #if UNITY_EDITOR
                Debug.Log($"{this}: Jumping");
                #endif
                isJumping = true;
            }
            //climb
            else if(isClimbing)
            {
                #if UNITY_EDITOR
                Debug.Log($"{this}: Climbing");
                #endif
                isJumping = true;
            }
            //stop jumping
            else
            {
                #if UNITY_EDITOR
                Debug.Log($"{this}: Stop jumping");
                #endif
                if(isJumping)
                    JumpCoolDown();
                isJumping = false;
            }
        }
        //if not jumping 
        else
            isJumping = false;
        //addd moveDir to a new vector
        Vector3 velocity = new Vector3(_moveDir.x, _moveDir.y, _moveDir.z);
        //if jumping make velocity.y jump power
        if (isJumping)
            velocity.y = jumpPower;
        /*if climbing change the velocity.y by the slow 0>x>1
        because climbing can only happen when jumping it is bassicaly jumpPower*climbingSlow*/
        if(isClimbing)
        {
            velocity.y *= climbingSlow;
            #if UNITY_EDITOR
            Debug.Log($"{this}: slow climb");
            #endif
        }
        //apply new velocity
        _rb.linearVelocity = velocity;
    }
    bool isGrounded;
    bool isClimbing;

    public bool CheakGround()
    {
        /*creates a shpere on the gameObject GroundCheakPoint
        also cheaks if it collies with the layer in GroundMask*/
        return Physics.OverlapSphere(
            groundCheckPoint.position,
            0.35f,
            groundMask
        ).Length > 0;
    }
    public bool CheakClimbing()
    {
        /*creats a box inside of the player with a custom height
        the size of the box is a vector3 with the var boxSize
        cheacks for collisions on the layermask groundMask*/
        return Physics.OverlapBox(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z),
            boxSize,
            transform.rotation,
            groundMask
        ).Length > 0;
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
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.35f);
    }

}
