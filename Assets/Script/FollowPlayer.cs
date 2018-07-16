using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private PolyNavAgent agent;
	public GameObject player;

		void Start(){
			agent = GetComponent<PolyNavAgent>();
			if (player == null) player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		if (player != null) {
			Transform p = player.transform;
			agent.SetDestination(new Vector2(p.position.x, p.position.y));
		}
	}

}

