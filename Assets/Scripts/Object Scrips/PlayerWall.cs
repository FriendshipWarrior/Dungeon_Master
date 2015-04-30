using UnityEngine;
using System.Collections;

public class PlayerWall : MonoBehaviour {

    public bool leftside = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        Behavior(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Behavior(other);
    }

    void Behavior(Collider2D other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;
        if (leftside)
            other.GetComponent<CharacterController>().MoveX(0.3f);
        else
            other.GetComponent<CharacterController>().MoveX(-0.3f);
    }
}
