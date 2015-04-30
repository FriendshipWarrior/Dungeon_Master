using UnityEngine;
using System.Collections;

public class StopCamera : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Hit Cammera Stopper");
        other.GetComponent<TrackPlayer>().CanFollowPlayer = false ;
        GameObject go = GameObject.Find("Player 1");
        CharacterController player = go.GetComponent<CharacterController>();
        player.enemiesToKill = 1;
    }
}
