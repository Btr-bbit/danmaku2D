using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour {
    public float CollectRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        GameObject reward = collision.gameObject;
        if (reward.tag == "Supply")
        {
            reward.GetComponent<Rigidbody2D>().velocity = (transform.position - reward.transform.position) * CollectRate;
            //reward.GetComponent<Rigidbody2D>().AddForce(transform.position - reward.transform.position);
        }
        else if (reward.tag == "Treasure")
        {

        }
	}
}
