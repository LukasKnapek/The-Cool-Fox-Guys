using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float acceleration = 1f;
	public float maxSpeed = 5f;

	public float jumpForce = 800f;
	[HideInInspector] public bool jump = false;
	public Transform PlayerGroundCheck;

	private bool grounded = false;
	private int groundmask;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		groundmask = 1 << LayerMask.NameToLayer ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, PlayerGroundCheck.position, groundmask);

		if (Input.GetButtonDown("Jump") && grounded){
			jump = true;
		}
	}

	// Update physics
	void FixedUpdate() {
		
		if (grounded) {
			rb2d.gravityScale = 0;
		} else {
			rb2d.gravityScale = 4;
		}


		float horizontalInput = Input.GetAxisRaw("Horizontal");

		if (horizontalInput != 0 && Mathf.Abs(rb2d.velocity.x) < maxSpeed) {
			if (horizontalInput * acceleration >= maxSpeed) {
				rb2d.velocity = new Vector2 (Mathf.Sign (horizontalInput) * maxSpeed, rb2d.velocity.y);
			} else {
				rb2d.AddForce (new Vector2 (horizontalInput * acceleration, 0), ForceMode2D.Impulse);
			}
		}

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

		if (jump){
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
}
