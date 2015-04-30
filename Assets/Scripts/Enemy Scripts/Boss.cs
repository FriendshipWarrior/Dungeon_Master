using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<CharacterController> () == null)
			return;
		if (Input.GetKey(KeyCode.Space))
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.GetComponent<CharacterController>() == null)
			return;
		if (Input.GetKey(KeyCode.Space))
		{
			Destroy(gameObject);
		}
	}
}