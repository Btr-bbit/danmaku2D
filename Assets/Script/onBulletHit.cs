using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		switch (collider.tag){
		case "Wall":
			break;
		case "Player":
			Player p = collider.GetComponent<Player>();
			p.hit();
			break;
		case "Enemy":
			Destroy(collider.gameObject);
			break;
		case "Bullet":
			return;
		default:
			Debug.Log("onBulletHit.cs: OnTriggerEnter2D(Collider2D),colliderTag:" + collider.name);
			break;
		}
		Destroy(gameObject);
        // if (collider.tag == "Wall" || collider.tag == "Player")
        //     Destroy(gameObject);
    }
}
