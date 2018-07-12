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
            Destroy(gameObject);
			break;
		case "Player":
			Player p = collider.GetComponent<Player>();
			p.GetHit(gameObject);
            Destroy(gameObject);
			break;
		case "Enemy":
            //Destroy(collider.gameObject);
            collider.GetComponent<HPRecorder>().GetHit(gameObject.GetComponent<DamageController>().rawDamage);
            Destroy(gameObject);
			break;
		case "Bullet":
			return;
        case "Reward Collector":
        case "Supply":
            break;
		default:
			Debug.Log("onBulletHit.cs: OnTriggerEnter2D(Collider2D),colliderTag:" + collider.name);
			break;
		}
        // if (collider.tag == "Wall" || collider.tag == "Player")
        //     Destroy(gameObject);
    }
}
