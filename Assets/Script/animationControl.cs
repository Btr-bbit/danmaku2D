using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour {


	private Animator anim;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
		anim.SetFloat("m_speed",rb.velocity.magnitude);
		
	}
}
