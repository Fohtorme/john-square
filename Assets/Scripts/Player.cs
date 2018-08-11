using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Ground Mask
    public LayerMask groundMask;
    // Jump speed
    public float jumpSpeed = 7f;
    // Jump fall adjust
    public float jumpFallAdjust = 2f;
    // Jump height adjust
    public float jumpHeightAdjust = 3f;

    // Moviment speed
    private float movimentSpeed = 5f;
    // Rigid body
    private Rigidbody playerRb;
    // Indicates if the object is grounded
    private bool isGrounded;


	// Use this for initialization
	void Start () {
        playerRb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Load parameters
        isGrounded = Physics.OverlapBox(getGroundDetectionPosition(), 
            getGroundDetectionSize(),
            new Quaternion() , 
            groundMask).Length != 0;
        // Optimizations
        if(playerRb.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * (jumpHeightAdjust - 1f) * Time.deltaTime;
        } else if (playerRb.velocity.y < 0f)
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * (jumpFallAdjust - 1f) * Time.deltaTime;
        }
        // Actions
        this.gameObject.transform.Translate(Vector3.forward * 
            Input.GetAxis("Vertical") * 
            Time.deltaTime *
            movimentSpeed);
        this.gameObject.transform.Translate(Vector3.right * 
            Input.GetAxis("Horizontal") * 
            Time.deltaTime *
            movimentSpeed);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.velocity = Vector3.up * jumpSpeed;
        }
        // Input.GetAxis("Horizontal");
        // Input.GetButton("Fire1");

        // Commands:
        // Dash -> Shift
        // Shot -> Mouse 1
        // Moviment -> WASD
        // Focus -> Mouse 2
        // Changes shape -> Numbers
        // Interact -> E
        // Swap -> ???
        // Save place -> ???
        // Load place -> ???
        // Duplicate body -> (your copy will copy yours moviment's too)

        // Objects:
        // Glue
        // Teleporters
        // Buttons
        // Places to put some specify object
        // Winders
        // 

    }

    // Ground detection position
    private Vector3 getGroundDetectionPosition()
    {
        Vector3 position = this.gameObject.transform.position;
        position.y -= 0.510f;
        return position;
    }

    // Ground detection size
    private Vector3 getGroundDetectionSize()
    {
        return new Vector3(1f, 0.05f, 1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(getGroundDetectionPosition(), getGroundDetectionSize());
    }
}
