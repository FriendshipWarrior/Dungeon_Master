using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	public float maxSpeed = 10f;
	private bool facingRight = true;
	public int maxHealth = 100;
	public int myHealth = 100;
	Animator anim;
    TrackPlayer camera;
    public int enemiesToKill = 0;
    public int strength = 10;
	//for player combat
	public float InvinsibilityTime = .3f;
	float gotHitAt = 1;
	float canGetHitAt = 0;
	CharacterController player;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        GameObject go = GameObject.Find("Main Camera");
        camera = go.GetComponent<TrackPlayer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveX = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	
		float moveY = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveY * maxSpeed);

		if(moveX != 0)
			anim.SetFloat ("Speed", Mathf.Abs(moveX));
		else
			anim.SetFloat ("Speed", Mathf.Abs(moveY));


		if(moveX > 0 && !facingRight)
			Flip();
		else if(moveX < 0 && facingRight)
	        Flip();
		
		if (enemiesToKill == 0)
			camera.CanFollowPlayer = true;

        if (Input.GetKey(KeyCode.Space))
            AttackStart();

		if (Input.GetKey (KeyCode.E))
			AttackSpecialStart ();
	}

	void AttackStart()
	{
        anim.SetBool("Attack_B", true);
	}

    void AttackEnd()
    {
        anim.SetBool("Attack_B", false);
    }

	void AttackSpecialStart()
	{
		anim.SetBool("Attack_Special", true);
	}
	
	void AttackSpecialEnd()
	{
		anim.SetBool("Attack_Special", false);
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter(Collision collision) 
	{
		print( "Collided with someone" );
		if (Input.GetKey (KeyCode.Space))
			Destroy (collision.gameObject);
		maxHealth += 20;
	}

	public void ChangeHealth(int deltaHealth)
	{
        if(myHealth <= maxHealth)
		    myHealth += deltaHealth;
        if (myHealth > maxHealth)
            myHealth = maxHealth;
	}

    public void MoveX(float x)
    {
        GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x + x, GetComponent<Rigidbody2D>().position.y);
    }

	public void MenuLoader(int level)
	{
		Application.LoadLevel (level);
	}

	public void DoDamageToPlayer (int damage)
	{
		gotHitAt = Time.time;
		if (gotHitAt > canGetHitAt)
		{
			canGetHitAt = gotHitAt + InvinsibilityTime;
			myHealth = myHealth - damage;
			if (myHealth <= 0)
			{
				PlayerDied();
			}
		}
	}
	public void PlayerDied ()
	{
		//Probably should do a death animation or game over screen
		Destroy(gameObject);
		MenuLoader (2);
	}

}
