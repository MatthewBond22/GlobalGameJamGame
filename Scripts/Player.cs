using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Movement Variables
    public float speed;
    public float jumpPower;
    public float MaxSpeed;

    // Ground Activation
    public bool grounded;

    // Player Health Variables
    public int curHealth;
    public int maxHealth = 100;

    private Animator anim; 
    private Rigidbody2D rb2d;

	void Start ()
	{
	  rb2d = gameObject.GetComponent<Rigidbody2D>();
	  anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
	}

	void Update()
    {
        // Animation
		anim.SetBool("Grounded",grounded);
		anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
		
        // Move Left
		if(Input.GetAxis("Horizontal") < -0.1f)
		{
			transform.localScale = new Vector3(-1,1,1);
		}

        // Move Right
		if(Input.GetAxis("Horizontal") > 0.1f)
		{
			transform.localScale = new Vector3(1,1,1);
		}

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Death();
        }
    }

    void FixedUpdate () 
	{
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        // Fake friction / Easing the x speed of the player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        // Player Movement
        float h = Input.GetAxis("Horizontal");
	    rb2d.AddForce((Vector2.right * speed) * h);

	  // Limit Movement 
	  if(rb2d.velocity.x > MaxSpeed)
	  {
		  rb2d.velocity = new Vector2(MaxSpeed,rb2d.velocity.y);
	  }
	  if(rb2d.velocity.x < - MaxSpeed)
	  {
		  rb2d.velocity = new Vector2(-MaxSpeed, rb2d.velocity.y); 
	  }
	}

    void Death()
    {
        // Restart game
        SceneManager.LoadScene(0);
    }

    public void Damage (int dmg)
    {
        curHealth -= dmg;
    }

    public IEnumerator Knock(float knockDur, float knockPwr, Vector2 knockDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector2(knockDir.x * -500, knockPwr));
        }

        yield return 0;
    }
}
