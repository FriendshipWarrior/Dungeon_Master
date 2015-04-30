using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform Target;
	private GameObject Player;
	private float Range;
	public float Speed = 1;
	public float FollowDistance = 10;
	public float AttackDistance = 2;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.x > transform.position.x)
			transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
		else
			transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
		Range = Vector2.Distance (transform.position, Player.transform.position);
		if (Range <= AttackDistance) {
			anim.SetBool ("IsAttacking", true);
			anim.SetBool ("IsWalking", false);
		}
		else if (Range <= FollowDistance) {
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsWalking", true);
			transform.position += (Player.transform.position - transform.position).normalized * Speed * Time.deltaTime;
		}
		else {
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsWalking", false);
		}
		
	}
	
}