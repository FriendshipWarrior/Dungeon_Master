using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {
	
	public Transform player;
	public float offsetX;
    public bool CanFollowPlayer = true;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		Vector3 pos = transform.position;
		
		//offsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanFollowPlayer)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            var preOffsetX = pos.x - transform.position.x;
            if (preOffsetX >= 0)
            {
                transform.position = pos;
            }
        }
	}

    void OnGUI()
    {
        GameObject go = GameObject.Find("Player 1");
        CharacterController p = go.GetComponent<CharacterController>();
        GUILayout.Label(p.myHealth + " / " + p.maxHealth);
    }
}
