using UnityEngine;
using System.Collections;

public class GoblinCombat : MonoBehaviour {

    public int Health;
    public float InvinsibilityTime = .3f;
    float gotHitAt = 1;
    float canGetHitAt = 0;
	public int damage = 1;
    CharacterController player;
	Animator anim;

    void Start () {
		GameObject go = GameObject.Find("Player 1");
		anim = this.GetComponent<Animator> ();
        player = go.GetComponent<CharacterController>();
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
    void Behavior (Collider2D other)
    {
		if (anim.GetBool("IsAttacking")) {
			player.DoDamageToPlayer(damage);
		}

        if (Input.GetKey(KeyCode.Space))
        {
            gotHitAt = Time.time;
            if (gotHitAt > canGetHitAt)
            {
                canGetHitAt = gotHitAt + InvinsibilityTime;
                Health = Health - player.strength;
                if (Health <= 0)
                {
                    Destroy(gameObject);
                    player.enemiesToKill -= 1;
                }
            }
        }
    }
}
