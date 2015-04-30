using UnityEngine;
using System.Collections;

public class FoodPickup : MonoBehaviour {

	public int healthGained;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<CharacterController> () == null)
			return;
        if (Input.GetKey(KeyCode.Space))
        {
            other.GetComponent<CharacterController>().ChangeHealth(healthGained);
            Destroy(gameObject);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;
        if (Input.GetKey(KeyCode.Space))
        {
            other.GetComponent<CharacterController>().ChangeHealth(healthGained);
            Destroy(gameObject);
            print("Food is good");
        }
    }
}
