using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFoxMove : MonoBehaviour {

	public float acceleration = 1f;
	public float maxSpeed = 5f;
	public float jumpForce = 800f;
	[HideInInspector] public bool jump1 = false;
    [HideInInspector] public bool jump2 = false;
    public Transform Player1GroundCheck;

    private bool grounded = false;
    private int groundmask;
    Animator playerAnim;
    SpriteRenderer mySprite;
    ParticleSystem deathParticle;
    ParticleSystem powerParticle;
    Slider powerBar;
    
	private Rigidbody2D rb2d;
    private AudioClip jumpSound;
    private AudioClip walkSound;
    private AudioClip deathSound;
    private AudioClip screamSound;
    private AudioSource sound;
    private AudioSource mainPlayer;

    private bool canDoubleJump = false;

    // Use this for initialization
    void Awake ()
    {
		rb2d = GetComponent<Rigidbody2D> ();
		groundmask = 1 << LayerMask.NameToLayer ("Ground");
        playerAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        if(GameObject.Find("UI"))
        powerBar = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarFox").GetComponent<Slider>();
        deathParticle = GameObject.Find("DeathParticle").GetComponent<ParticleSystem>();

        jumpSound = Resources.Load("Audio/SFX/jumping/jump", typeof(AudioClip)) as AudioClip;
        walkSound = Resources.Load("Audio/SFX/walking/footsteps_dirt", typeof(AudioClip)) as AudioClip;
        deathSound = Resources.Load("Audio/SFX/interaction/player_death", typeof(AudioClip)) as AudioClip;
        screamSound = Resources.Load("Audio/SFX/interaction/player_hurt", typeof(AudioClip)) as AudioClip;

        sound = this.GetComponent<AudioSource>();
        mainPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, Player1GroundCheck.position, groundmask);

        if (Input.GetButtonDown("Player1Jump"))
        { 
            if (grounded)
            {
                rb2d.AddForce(new Vector2(0f, jumpForce));
                if (powerBar.GetComponent<PowerBarFox>().getPower() > 0f)
                {
                    canDoubleJump = true;
                }
                sound.PlayOneShot(jumpSound);

            }
            else if (canDoubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                sound.PlayOneShot(jumpSound);
                canDoubleJump = false;

                powerBar.GetComponent<PowerBarFox>().decreasePower(0.12f);
                powerParticle = GameObject.Find("FoxPowerParticle").GetComponent<ParticleSystem>();
                powerParticle.transform.position = this.transform.position;
                powerParticle.Play();
            }
        }
    }

    // Update physics
    void FixedUpdate() {

		if (grounded) {
			rb2d.gravityScale = 0;
		} else {
			rb2d.gravityScale = 10;
		}

		float horizontalInput = Input.GetAxisRaw("Player1Horizontal");

        if (horizontalInput > 0)
            mySprite.flipX = false;
        else if (horizontalInput < 0)
            mySprite.flipX = true;
        playerAnim.SetFloat("Walking", horizontalInput);
        
        if (horizontalInput != 0 && Mathf.Abs(rb2d.velocity.x) < maxSpeed) {
			if (horizontalInput * acceleration >= maxSpeed) {
                rb2d.velocity = new Vector2 (Mathf.Sign (horizontalInput) * maxSpeed, rb2d.velocity.y);
			} else {
				rb2d.AddForce (new Vector2 (horizontalInput * acceleration, 0), ForceMode2D.Impulse);
			}
            if (!sound.isPlaying && grounded)
            {
                sound.PlayOneShot(walkSound);
            }
        }

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            deathParticle.transform.position = this.transform.position;
            deathParticle.Play();

            mainPlayer.Stop();
            mainPlayer.PlayOneShot(deathSound);
            mainPlayer.PlayOneShot(screamSound);

            Destroy(this.gameObject);
            GameMaster.GM.GameOver();
        }
        if (collision.gameObject.name == "Level End")
        {
            GameMaster.GM.Win();
        }
    }
}
