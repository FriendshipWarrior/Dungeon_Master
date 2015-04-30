using UnityEngine;
using System.Collections;

public class StopCameraAndSpawn : MonoBehaviour {
    public float spawnTime = 5f;		// The amount of time between each spawn.
    public float spawnDelay = 3f;		// The amount of time before spawning starts.
    public GameObject[] enemies;		// Array of enemy prefabs.
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Hit Cammera Stopper");
        GameObject go = GameObject.Find("Player 1");
        CharacterController player = go.GetComponent<CharacterController>();
        player.enemiesToKill = enemies.Length;

        other.GetComponent<TrackPlayer>().CanFollowPlayer = false ;

        var toSpawn = spawnTime;
        for (int i = 0; i < enemies.Length; i++)
        {
            Invoke("Spawn", toSpawn);
            toSpawn += spawnDelay;
        }
        //Spawn(spawnDelay);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        foreach(var enemy in enemies)
        {
            if (enemy != null)
                return;
        }
        other.GetComponent<TrackPlayer>().CanFollowPlayer = true;

    }

    void Spawn()
    {
        print("Spawned!");
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }
}
