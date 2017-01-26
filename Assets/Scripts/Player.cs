using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float movementSpeed;
    public float jumpSpeed = 50f;
    public float turningSpeed = 60f;
    public float gravity = 400f;
    public float defaultGravity = 400f;
    public float fallGravity = 100;
    public bool canMoveWhileJumping;
    public float jumpDelay = 100f;
    public float jumpDelayTimer = 0f;
    public Vector3 move = Vector3.zero;
    public Vector3 direction = Vector3.zero;
    public CharacterController controller;
    public GameObject sword;
    public Transform swordParent;
    public Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movementSpeed = GetComponent<Stats>().movementSpeed;
        sword.transform.SetParent(swordParent);
        
    }

    void Update()
    {
        if (canMoveWhileJumping)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (controller.isGrounded)
        {
            gravity = defaultGravity;
            canMoveWhileJumping = true;
            move = direction * movementSpeed;
            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
                jumpDelayTimer = 0f;
            }
        }
        else
        {
            gravity = fallGravity;
            if(jumpDelayTimer < jumpDelay)
            {
                canMoveWhileJumping = false;
            }
            else
            {
                jumpDelayTimer += Time.deltaTime;
            }
        }
        move.y -= gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }
}
