using UnityEngine;
using System.Collections;

public class BossCombat : MonoBehaviour {
	
	public int Health = 50;
	public float InvinsibilityTime = .3f;
	float gotHitAt = 1;
	float canGetHitAt = 0;
	public int damage = 5;
	CharacterController player;
	Animator anim;
	private GameObject Player;
	
	void Start () {
		GameObject go = GameObject.Find("Player 1");
		anim = this.GetComponent<Animator> ();
		player = go.GetComponent<CharacterController>();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<CharacterController> () == null)
			return;
		Behavior(other);
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.GetComponent<CharacterController>() == null)
			return;
		Behavior(other);
	}

	public void MenuLoader(int level)
	{
		Application.LoadLevel (level);
	}

	void Behavior (Collider2D other)
	{
		if (anim.GetBool("IsAttacking")) {
			if ((transform.rotation.y == 0 && transform.position.x - Player.transform.position.x > 0) || (transform.rotation.y == 180 && transform.position.x - Player.transform.position.x < 0))
				player.DoDamageToPlayer(damage);
		}
		
		if (Input.GetKey(KeyCode.Space))
		{
			if ((transform.rotation.y == 0 && transform.position.x - Player.transform.position.x < 0) || (transform.rotation.y == 180 && transform.position.x - Player.transform.position.x > 0)) 
			{
				gotHitAt = Time.time;
				if (gotHitAt > canGetHitAt)
				{
					canGetHitAt = gotHitAt + InvinsibilityTime;
					Health = Health - player.strength;
					if (Health <= 0)
					{
						Destroy(gameObject);
						MenuLoader(3);
					}
				}
			}
		}
	}
}
